using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LeaveScript : MonoBehaviour
{
    [SerializeField] private Collider Human;
    [SerializeField] private Animator anim;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject Character;
    private Vector3 position;
    
    void Update()
    {
        position = Character.transform.position;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == Human)
        {
            anim.SetBool("Walk",false);
            agent.SetDestination(gameObject.GetComponentInParent<Transform>().position);
        }
    }
}
