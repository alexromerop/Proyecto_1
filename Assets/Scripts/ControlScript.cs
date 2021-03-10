using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScript : MonoBehaviour
{

    public GameObject[] CanControl;
    [SerializeField]
    GameObject CurrentControl;
    void Start()
    {
        for (int i =1; i < CanControl.Length; i++)
        {
            CanControl[i].GetComponent<Player_movment>().enabled = false;
        }

        CurrentControl = CanControl[0];
    }

    // Update is called once per frame
    public void Posses(GameObject player)
    {
        CurrentControl.GetComponent<Player_movment>().enabled = false;
        CurrentControl = player;
    }
}
