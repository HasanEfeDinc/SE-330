using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private bool buttonPressed = false;
    public AudioSource src;
    public AudioClip buttonClick;
    private Button startButton;
    
    void Start()
    {
        Button start = startButton.GetComponent<Button>();
        start.onClick.AddListener(PlayGame);
    }

    
    public void PlayGame()
        {
            //PlayButtonClickSound();
            buttonPressed = true;
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex+1;
            SceneManager.LoadScene(nextSceneIndex);
        }
    /*
        private void PlayButtonClickSound()
        {
            if (buttonClick != null)
            {
                src.clip = buttonClick;
                src.Play();
            }
            else
            {
                Debug.Log("AudioSource component is not assigned");
            }
        }*/
}
