using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject menu;
    public AudioManager audioManager;

    public void ChangeScene(string scene)
    {
        audioManager.PlayClicked();
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        Debug.Log("Choose Level!");
    }

    public void GoToCilckedButton(GameObject label)
    {
        audioManager.PlayClicked();
        menu.SetActive(false);
        label.SetActive(true);
    }


    public void QuitGame()
    {
        audioManager.PlayClicked();
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void Back(GameObject label)
    {
        audioManager.PlayClicked();
        label.SetActive(false);
        menu.SetActive(true);
    }
}
