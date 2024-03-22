using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoadsBatteryCharger : MonoBehaviour
{

    public CarController carController;
     
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

   private void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Player"))  
        {
            carController.battery += 0.010f; 
            carController.battery = Mathf.Clamp(carController.battery,  carController.minBattery, carController.maxBattery);
            carController.BatteryBreakeCharge.text = "++ ";
        }
    }
  
}
