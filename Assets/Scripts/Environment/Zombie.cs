using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Zombie : MonoBehaviour
{
    public int health = 100;
    public GameObject panel;
    [SerializeField] private Collider Detect, Leave, Human;
    [SerializeField] private Animator anim;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject Character;
    private Vector3 position;

    private HealthBar healthBar;

    private void Start()
    {
        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
            if (agent == null)
            {
                Debug.LogError("NavMeshAgent component not found on " + gameObject.name);
            }
        }

        if (Character == null)
        {
            Debug.LogError("Character GameObject is not assigned.");
        }
        
        healthBar = FindObjectOfType<HealthBar>();
        if (healthBar == null)
        {
            Debug.LogError("HealthBar script not found in the scene.");
        }
    }

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
/*
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            healthBar.getDamage(10); 
        }
    }
*/
    private void OnTriggerStay(Collider other)
    {
        if (other == Human)
        {
            anim.Play("Walk Animation");
            agent.SetDestination(position);
        }
    }
}
