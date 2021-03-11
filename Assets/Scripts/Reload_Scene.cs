using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload_Scene : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
