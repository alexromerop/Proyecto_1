using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; set; }
    
    public AudioSource backgroundMusic;
    public AudioMixer mixer;

    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLevelVolume(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }

    public void ChangeBackgroundMusic(AudioClip music)
    {
        if (backgroundMusic.clip.name == music.name)
            return;

        backgroundMusic.Stop();
        backgroundMusic.clip = music;
        backgroundMusic.Play();
    }
}
