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
    }

    public void destryobject()
    {
        Destroy(gameObject);
    }
    
    
}
