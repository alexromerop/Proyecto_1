using System.Collections;
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
        CurrentControl.GetComponent<Player_movment>().enabled = false;
        //CurrentControl.GetComponent<CapsuleCollider2D>().enabled = false;
        if (CurrentControl == CanControl[0])
        {
            //CurrentControl.transform.position = player.transform.position;
        }
        CurrentControl = player;
        camera.SetTarget(player);
        player.GetComponent<Player_movment>().controlled = true;
        player.GetComponent<ParticleSystem>().Play();
    }

    public void UnPosses()
    {
        CurrentControl.GetComponent<Player_movment>().controlled = false;
        CurrentControl.GetComponent<Player_movment>().enabled = false;
        CanControl[0].transform.position = CurrentControl.transform.position;
        CurrentControl = CanControl[0];
        camera.SetTarget(CanControl[0]);
        CurrentControl.SetActive(true);
    }
}
