using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class StreetLights : MonoBehaviour
{
    public Light parentLight;
    public DayNightCycle dayNightCycle;
    void Start()
    {
       parentLight.GetComponent<Light>();
    }

   
    void Update()
    {
        float timeOfDay = dayNightCycle.timeOfDay;
        if (timeOfDay >0f)
            parentLight.intensity = 1.1f;
        
        if (timeOfDay >5.5f)
            parentLight.intensity = 0.0f;


        if (timeOfDay >17.0f)
            parentLight.intensity = 1.1f;

        


    }
}

