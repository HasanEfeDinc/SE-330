using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pharmacy : MonoBehaviour
{
    private HealthBar healthbar;
    
    private void Start()
    {
        healthbar = FindObjectOfType<HealthBar>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            healthbar.heal(2);
        }
    }
}
