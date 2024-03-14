using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class FollowPlayerScript : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    [SerializeField]
    private float speed = 1.0f;
    [SerializeField]
    private Animator clownAnimator;
    private Transform player;
    [SerializeField]
    private float distance;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>(); 
    }

    // Update is called once per frame
    void Update()
    {

        distance = Vector3.Distance(transform.position, player.position);
      
        navMeshAgent.SetDestination(player.position);
        
        
        if(distance <= 10.0f && distance > 3.0f) {
            speed = 3.0f;
            navMeshAgent.speed = 3.0f;
            clownAnimator.SetFloat("speed", 1.0f);
        } else if(distance >= 4.0f) {
            speed = 6.0f;
            navMeshAgent.speed = 6.0f;
            clownAnimator.SetFloat("speed", 2.0f);
        } else {
            speed = 0.0f;
            navMeshAgent.speed = 0.0f;
            clownAnimator.SetFloat("speed", 0.0f);
        }
    }
}
