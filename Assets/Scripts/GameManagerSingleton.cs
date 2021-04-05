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
    }
    public void CompleteLevel(int level)
    {
        if(levelAccess == level)
        {
            levelAccess = level + 1;
        } 
    }

}
