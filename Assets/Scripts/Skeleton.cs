using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public GameObject Prota;
    public GameObject Bullet;
    public GameObject Skeleton_;


    private Vector3 direction;
    private float distance;
    private float LastShoot;

    public void Start()
    {
        direction = Prota.transform.position - transform.position;
    }
    public void Update()
    {
        Player_movment variable = GetComponent<Player_movment>();
        if (variable.in_control == false)
        {
            distance = Mathf.Abs(Prota.transform.position.x - transform.position.x);
            if (distance < 2.0f)
            {
                if (direction.x >= 0.0f) transform.localScale = new Vector3(1f, 1f, 1.0f);
                else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            }
            if (distance < 1.5f && Time.time > LastShoot + 1f)
            {
                Shoot();
                LastShoot = Time.time;
            }
        }
    }
    private void Shoot()
    {
        Debug.Log("Shoot");

        GameObject instBullet = Instantiate(Bullet, transform.position, transform.rotation);
        Rigidbody2D instBulletRigidbody = instBullet.GetComponent<Rigidbody2D>();
        instBulletRigidbody.velocity = direction * 2;
    }

    }

