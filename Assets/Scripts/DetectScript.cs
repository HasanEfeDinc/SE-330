using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DetectScript : MonoBehaviour
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

    private void OnTriggerEnter(Collider other)
    {
        if (other == Human)
        {
            anim.SetBool("Walk",true);
            agent.SetDestination(Human.transform.position);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other == Human)
        {
            anim.SetBool("Walk",true);
            agent.SetDestination(Human.transform.position);
        }
    }

    private void Start()
    {
        gameObject.GetComponent<SphereCollider>().radius = 10;
    }
}
