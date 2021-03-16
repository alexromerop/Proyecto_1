using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public GameObject Prota;
    public GameObject Bullet;
    public GameObject Skeleton_;

    private float LastShoot;
    public void Start()
    {
        
    }
    public void Update()
    {
        Player_movment variable = GetComponent<Player_movment>();
        if ( GetComponent<Player_movment>().enabled == true)
        {
            if ((Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.E)) && Time.time> LastShoot + 0.3f)
            {
                Shoot();
                LastShoot = Time.time;
            }
        }
    }
    private void Shoot()
    {
        Debug.Log("Shoot");

        Vector3 direction;
        if (GetComponent<Player_movment>().transform.localScale.x == 1.0f) direction = Vector3.right;
        else direction = Vector3.left;

        GameObject instBullet = Instantiate(Bullet, transform.position + direction*0.1f, Quaternion.identity);
        instBullet.GetComponent<BulletScript>().SetDirection(direction);
    }

}

