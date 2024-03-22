using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryThrillerSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip batteryClip;
    public CarController carController;
    
    void Update()
    {
        
        if (carController.battery < 35 && !audioSource.isPlaying)
        {
            
            audioSource.clip = batteryClip;
            audioSource.Play();
        }
        
    }
}


