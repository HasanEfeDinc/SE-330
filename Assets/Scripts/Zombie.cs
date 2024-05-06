using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();

        if (character != null)
        {
            character.currentHealth--;
            if (character.currentHealth <= 0)
            {
                Debug.Log("you are dead");
            }
        }
    }
}
