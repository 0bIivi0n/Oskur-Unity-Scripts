using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoors : MonoBehaviour
{
    private playerKeyItems playerKeys;
    private bool isLocked = true;
    [SerializeField]
    private GameObject trigger;
    private BoxCollider boxColl;
    [SerializeField]
    private GameObject unlockText;
    [SerializeField]
    private GameObject needKeyText;
    private bool isPlayerInRange = false;

    // Start is called before the first frame update
    void Start()
    {
        playerKeys = GameObject.Find("Player").GetComponent<playerKeyItems>();
        boxColl = trigger.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerInRange) {
            unlockText.SetActive(true);
            // Check Square Door Key and unlock
            if (trigger.name == "SquareTrigger") {
                if(playerKeys.GetSquareKey()) {
                    if(Input.GetButtonDown("Activate")){
                        boxColl.enabled = true;
                        unlockText.SetActive(false);
                        Destroy(gameObject);
                    }
                } else {
                    if(Input.GetButtonDown("Activate")) {
                        StartCoroutine("DisplayNeedKeyText");
                    }
                } 
            }
            // Check Restaurant door key and unlock
            if (trigger.name == "RestaurantTrigger") {
                if(playerKeys.GetRestaurantKey()) {
                    if(Input.GetButtonDown("Activate")){
                        boxColl.enabled = true;
                        unlockText.SetActive(false);
                        Destroy(gameObject);
                    }
                } else {
                    if(Input.GetButtonDown("Activate")) {
                        StartCoroutine("DisplayNeedKeyText");
                    }
                } 
            }
            // Check Meeting Room door key and unlock
            if (trigger.name == "MeetingRoomTrigger") {
                if(playerKeys.GetMeetingRoomKey()) {
                    if(Input.GetButtonDown("Activate")){
                        boxColl.enabled = true;
                        unlockText.SetActive(false);
                        Destroy(gameObject);
                    }
                } else {
                    if(Input.GetButtonDown("Activate")) {
                        StartCoroutine("DisplayNeedKeyText");
                    }
                } 
            }
            // Check Center Back Office door key and unlock
            if (trigger.name == "CenterBackOffTrigger") {
                if(playerKeys.GetSquareKey()) {
                    if(Input.GetButtonDown("Activate")){
                        boxColl.enabled = true;
                        unlockText.SetActive(false);
                        Destroy(gameObject);
                    }
                } else {
                    if(Input.GetButtonDown("Activate")) {
                        StartCoroutine("DisplayNeedKeyText");
                    }
                } 
            }
            // Check Left Back Office door key and unlock
            if (trigger.name == "LeftBackOffTrigger") {
                if(playerKeys.GetSquareKey()) {
                    if(Input.GetButtonDown("Activate")){
                        boxColl.enabled = true;
                        unlockText.SetActive(false);
                        Destroy(gameObject);
                    }
                } else {
                    if(Input.GetButtonDown("Activate")) {
                        StartCoroutine("DisplayNeedKeyText");
                    }
                } 
            }
            // Check Left Back Office door key and unlock
            if (trigger.name == "LeftSecondOffTrigger") {
                if(playerKeys.GetSquareKey()) {
                    if(Input.GetButtonDown("Activate")){
                        boxColl.enabled = true;
                        unlockText.SetActive(false);
                        Destroy(gameObject);
                    }
                } else {
                    if(Input.GetButtonDown("Activate")) {
                        StartCoroutine("DisplayNeedKeyText");
                    }
                } 
            }
            // Check Left Back Office door key and unlock
            if (trigger.name == "LeftFirstOffTrigger") {
                if(playerKeys.GetSquareKey()) {
                    if(Input.GetButtonDown("Activate")){
                        boxColl.enabled = true;
                        unlockText.SetActive(false);
                        Destroy(gameObject);
                    }
                } else {
                    if(Input.GetButtonDown("Activate")) {
                        StartCoroutine("DisplayNeedKeyText");
                    }
                } 
            }
            // Check Left Back Office door key and unlock
            if (trigger.name == "BackOfficeTrigger") {
                if(playerKeys.GetBackOfficeKey()) {
                    if(Input.GetButtonDown("Activate")){
                        boxColl.enabled = true;
                        unlockText.SetActive(false);
                        Destroy(gameObject);
                    }
                } else {
                    if(Input.GetButtonDown("Activate")) {
                        StartCoroutine("DisplayNeedKeyText");
                    }
                } 
            }
            // Check elevator key and unlock **End of first level**
            if (trigger.name == "ElevatorTrigger") {
                if(playerKeys.GetBackdoorKey()) {
                    if(Input.GetButtonDown("Activate")){
                        boxColl.enabled = true;
                        unlockText.SetActive(false);
                        Destroy(gameObject);
                    }
                } else {
                    if(Input.GetButtonDown("Activate")) {
                        StartCoroutine("DisplayNeedKeyText");
                    }
                } 
            }
        } else {
            unlockText.SetActive(false);
        }
    }

    IEnumerator DisplayNeedKeyText() {
        needKeyText.SetActive(true);
        yield return new WaitForSeconds(2);
        needKeyText.SetActive(false);
    }

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player")) {
            isPlayerInRange = false;
        }
    }
}
