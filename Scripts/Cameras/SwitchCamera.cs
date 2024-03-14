using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{

    private GameObject zoneCamera;

    // Start is called before the first frame update
    void Start()
    {
        zoneCamera = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            zoneCamera.tag = "MainCamera";
            zoneCamera.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            zoneCamera.tag = "Untagged";
            zoneCamera.SetActive(false);
        }
    }
}
