using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindTurbineRotater : MonoBehaviour
{
    public GameObject windTurbine1;
    public GameObject windTurbine2;
    public GameObject windTurbine3;
    public GameObject windTurbine4;
    public GameObject windTurbine5;
    public GameObject windTurbine6;
    public GameObject windTurbine7;
    public GameObject windTurbine8;
    public GameObject windTurbine9;
    public GameObject windTurbine10;

    public GameObject windTurbine11;
    public GameObject windTurbine12;
    public GameObject windTurbine13;
    public GameObject windTurbine14;
    public GameObject windTurbine15;
    public GameObject windTurbine16;
    public GameObject windTurbine17;
    public GameObject windTurbine18;
    public GameObject windTurbine19;
    public GameObject windTurbine20;



    void Start()
    {
        
    }

    
    void Update()
    {
        TurnTurbines();


       
    }

    void TurnTurbines()
    {
        windTurbine1.transform.Rotate(Vector3.back, 70f * Time.deltaTime);
        windTurbine2.transform.Rotate(Vector3.back, 70f * Time.deltaTime);
        windTurbine3.transform.Rotate(Vector3.back, 70f * Time.deltaTime);
        windTurbine4.transform.Rotate(Vector3.back, 70f * Time.deltaTime);
        windTurbine5.transform.Rotate(Vector3.back, 70f * Time.deltaTime);
        windTurbine6.transform.Rotate(Vector3.back, 70f * Time.deltaTime);
        windTurbine7.transform.Rotate(Vector3.back, 70f * Time.deltaTime);
        windTurbine8.transform.Rotate(Vector3.back, 70f * Time.deltaTime);
        windTurbine9.transform.Rotate(Vector3.back, 70f * Time.deltaTime);
        windTurbine10.transform.Rotate(Vector3.back, 70f * Time.deltaTime);
        windTurbine11.transform.Rotate(Vector3.back, 70f * Time.deltaTime);
        windTurbine12.transform.Rotate(Vector3.back, 70f * Time.deltaTime);
        windTurbine13.transform.Rotate(Vector3.back, 70f * Time.deltaTime);
        windTurbine14.transform.Rotate(Vector3.back, 70f * Time.deltaTime);
        windTurbine15.transform.Rotate(Vector3.back, 70f * Time.deltaTime);
        windTurbine16.transform.Rotate(Vector3.back, 70f * Time.deltaTime);
        windTurbine17.transform.Rotate(Vector3.back, 70f * Time.deltaTime);
        windTurbine18.transform.Rotate(Vector3.back, 70f * Time.deltaTime);
        windTurbine19.transform.Rotate(Vector3.back, 70f * Time.deltaTime);
        windTurbine20.transform.Rotate(Vector3.back, 70f * Time.deltaTime);

    }
}
