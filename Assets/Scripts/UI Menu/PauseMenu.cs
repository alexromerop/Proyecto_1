using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject finalLevelUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void LoadMenu()
    {
        string mainMenu = "MainMenu";
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenu);
        gameIsPaused = false;
    }

    public void GoToNextLevel(string scene)
    {
        SceneManager.LoadScene(scene);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void LevelFinished()
    {
        finalLevelUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
