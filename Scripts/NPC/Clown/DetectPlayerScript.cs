using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class DetectPlayerScript : MonoBehaviour
{

    public Transform player;
    public NavMeshAgent navMeshAgent;
    [SerializeField]
    bool m_IsPlayerInRange;
    [SerializeField]
    bool playerSpotted;
    GameObject clownGameObject;
    FirstFloorPatrolScript patrolScript;
    FollowPlayerScript followScript;

    void Start() {

        clownGameObject = GameObject.Find("KillerClown");
        patrolScript = clownGameObject.GetComponent<FirstFloorPatrolScript>();
        followScript = clownGameObject.GetComponent<FollowPlayerScript>();
    }

    void OnTriggerEnter(Collider other) {

        if(other.transform == player) {
            m_IsPlayerInRange = true;
        }
        
    }

    void OnTriggerStay(Collider other) {

        if(other.transform == player) {
            m_IsPlayerInRange = true;
        }

    }

    void OnTriggerExit(Collider other) {
        
        if(other.transform == player) {
            m_IsPlayerInRange = false;
            StartCoroutine(GetBackToPatrol());
        }
    }

    void Update() {

        if(m_IsPlayerInRange) {

            Vector3 playerDirection = player.position - transform.position;

            Ray ray = new Ray(transform.position, playerDirection);
            RaycastHit raycastHit;

            // Check if clown has a direct line of sight to player
            if(Physics.Raycast(ray, out raycastHit, math.INFINITY)) {

                if(raycastHit.transform == player) {
                    playerSpotted = true;
                    Debug.Log("Player detected !");
                    StopCoroutine(GetBackToPatrol());
                    navMeshAgent.isStopped = true;
                    patrolScript.enabled = false;
                    followScript.enabled = true;
                    navMeshAgent.isStopped = false;
                }
            }

            // Check if clown has a line of sight to player through glass
            RaycastHit[] hits;
            hits = Physics.RaycastAll(transform.position, playerDirection, math.INFINITY);
            
            for (int i = 0; i < hits.Length; i++) {
                
                if(!hits[i].transform.name.Contains("floor") && !hits[i].transform.name.Contains("Floor")) { 

                    Debug.Log(hits[i].transform.name);

                    if(hits.Length > 1 && hits[i].transform == player && hits[i-1].transform.name.Contains("Glass")) {
                        playerSpotted = true;
                        Debug.Log("Player detected !");
                        StopCoroutine(GetBackToPatrol());
                        navMeshAgent.isStopped = true;
                        patrolScript.enabled = false;
                        followScript.enabled = true;
                        navMeshAgent.isStopped = false;
                    }      
                }
            }
        }
    }

    IEnumerator GetBackToPatrol() {
        // Switch back to patrol after 30 seconds
        yield return new WaitForSeconds(30);

        playerSpotted = false;
        navMeshAgent.isStopped = true;
        followScript.enabled = false;
        patrolScript.enabled = true; 
        navMeshAgent.isStopped = false; 
    }

    public void SetPlayerSpotted(bool status) {
        playerSpotted = status;
    }

    public void SetPlayerInRange(bool status) {
        m_IsPlayerInRange = status;
    }
}
