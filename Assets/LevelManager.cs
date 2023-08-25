using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int menuLevel = 0;
    public int tutorialStart = 1;
    public int levelStart = 2;
    public int winLevel = 3;
    public int loseLevel = 4;
    
    public void StartGame()
    {
        SceneManager.LoadScene(tutorialStart);
    }

    public void BeginGame()
    {
        SceneManager.LoadScene(levelStart);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(menuLevel);
    }

    public void LoadWin()
    {
        SceneManager.LoadScene(winLevel);
    }

    public void LoadLose()
    {
        SceneManager.LoadScene(loseLevel);
    }
}
