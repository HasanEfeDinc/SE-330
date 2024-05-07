using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ZombieScript : MonoBehaviour
{
    public int health = 100;
    public GameObject panel;
    [SerializeField] private Collider Detect, Leave, Human;
    [SerializeField] private Animator anim;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject Character;
    private Vector3 position;
    
    void Update()
    {
        position = Character.transform.position;
    }

    public void DecreaseHealthBar()
    {
        Image healthBarImage = panel.gameObject.GetComponent<Image>();
        float decreaseAmount = 0.5f;
        health -= 50;
        healthBarImage.fillAmount -= decreaseAmount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == Human)
        {
            anim.Play("Walk Animation");
            agent.SetDestination(position);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other == Human)
        {
            anim.Play("Walk Animation");
            agent.SetDestination(position);
        }
    }
}
