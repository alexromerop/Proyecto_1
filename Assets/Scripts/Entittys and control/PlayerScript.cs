using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerScript : MonoBehaviour
{
    public ControlScript control;
    private float speedX;
    private float speedY;
    public float speed;
    public GameObject player;
    public enum Possesions
    {
        Rat,
        Skeleton,
        Zombie
    }
    void Update()
    {
        if (Input.GetKeyDown("g")|| control.CurrentControl.GetComponent<Player_movment>().Health<=0)
        {
            /*if(control.CurrentControl.GetComponent<Player_movment>().Health <= 0)
            {
                Destroy(control.CurrentControl);
            }*/
            control.UnPosses();
            control.CanControl[0].GetComponent<Player_movment>().enabled = true;
            //player.transform.position = control.transform.position;
        }
    }
    void OnMouseDown()
    {
        control.Posses(gameObject);
        GetComponent<Player_movment>().enabled = true;
        player.SetActive(false);
    }
}
