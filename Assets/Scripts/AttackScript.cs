using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackScript : MonoBehaviour
{
    [SerializeField] private Collider Human;
    [SerializeField] private Animator anim;
    [SerializeField] GameObject humanHealth;
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other == Human)
        {
            StartCoroutine(AttackCoroutine());
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other == Human)
        {
            StartCoroutine(AttackCoroutine());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        StopCoroutine(AttackCoroutine());
        anim.SetBool("Attack",false);
    }

    IEnumerator AttackCoroutine()
    {
        if (!anim.GetBool("Attack"))
        {
            anim.SetBool("Attack", true);
        }
        yield return new WaitUntil(() => anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 && !anim.IsInTransition(0));
    }
    
    
    
}
