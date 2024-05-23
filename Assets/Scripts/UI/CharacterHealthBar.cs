using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealthBar : MonoBehaviour
{
    public int health = 100;
    public GameObject panel;
    [SerializeField] private GameObject Zombie;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void getDamage()
    {
        Image healthBarImage = panel.gameObject.GetComponent<Image>();
        float decreaseAmount = 0.5f;
        health -= 50;
        healthBarImage.fillAmount -= decreaseAmount;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other == Zombie)
        {
            getDamage();
        }
    }
}
