using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public GameObject Prota;
    public GameObject Bullet;
    public GameObject Skeleton_;


    private float LastShoot;
    public void Update()
    {
        Player_movment variable = GetComponent<Player_movment>();
        if (variable.in_control == false)
        {
            Vector3 direction = Prota.transform.position - transform.position;
            float distance = Mathf.Abs(Prota.transform.position.x - transform.position.x);
            if (distance < 2.0f)
            {
                if (direction.x >= 0.0f) transform.localScale = new Vector3(0.16f, 0.34f, 1.0f);
                else transform.localScale = new Vector3(-0.16f, 0.34f, 1.0f);
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
    }






    }

