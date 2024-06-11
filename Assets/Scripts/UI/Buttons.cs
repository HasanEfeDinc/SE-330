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
    public Button continueButton;

    public GameObject gameOverPanel;
    public GameObject pausePanel;
    
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Button btn1 = homeButton.GetComponent<Button>();
        Button btn2 = restartButton.GetComponent<Button>();
        Button btn3 = pauseButton.GetComponent<Button>();
        Button btn4 = continueButton.GetComponent<Button>();
        
        btn1.onClick.AddListener(GoToMenu);
        btn2.onClick.AddListener(RestartGame);
        btn3.onClick.AddListener(PauseGame);
        btn4.onClick.AddListener(ContinueGame);
    }

    public void GoToMenu()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void RestartGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        gameOverPanel.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(currentSceneIndex);
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        Controller controller = GetComponent<Controller>();
        pausePanel.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }

    public void ContinueGame()
    {
        pausePanel.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }
    
    
}
