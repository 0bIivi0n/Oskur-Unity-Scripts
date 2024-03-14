using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoulderPlayerController : MonoBehaviour
{
    [SerializeField]
    private float horizontalAxis;
    [SerializeField]
    private float verticalAxis;
    private float horizontalRot;
    private Rigidbody rb;
    [SerializeField]
    private float speed = 10.0f;
    [SerializeField]
    private float rotSpeed = 120.0f;
    [SerializeField]
    private float mouseRotSpeed = 180.0f;
    private float mouseRotX;
    private float jumpForce = 5.0f;
    [SerializeField]
    private bool isGrounded = true;
    private Animator cueAnim;
    [SerializeField]
    private bool isRunning = false;
    
    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody>();
      //cueAnim = GameObject.Find("Arms High").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");
        horizontalRot = Input.GetAxis("Horizontal_R");
        mouseRotX = Input.GetAxis("Mouse X");

       // Make weapon move while walking
        // if(horizontalAxis != 0 || verticalAxis != 0) {
        //     cueAnim.SetFloat("speed", 1.0f);
        // } else {
        //     cueAnim.SetFloat("speed", 0.0f);
        // }

        if (horizontalAxis == 1 && verticalAxis == 1) {
            speed = 5.0f;
        }

        // FPS & Shoulder controls 
        transform.Translate(Vector3.forward * verticalAxis * speed * Time.deltaTime);
        transform.Translate(Vector3.right * horizontalAxis * speed * Time.deltaTime);
        transform.Rotate(Vector3.up.normalized * horizontalRot * rotSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up.normalized * mouseRotX * mouseRotSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        }

        if (Input.GetButtonDown("Run") && !isRunning) {
            speed = 14;
            isRunning = true;
            StartCoroutine(ResetSpeed());
            StartCoroutine(ResetSprint());
        }
    }

    IEnumerator ResetSpeed() {
        yield return new WaitForSeconds(3);
        speed = 7;
    }

    IEnumerator ResetSprint() {
        yield return new WaitForSeconds(5);
        isRunning = false;
    }

    void OnTriggerStay(Collider other) {
        if (other.CompareTag("Floor")) {
            isGrounded = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Floor")) {
            isGrounded = false;
        }
    }
}
