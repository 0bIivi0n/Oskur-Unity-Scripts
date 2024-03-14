using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.AI;

public class StopClownScript : MonoBehaviour
{

    [SerializeField]
    private NavMeshAgent navMeshAgent;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private GameObject PointofView;
    [SerializeField]
    private FollowPlayerScript followScript;
    [SerializeField]
    private FirstFloorPatrolScript patrolScript;

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("ClownStopper")) {
            PointofView.SetActive(false);
            navMeshAgent.isStopped = true;
            followScript.enabled = false;
            patrolScript.enabled = false;
            navMeshAgent.speed = 0.0f;
            anim.SetFloat("speed", 0.0f);
            StartCoroutine(GetBackToPatrol(10));
            StartCoroutine(ActivatePointOfView(13));
            StartCoroutine(TurnOff(15));
        }
    }

    IEnumerator GetBackToPatrol(int sec) {
        yield return new WaitForSeconds(sec);
        patrolScript.enabled = true;
        navMeshAgent.speed = 3.0f;
        anim.SetFloat("speed", 1.0f);
        navMeshAgent.isStopped = false;
    }

    IEnumerator ActivatePointOfView(int sec) {

        DetectPlayerScript[] allPovs = PointofView.GetComponentsInChildren<DetectPlayerScript>();

        yield return new WaitForSeconds(sec);

        foreach (DetectPlayerScript povScript in allPovs) {
            povScript.SetPlayerInRange(false);
            povScript.SetPlayerSpotted(false);
        }
        PointofView.SetActive(true);
    }

    IEnumerator TurnOff(int sec) {
        yield return new WaitForSeconds(sec);
        enabled = false;
    }
}
