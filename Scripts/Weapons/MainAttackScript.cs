using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAttackScript : MonoBehaviour
{
    private Animator cueAnim;

    // Start is called before the first frame update
    void Start()
    {
        cueAnim = GameObject.Find("Arms High").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) {
           cueAnim.SetBool("isAttacking", true);
           StartCoroutine(StopAttack());
        }
    }

    IEnumerator StopAttack() {
        yield return new WaitForSeconds(1);
        cueAnim.SetBool("isAttacking", false);
    }
}


