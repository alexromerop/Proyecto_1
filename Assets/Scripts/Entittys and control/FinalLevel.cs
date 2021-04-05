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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            GameManagerSingleton.instance.CompleteLevel(numLevel);
            LevelComplete();
        }
    }

    void LevelComplete()
    {
        completeLevel.SetActive(true);
    }
}
