﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScript : MonoBehaviour
{
    public GameObject[] CanControl;
    //[SerializeField]
    public GameObject CurrentControl;
    public new CameraClamp camera;
    void Start()
    {
        for (int i = 1; i < CanControl.Length; i++)
        {
            CanControl[i].GetComponent<Player_movment>().enabled = false;
        }

        CurrentControl = CanControl[0];
    }
    public void Posses(GameObject player)
    {
        CurrentControl.GetComponent<Animator>().SetBool("Possesed", false);
        CurrentControl.GetComponent<Player_movment>().enabled = false;
        //CurrentControl.GetComponent<CapsuleCollider2D>().enabled = false;
        if (CurrentControl == CanControl[0])
        {
            //CurrentControl.transform.position = player.transform.position;
        }
        CurrentControl = player;
        camera.SetTarget(player);
        player.GetComponent<Animator>().SetBool("Possesed", true);
        if (player.GetComponent<ParticleSystem>() != null)
        {
            player.GetComponent<ParticleSystem>().Play();
        }
    }

    public void UnPosses()
    {

        CurrentControl.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        CurrentControl.GetComponent<Player_movment>().enabled = false;
        CanControl[0].transform.position = CurrentControl.transform.position;
        CurrentControl = CanControl[0];
        camera.SetTarget(CanControl[0]);
        CurrentControl.SetActive(true);
    }
}
