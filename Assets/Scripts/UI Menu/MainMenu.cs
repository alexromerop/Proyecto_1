using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene("Map_test", LoadSceneMode.Single);
        Debug.Log("PLAY!");
    }

    public void GoToCilckedButton(GameObject label)
    {
        menu.SetActive(false);
        label.SetActive(true);
    }


    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void Back(GameObject label)
    {
        label.SetActive(false);
        menu.SetActive(true);
    }
}
