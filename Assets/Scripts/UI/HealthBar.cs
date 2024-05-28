using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillImage;
    public float health;
    public GameObject damagePanel;
    public GameObject gameOverPanel;

    [SerializeField] private GameObject text;
    public void getDamage(int value)
    {
        health -= value;
        fillImage.fillAmount = health / 100;
        if (health <= 0)
        {
            // dead
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }

        if (health == 50)
        {
            OpenText();
        }
    }

    public void heal(int value)
    {
        health += value;
        fillImage.fillAmount = health / 100;
        
        if (health == 100)
        {
            return;
        }
    }

    private void OpenText()
    {
        text.SetActive(true);
        Invoke("CloseText", 1f);  
    }

    private void CloseText()
    {
        text.SetActive(false);
    }
    
}
