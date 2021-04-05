using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalLevel : MonoBehaviour
{
    public int numLevel;

    public GameObject completeLevel;


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Controlable"))
        {
            GameManagerSingleton.instance.CompleteLevel(numLevel);
            //Debug.Log("Collision");
            LevelComplete();
        }
    }

    void LevelComplete()
    {
        completeLevel.SetActive(true);
        Debug.Log(GameManagerSingleton.instance.levelAccess);
        Time.timeScale = 0f;
    }
}
