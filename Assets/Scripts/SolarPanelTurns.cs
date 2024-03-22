using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarPanelTurns : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.down, 20 * Time.deltaTime);
    }
}
