using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    private float fireRate = 0.7f;  
    private float nextFireTime = 0f;
    private float range = 5000;
    private int ammo = 15;
    private bool reloading = false;
    [SerializeField] private ParticleSystem FireEffect;
    [SerializeField] private AudioSource firesound, emptysound, shelldropsound, reloadsound;
    [SerializeField] private TextMeshProUGUI remainingAmmo;


    private void Start()
    {
        remainingAmmo.text = "15 / " + (ammo.ToString());
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime && !reloading)
        {
            Fire();
            remainingAmmo.text = "15 / " + (ammo.ToString());
            nextFireTime = Time.time + fireRate;  
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (ammo != 15)
            {
                StartCoroutine(Reload());
            }
        }
    }
    IEnumerator Reload()
    {
        reloading = true; 
        reloadsound.Play();
        yield return new WaitForSeconds(reloadsound.clip.length); 
        ammo = 15;
        remainingAmmo.text = "15 / " + ammo.ToString();
        reloading = false;
    }

    void Fire()
    {
        if (ammo == 0)
        {
            emptysound.Play();
        }
        if (ammo >0)
        {
            ammo -= 1;
            FireEffect.Play();
            firesound.Play();
            shelldropsound.PlayDelayed(0.1f);
            RaycastHit raycastHit = new RaycastHit();
            if (Physics.Raycast(transform.position, transform.forward, out raycastHit, range))
            {
                if (raycastHit.transform.gameObject.CompareTag("Zombie")) 
                {
                    raycastHit.transform.gameObject.GetComponent<ZombieScript>().DecreaseHealthBar();
                    if (raycastHit.transform.gameObject.GetComponent<ZombieScript>().health == 0)
                    {
                        raycastHit.transform.gameObject.GetComponent<Animator>().SetBool("Die",true);
                        raycastHit.transform.gameObject.GetComponent<NavMeshAgent>().enabled = false;

                    }
                }
            }
        }
    }
}
