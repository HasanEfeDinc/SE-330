using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildZombie : MonoBehaviour
{
    private HealthBar healthbar;
    public GameObject damagePanel;

    private void Start()
    {
        healthbar = FindObjectOfType<HealthBar>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            healthbar.getDamage(5);
            OpenDamagePanel();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CloseDamagePanel();
        }
    }

    private void OpenDamagePanel()
    {
        damagePanel.SetActive(true);
    }

    private void CloseDamagePanel()
    {
        damagePanel.SetActive(false);
    }
}

