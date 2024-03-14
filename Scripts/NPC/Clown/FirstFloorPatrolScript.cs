using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FirstFloorPatrolScript : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    [SerializeField]
    private Animator clownAnimator;
    [SerializeField]
    int m_currentWayPointIndex;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        clownAnimator.SetFloat("speed", 1.0f);
        navMeshAgent.SetDestination(waypoints[m_currentWayPointIndex].position);

        if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            clownAnimator.SetFloat("speed", 0.0f);
            m_currentWayPointIndex = (m_currentWayPointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[m_currentWayPointIndex].position);
            clownAnimator.SetFloat("speed", 1.0f);
            navMeshAgent.speed = 3.0f;
        }
    }
}
