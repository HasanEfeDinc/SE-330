using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildZombie : MonoBehaviour
{
    public GameObject damagePanel;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
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

