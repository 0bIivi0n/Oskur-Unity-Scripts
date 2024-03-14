using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayerController : MonoBehaviour
{
    [SerializeField]
    private float horizontalAxis;
    [SerializeField]
    private float verticalAxis;
    private float horizontalRot;

    private GameObject mainCam;
    [SerializeField]
    private float speed = 5.0f;
   
 
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.Find("StartCam");
    }

    // Update is called once per frame
    void Update()
    {   
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");
        horizontalRot = Input.GetAxis("Horizontal_R");

       if(verticalAxis != 0 || horizontalAxis != 0)
       {

            /* Controls based on Cameras */

            // Move Up
            if(verticalAxis > 0)
            {
                transform.eulerAngles = new Vector3(0, mainCam.transform.eulerAngles.y + (90 * horizontalAxis), 0);  
            }
            // Move Down
            if(verticalAxis < 0)
            {
                transform.eulerAngles = new Vector3(0, (mainCam.transform.eulerAngles.y + 180) - (90 * horizontalAxis), 0);  
            }

            transform.Translate(Vector3.forward * speed * Time.deltaTime);
       }
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Zone"))
        {
            mainCam = other.transform.GetChild(0).gameObject;
        }
    }
}
