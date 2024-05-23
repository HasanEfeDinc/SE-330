using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildZombie : MonoBehaviour
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
            healthbar.getDamage(5);
        }
    }
}
