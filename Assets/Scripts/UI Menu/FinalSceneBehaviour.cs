using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalSceneBehaviour : MonoBehaviour
{
    public GameObject finalLevelUI;
    public AudioManager audioManager;

    private void Update()
    {
        StartCoroutine(ShowLastMenu());
    }
    public void FinishGame()
    {
        finalLevelUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LoadMenu()
    {
        string mainMenu = "MainMenu";
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenu);
    }
    public void QuitGame()
    {
        audioManager.PlayClicked();
        Debug.Log("QUIT!");
        Application.Quit();
    }
   
    IEnumerator ShowLastMenu()
    {
        yield return new WaitForSeconds(10.0f);
        finalLevelUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
