using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class huma : MonoBehaviour
{
    public GameObject Prota;
    public GameObject Bullet;
    public int Health = 1;
    private Player_movment _hit;


    private float LastShoot;
    private void Update()
    {
        Vector3 direction = Prota.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        float distance = Mathf.Abs(Prota.transform.position.x - transform.position.x);
        if(distance <1.0f && Time.time > LastShoot + 1.0f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void Shoot()
    {
        Debug.Log("Shoot");

        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector3.right;
        else direction = Vector3.left;

        GameObject instBullet = Instantiate(Bullet, transform.position + direction * 0.2f, Quaternion.identity);
        instBullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            if (gameObject.tag.Equals("Enemy"))
                Health -= 1;
            if (Health == 0) {
                
                Debug.Log("Dead Enemy");
                Destroy(gameObject);
            }


           

        }
    }
}
