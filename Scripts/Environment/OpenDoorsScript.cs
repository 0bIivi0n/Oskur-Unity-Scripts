using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OpenDoorsScript : MonoBehaviour
{

    private Animator openAnim;
    private bool isOpen = false;
    [SerializeField]
    private bool isPlayerInRange = false;
    // [SerializeField]
    // private bool isClownInRange = false;
    [SerializeField]
    private GameObject openText;
    [SerializeField]
    private GameObject closeText;
    [SerializeField]
    private BoxCollider blocker;

    void Start() {
        // if (transform.parent.name == "BackdoorTrigger") {
        //     openAnim = GetComponentInParent<Animator>();
        //     openText.SetActive(false);
        //     closeText.SetActive(false);
        // }

        openAnim = GetComponentInParent<Animator>();
        openText.SetActive(false);
        closeText.SetActive(false);
    }

    void OnTriggerEnter(Collider other) {
        
        if(other.CompareTag("Player")) {
            isPlayerInRange = true;
        }

        // if(other.CompareTag("Clown")) {          
        //     isClownInRange = true;
        // }
    }

    void OnTriggerExit(Collider other) {

        if(other.CompareTag("Player")) {
            isPlayerInRange = false;
        }

        // if(other.CompareTag("Clown")) {
        //     isClownInRange = false;
        // }
    }

    void Update() {

        if(isPlayerInRange && !isOpen) {

            openText.SetActive(true);

            if (Input.GetButtonDown("Activate")) {
                // if(transform.name == "ElevatorTrigger") {
                //     Debug.Log("You unlocked the elevator");
                // } else {
                //     openAnim.SetBool("openTrigger", true);
                //     openAnim.SetBool("closeTrigger", false);
                //     StartCoroutine(WaitDoorOpening());
                //     blocker.enabled = false;
                // }

                openAnim.SetBool("openTrigger", true);
                openAnim.SetBool("closeTrigger", false);
                StartCoroutine(WaitDoorOpening());
                blocker.enabled = false;
            }   
        } else {
            openText.SetActive(false);
        }

        if(isPlayerInRange && isOpen) {

            closeText.SetActive(true);

            if (Input.GetButtonDown("Activate")) {
                openAnim.SetBool("closeTrigger", true);
                openAnim.SetBool("openTrigger", false);
                StartCoroutine(WaitDoorClosing());
                blocker.enabled = true;
            }
        } else {
            closeText.SetActive(false);
        }

        // if(isClownInRange && !isOpen) {
        //     openAnim.SetBool("openTrigger", true);
        //     openAnim.SetBool("closeTrigger", false);
        //     StartCoroutine(WaitDoorOpening());
        //     blocker.enabled = false;
        // }
    }

    IEnumerator WaitDoorOpening() {
        yield return new WaitForSeconds(1);
        isOpen = true;
    }

    IEnumerator WaitDoorClosing() {
        yield return new WaitForSeconds(1);
        isOpen = false;
    }
}
