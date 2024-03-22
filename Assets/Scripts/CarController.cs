using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{
    public ElectricAddPoint electricAddPoint;
    public float battery;
    public float minBattery=0f;
    public float maxBattery = 100f;
    public Slider batterySlider;
    


    private float horizontalInput;
    private float verticalInput;

    private bool isFren;
    private float currentFrenForce;
    private float currentDonusAcisi;

    //[SerializeField] private float carMaxSpeed;
    public float maxDonusAcisi, motorTorqueForce, brakeForce;
    

    [SerializeField] private WheelCollider onSolTekerlerkCollider;
    [SerializeField] private WheelCollider onSagTekerlerkCollider;
    [SerializeField] private WheelCollider arkaSolTekerlerkCollider;
    [SerializeField] private WheelCollider arkaSagTekerlerkCollider;

    [SerializeField] private Transform onSolTekerlekTransform;
    [SerializeField] private Transform onSagTekerlekTransform;
    [SerializeField] private Transform arkaSolTekerlekTransform;
    [SerializeField] private Transform arkaSagTekerlekTransform;

   
    AudioSource audioSource;
    public float minEngineSound=0f;
    public float MaxEngineSound = 1f;
    public float engineSound;
    public GameObject panel,RoadLights,ElectricCar,infopanel;
    public Rigidbody rbElectricCar;

    public TMP_Text DurumC,BatteryPercent,BatteryBreakeCharge,FindedObjects;
    
    
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    private void Start()
    {
        Time.timeScale = 0.0f;
        battery = 100f;
        audioSource.volume = 0f;
        





    }

    private void Update()
    {
        FindedObjects.text = electricAddPoint.collectedObjectCount+ " / 20";
        batterySlider.value = battery;
        BatteryPercent.text = "% " + (int)battery;
        battery=Mathf.Clamp(battery,minBattery,maxBattery);

        if(battery < 60)
        {
            batterySlider.fillRect.GetComponent<Image>().color = Color.yellow;
        }
        if (battery < 25)
        {
            
            batterySlider.fillRect.GetComponent<Image>().color = Color.red;
        }
        if (battery ==0)
        {
            Time.timeScale = 0;
            audioSource.volume = 0;
            panel.SetActive(true);
            DurumC.text = "You have failed this city. Try to drive more efficient ";
            
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale=0;
            infopanel.SetActive(true);
            audioSource.Pause();
        
        }

        

    }
    
    
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("AddBattery"))
        {
            electricAddPoint.collectedObjectCount++;
            battery += +4;
            Destroy(col.gameObject);


        }
        if (electricAddPoint.collectedObjectCount >= 20)
        {
            Time.timeScale = 0;
            audioSource.volume = 0;
            panel.SetActive(true);
            DurumC.text = "Congratulations, you won!";
        }
        
    }
    public void TryAgainButton()
    {
        panel.SetActive(false);
        
        SceneManager.LoadScene(1);

       
    }

    public void ExitGame()
    {
        Application.Quit();
    }


    private void FixedUpdate()
    {
        getUserInput();
        moveTheCar();
        rotateTheCar();
        rotateTheWheels();




        
    }
   
    private void rotateTheWheels()
    {
        rotateTheWheel(onSolTekerlerkCollider, onSolTekerlekTransform);
        rotateTheWheel(onSagTekerlerkCollider, onSagTekerlekTransform);
        rotateTheWheel(arkaSolTekerlerkCollider, arkaSolTekerlekTransform);
        rotateTheWheel(arkaSagTekerlerkCollider, arkaSagTekerlekTransform);
    }

    private void rotateTheWheel(WheelCollider tekerlerkCollider, Transform tekerlekTransform)
    {
        Vector3 position;
        Quaternion rotation;
        tekerlerkCollider.GetWorldPose(out position, out rotation);
        tekerlekTransform.position = position;
        tekerlekTransform.rotation = rotation;
    }

    private void rotateTheCar()
    {
        currentDonusAcisi = maxDonusAcisi * horizontalInput;
        onSolTekerlerkCollider.steerAngle = currentDonusAcisi;
        onSagTekerlerkCollider.steerAngle = currentDonusAcisi;
    }

    private void moveTheCar()
    {
        onSolTekerlerkCollider.motorTorque = verticalInput * motorTorqueForce;
        onSagTekerlerkCollider.motorTorque = verticalInput * motorTorqueForce;
        currentFrenForce = isFren ? brakeForce : 0f;
        if (Input.GetKey(KeyCode.Space))
        {
            onSolTekerlerkCollider.brakeTorque = currentFrenForce;
            onSagTekerlerkCollider.brakeTorque = currentFrenForce;
            arkaSolTekerlerkCollider.brakeTorque = currentFrenForce;
            arkaSagTekerlerkCollider.brakeTorque = currentFrenForce;


            if (Mathf.Abs(rbElectricCar.velocity.magnitude) > 0.1f)
            {
                battery += 0.015f;
                BatteryBreakeCharge.text = "+";
            }
            else
            {
                BatteryBreakeCharge.text = "";
            }



        }
        else
        {
            onSolTekerlerkCollider.brakeTorque = 0f;
            onSagTekerlerkCollider.brakeTorque = 0f;
            arkaSolTekerlerkCollider.brakeTorque = 0f;
            arkaSagTekerlerkCollider.brakeTorque = 0f;

            BatteryBreakeCharge.text = "";


            
            
        }
    }

    private void getUserInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical")*5f;
        if (verticalInput > 0)
        {
            audioSource.volume = Mathf.Min(audioSource.volume + 0.2f * Time.deltaTime, MaxEngineSound);
            battery -= 0.030f;
           
        }
        else 
        { audioSource.volume = Mathf.Min(audioSource.volume + -0.3f * Time.deltaTime, MaxEngineSound); }

        

        isFren = Input.GetKey(KeyCode.Space);
        if (Input.GetKeyDown(KeyCode.R))
        {
            resetCarRotation();
        }
    }

    private void resetCarRotation()
    {
        Quaternion rotation = transform.rotation;
        rotation.z = 0f;
        rotation.x = 0f;
        transform.rotation = rotation;
    }

    public void SecondStartButton()
    {
        infopanel.SetActive(false);
        Time.timeScale= 1.0f;
        audioSource.Play();
    }
    public void ReplayButton()
    {
        SceneManager.LoadScene(1);
        infopanel.SetActive(false);
    }
}
