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
        speedX = (transform.position.x - player.transform.position.x) * speed;
        speedY = (transform.position.y - player.transform.position.y) * speed;
        if (Input.GetKeyDown("g")){
            control.UnPosses();
            control.CanControl[0].GetComponent<Player_movment>().enabled = true;
        }
    }
    void OnMouseDown()
    {
        control.Posses(gameObject);
        GetComponent<Player_movment>().enabled = true;
        player.GetComponent<Rigidbody2D>().AddForce(new Vector2(speedX, speedY), ForceMode2D.Impulse);
        player.SetActive(false);
    }
}
