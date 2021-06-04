﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalLevel : MonoBehaviour
{
    public int numLevel;

    public GameObject completeLevel;
    public Sprite sprite;
    public GameObject goal;
    public GameObject Salir_con_este;

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject== Salir_con_este.gameObject)
        {
            //Debug.Log("Collision");
            goal.GetComponent<SpriteRenderer>().sprite = sprite;
            LevelComplete();
        }
    }

    public void LevelComplete()
    {
        completeLevel.SetActive(true);
        GameManagerSingleton.instance.CompleteLevel(numLevel);
        Debug.Log(GameManagerSingleton.instance.levelAccess);
        Time.timeScale = 0f;
    }
}
