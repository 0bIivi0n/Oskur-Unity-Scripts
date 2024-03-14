using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoombaScript : MonoBehaviour
{

    [SerializeField]
    private float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
         InvokeRepeating("RotateRoomba", 0.0f, Random.Range(1.0f, 3.0f));
    }

    // Update is called once per frame
    void Update()
    {
       transform.Translate(Vector3.forward * speed * Time.deltaTime);

       if (transform.position.y < -15) {
        transform.position = new Vector3(-14.4649391f,-13.7808161f,42.3611107f);
       }
    }

    void RotateRoomba() {
        transform.Rotate(0.0f, Random.Range(-15.0f, 15.0f), 0.0f, Space.Self);
    }

    void OnCollisionEnter(Collision collider) {
        if(collider.gameObject.CompareTag("Obstacle")) {
            transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
        }
    }
}
