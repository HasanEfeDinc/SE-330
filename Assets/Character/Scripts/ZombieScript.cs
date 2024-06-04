using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ZombieScript : MonoBehaviour
{
    public int health = 100;
    public GameObject panel;
    public GameObject healthBar;
    public GameObject damagePanel;
    
    public void DecreaseHealthBar()
    {
        Image healthBarImage = panel.gameObject.GetComponent<Image>();
        float decreaseAmount = 0.5f;
        health -= 50;
        healthBarImage.fillAmount -= decreaseAmount;
    }

    public void decreaseHealth()
    {
        healthBar.GetComponent<HealthBar>().getDamage(5);
        StartCoroutine(setPanel());
    }

    public void destryobject()
    {
        Destroy(gameObject);
    }

    public void enableagent()
    {
        gameObject.GetComponent<NavMeshAgent>().enabled = true;
    }
    
    public void disableagent()
    {
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
    }

    IEnumerator setPanel()
    {
        damagePanel.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        damagePanel.SetActive(false);
    }
    
    
}
