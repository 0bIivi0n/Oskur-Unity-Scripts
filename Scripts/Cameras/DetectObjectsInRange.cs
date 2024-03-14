using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DetectObjectsInRange : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI objectName;
    [SerializeField]
    private TextMeshProUGUI takeTxt;

    // Update is called once per frame
    void Update()
    {
       Ray ray = new Ray(transform.position, transform.forward);
       RaycastHit hit;

       if (Physics.Raycast(ray, out hit, 3.0f)) {
            if (hit.transform.CompareTag("Key")) {
                objectName.text = hit.transform.name;
                objectName.enabled = true;
                takeTxt.enabled = true;
                Debug.Log(hit.transform.name);

                if(Input.GetButtonDown("Activate")) {
                    PickUpKey(hit.transform.name);
                    Destroy(hit.transform.gameObject);
                }

            } else {
                objectName.enabled = false;
                takeTxt.enabled = false;
            }
        }
    }

    private void PickUpKey(string key) {
        if(key == "Square key") {
            gameObject.GetComponentInParent<playerKeyItems>().SetSquareKey(true);
        }

        if(key == "Restaurant key") {
            gameObject.GetComponentInParent<playerKeyItems>().SetRestaurantKey(true);
        }

        if(key == "Backoffice key") {
            gameObject.GetComponentInParent<playerKeyItems>().SetBackOfficeKey(true);
        }

        if(key == "Meeting room key") {
            gameObject.GetComponentInParent<playerKeyItems>().SetMeetingRoomKey(true);
        }

        if(key == "Elevator key") {
            gameObject.GetComponentInParent<playerKeyItems>().SetBackdoorKey(true);
        }
    }
}



