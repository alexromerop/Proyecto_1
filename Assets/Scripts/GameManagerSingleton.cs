using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManagerSingleton : MonoBehaviour
{
    public static GameManagerSingleton instance { get; set; }

    //Game Values
    public float musicVol;
    public float sfxVol;
    public int scene;

    //Level Selector
    public int levelAccess;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    private void Update()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9) && scene > 1 && scene < 5)
        {
            GameObject goal = GameObject.FindGameObjectWithTag("Goal");
            if (goal != null)
            {
                goal.GetComponent<FinalLevel>().LevelComplete();
            }
        }
    }
    public void CompleteLevel(int level)
    {
        if(levelAccess == level)
        {
            levelAccess = level + 1;
        } 
    }

}
