using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameManagerSingleton : MonoBehaviour
{
    public static GameManagerSingleton instance { get; private set; }

    //Game Values
    public float musicVol;
    public float sfxVol;
    public AudioMixer mixer;

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
        if(levelAccess == level)
            levelAccess = level++;
    }

    public void SetLevelVolume(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }
}
