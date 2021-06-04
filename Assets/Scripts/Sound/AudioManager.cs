﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    AudioSource[] mySounds;

    private AudioSource backgroundMusic;
    private AudioSource clicked;
    private AudioSource hit;
    private AudioSource death;
    private AudioSource arrowShot;

    // Start is called before the first frame update
    private void Awake()
    {
        mySounds = GetComponentsInParent<AudioSource>();
        clicked = mySounds[0];
        backgroundMusic = mySounds[1];
        hit = mySounds[2];
        death = mySounds[3];
        arrowShot = mySounds[4];
    }

    IEnumerator WaitSound(AudioSource audio)
    {
        audio.Play();
        yield return new WaitUntil(() => audio.isPlaying == false);
    }
    public void PlayClicked()
    {
        StartCoroutine(WaitSound(clicked));
    }
    public void PlayBackground()
    {
        backgroundMusic.Play();
    }
    public void StopBackground()
    {
        backgroundMusic.Pause();
    }

    public void PlayHit()
    {
        hit.Play();
    }
    public void PlayDeath()
    {
        StartCoroutine(WaitSound(death));
    }
    public void PlayArrowShot()
    {
        arrowShot.Play();
    }
}
