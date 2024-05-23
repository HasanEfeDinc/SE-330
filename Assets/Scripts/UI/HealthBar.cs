using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillImage;
    public float health;

    public void getDamage(int value)
    {
        health -= value;
        fillImage.fillAmount = health / 100;

        if (health <= 0)
        {
            // dead
            return;
        }
    }

    public void heal(int value)
    {
        health += value;
        fillImage.fillAmount = health / 100;
        
        //maybe something like UI text appearing on the screen

        if (health == 100)
        {
            return;
        }
    }

    
}
