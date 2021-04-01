using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    // Start is called before the first frame update
    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        Debug.Log("Choose Level!");
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
