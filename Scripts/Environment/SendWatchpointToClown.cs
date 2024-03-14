using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendWatchpointToClown : MonoBehaviour
{
    private Transform watchpoint;

    // Start is called before the first frame update
    void Start()
    {
        watchpoint = GetComponentInChildren<Transform>();
    }

    public Transform GetWatchPoint() {
        return watchpoint;
    }
}
