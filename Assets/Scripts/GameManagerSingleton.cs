using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerSingleton : MonoBehaviour
{
    public static GameManagerSingleton instance { get; private set; }

    //Game Values
    public float musicVol;
    public float sfxVol;

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

    public void CompleteLevel(int level)
    {
        if(levelAccess < level)
            levelAccess = level;
    }
}
