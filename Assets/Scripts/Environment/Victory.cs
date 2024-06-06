using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    [SerializeField] private GameObject talk3;
    [SerializeField] private GameObject talk4;
    [SerializeField] private float talk1Duration = 2f;
    [SerializeField] private float talk2Duration = 2f;
    [SerializeField] private MonoBehaviour characterMovementScript;
    [SerializeField] private GameObject ammo;
    [SerializeField] private GameObject crosshair;
    [SerializeField] private GameObject motherImage;
    [SerializeField] private GameObject characterImage;

    public GameObject storyPanel;
    public GameObject victoryStoryPanel;
    public GameObject victoryPanel;

    public Animator mother_animator;
    public Animator kid_animator;

    void Start()
    {
        mother_animator = GetComponent<Animator>();
        if (mother_animator != null)
        {
            mother_animator.Play("idle_m_2_220f");
        }

        kid_animator = GetComponent<Animator>();
        if (kid_animator != null)
        {
            kid_animator.Play("idle_m_1_200f");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ShowStorySequence());
        }
    }

    private IEnumerator ShowStorySequence()
    {
        victoryStoryPanel.SetActive(true);
        crosshair.SetActive(false);
        if (characterMovementScript != null)
        {
            characterMovementScript.enabled = false;
            ammo.SetActive(false);
        }

        ActivateText1();
        yield return new WaitForSeconds(talk1Duration);

        ActivateText2();
        ActivateMotherImage();
        yield return new WaitForSeconds(talk2Duration);

        CloseStoryPanel();

        if (characterMovementScript != null)
        {
            characterMovementScript.enabled = true;
            ammo.SetActive(true);
            crosshair.SetActive(true);
        }
    }

    public void ActivateText1()
    {
        talk3.SetActive(true);
    }

    public void ActivateText2()
    {
        talk3.SetActive(false);
        talk4.SetActive(true);
    }

    public void ActivateMotherImage()
    {
        characterImage.SetActive(false);
        motherImage.SetActive(true);
        talk4.SetActive(true);
    }

    public void CloseStoryPanel()
    {
        victoryStoryPanel.SetActive(false);
        victoryPanel.SetActive(true);
        crosshair.SetActive(false);
        characterMovementScript.enabled = false;

    }
}