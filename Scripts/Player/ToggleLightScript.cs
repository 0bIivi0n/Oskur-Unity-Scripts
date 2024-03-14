using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLightScript : MonoBehaviour
{

    private Light flashlight;

    // Start is called before the first frame update
    void Start()
    {
        flashlight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Flashlight") && !flashlight.enabled) {

            flashlight.enabled = true;

        } else if(Input.GetButtonDown("Flashlight") && flashlight.enabled) {

            flashlight.enabled = false;
            
        }
    }
}
