using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class huma : MonoBehaviour
{
    public GameObject[] Alie;
    public GameObject Prota;
    public GameObject Bullet;
    public int Health = 1;
    private Player_movment _hit;
    public Animator animator;
    private float speed;
    public bool shoting;

    public AudioManager audioManager;

    private float LastShoot;
    private void Update()
    {

        for (int i = 0; i < Alie.Length; i++)
        {
            Vector3 direction = Alie[i].transform.position - transform.position;
            if (direction.x >= 0.0f)
            {
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
               // Human.GetComponent<SpriteRenderer>().flipX = false;
            }
            else { 
                transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
               
            }

            float distance = Mathf.Abs(Alie[i].transform.position.x - transform.position.x);
            if (distance < 1.0f && Time.time > LastShoot + 1.0f)
            {
                shoting = false;
                Shoot();
                LastShoot = Time.time;
                shoting = true;
            }
            animator.SetBool("Shoting", shoting);
            animator.SetFloat("Speed", Mathf.Abs(speed));
            

        }
    }
    private void Shoot()
    {
        Debug.Log("Shoot");

        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector3.right;
        else direction = Vector3.left;

        //audioManager.PlayClicked();
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
