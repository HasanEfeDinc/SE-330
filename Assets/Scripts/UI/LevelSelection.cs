using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public Button[] levelButtons;
    

    void Start()
    {
        int maxAccessibleLevel = PlayerPrefs.GetInt("levelAt", 2);
        ResetPlayerProgress();
        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = (i + 2 <= maxAccessibleLevel);
            int levelIndex = i + 2; 
            levelButtons[i].onClick.AddListener(() => GoToThatLevel(levelIndex));
        }
        
        
    }

    private void GoToThatLevel(int levelIndex)
    {
        int sceneIndex = levelIndex; 

        if (sceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
    
    public void ResetPlayerProgress()
    {
        PlayerPrefs.SetInt("levelAt", 2);
        PlayerPrefs.Save();
    }

   
    

    
}