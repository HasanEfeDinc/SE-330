using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Buttons : MonoBehaviour
{
    public Button homeButton;
    public Button restartButton;
    public Button pauseButton;

    public GameObject gameOverPanel;
    public GameObject pausePanel;
    
    void Start()
    {
        Button btn1 = homeButton.GetComponent<Button>();
        Button btn2 = restartButton.GetComponent<Button>();
        Button btn3 = pauseButton.GetComponent<Button>();
        
        btn1.onClick.AddListener(GoToMenu);
        btn2.onClick.AddListener(RestartGame);
        btn3.onClick.AddListener(PauseGame);
    }

    public void GoToMenu()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void RestartGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene(currentSceneIndex);
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        Controller controller = GetComponent<Controller>();
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }
    
    
}
