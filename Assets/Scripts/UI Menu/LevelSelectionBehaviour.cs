using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionBehaviour : MonoBehaviour
{
    public Button buttonTutorial;
    public Button buttonLevel1;
    public Button buttonLevel2;
    public Button buttonLevel3;

    private void Start()
    {

    }

    private void Update()
    {
        if (GameManagerSingleton.instance.levelAccess >= 0)
        {
            buttonTutorial.interactable = true;
        }
        if (GameManagerSingleton.instance.levelAccess >= 1)
        {
            buttonLevel1.interactable = true;
        }
        if (GameManagerSingleton.instance.levelAccess >= 2)
        {
            buttonLevel2.interactable = true;
        }
        if (GameManagerSingleton.instance.levelAccess >= 3)
        {
            buttonLevel3.interactable = true;
        }
    }
}

