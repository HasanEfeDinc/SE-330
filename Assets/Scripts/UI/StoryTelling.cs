using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryTelling : MonoBehaviour
{
    [SerializeField] private GameObject talk1;
    [SerializeField] private GameObject talk2;
    [SerializeField] private float talk1Duration = 2f;
    [SerializeField] private float talk2Duration = 2f; 
    [SerializeField] private MonoBehaviour characterMovementScript; 
    [SerializeField] private GameObject crosshair;
    [SerializeField] private GameObject ammo;
    [SerializeField] private GameObject MiniMap;
    

    public GameObject storyPanel;

    void Start()
    {
        StartCoroutine(ShowStorySequence());
    }

    private IEnumerator ShowStorySequence()
    {
        if (characterMovementScript != null)
        {
            characterMovementScript.enabled = false;
            ammo.SetActive(false);
            MiniMap.SetActive(false);
        }

        ActivateText1();
        yield return new WaitForSeconds(talk1Duration);

        ActivateText2();
        yield return new WaitForSeconds(talk2Duration);

        CloseStoryPanel();

        if (characterMovementScript != null)
        {
            characterMovementScript.enabled = true;
            crosshair.SetActive(true);
            ammo.SetActive(true);
            MiniMap.SetActive(true);
        }
    }

    public void ActivateText1()
    {
        talk1.SetActive(true);
    }

    public void ActivateText2()
    {
        talk1.SetActive(false);
        talk2.SetActive(true);
    }

    public void CloseStoryPanel()
    {
        storyPanel.SetActive(false);
    }
}