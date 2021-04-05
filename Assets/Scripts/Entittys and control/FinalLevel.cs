using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalLevel : MonoBehaviour
{
    public int numLevel;

    public GameObject completeLevel;
    public Sprite sprite;
    public GameObject goal;

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Controlable"))
        {
            //Debug.Log("Collision");
            goal.GetComponent<SpriteRenderer>().sprite = sprite;
            LevelComplete();
        }
    }

    void LevelComplete()
    {
        completeLevel.SetActive(true);
        GameManagerSingleton.instance.CompleteLevel(numLevel);
        Debug.Log(GameManagerSingleton.instance.levelAccess);
        Time.timeScale = 0f;
    }
}
