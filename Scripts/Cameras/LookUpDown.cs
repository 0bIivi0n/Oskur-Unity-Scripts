using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookUpDown : MonoBehaviour
{
    private float mouseRotY;
    private float verticalRot;
    [SerializeField]
    private float mouseSpeed;
    private float joystickSpeed;
    // private float maxLookup = 15.0f;
    // private float maxLookDown = 15.0f;
  
    // Start is called before the first frame update
    void Start()
    {
        mouseSpeed = 120.0f;
        joystickSpeed = 75.0f;
    }

    // Update is called once per frame
    void Update()
    {
        mouseRotY = Input.GetAxis("Mouse Y");
        verticalRot = Input.GetAxis("Vertical_R");

        
        transform.Rotate(Vector3.right.normalized * verticalRot * joystickSpeed * Time.deltaTime);
        transform.Rotate(Vector3.right.normalized * mouseRotY * mouseSpeed * Time.deltaTime);

        
    }
}
