using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Humano : MonoBehaviour
{
    public GameObject[] Alie;
    public GameObject Prota;
    public GameObject Bullet;
    public int Health = 2;
    public Animator animator;
    public float speed;
    public bool shoting;

    public AudioManager audioManager;

    private float LastShoot;
    private Rigidbody2D rigidbody2D;
    [SerializeField] Vector3 direction;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        //if (!shoting)
        //{
        //    rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
        //}
    }
    private void Update()
    {

        for (int i = 0; i < Alie.Length; i++)
        {
            direction = Alie[i].transform.position - transform.position;
            if (direction.x >= 0.0f && direction.y < 0.3f)
            {
                transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
               // Human.GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (direction.x < 0.0f && direction.y > 0.3f)
            { 
                transform.localScale = new Vector3(-0.8f, 0.8f, 0.8f);
               
            }

            float distance = Mathf.Abs(Alie[i].transform.position.x - transform.position.x);
            if (distance < 3.0f && Time.time > LastShoot + 1.5f && direction.y > -0.2f)
            {
                shoting = true;
                animator.SetTrigger("Shoot");
                StartCoroutine(ShootAnimation());
                shoting = false;
                LastShoot = Time.time;
            }
            animator.SetFloat("Speed", Mathf.Abs(speed));
            

        }
        if (Health == 0)
        {

            Debug.Log("Dead Enemy");
            Destroy(gameObject);
        }
    }
    private void Shoot(Vector3 directionTarget)
    {
        Debug.Log("Shoot");
        Vector3 bulletPosition = transform.position + directionTarget * 0.28f;
        //audioManager.PlayClicked();
        GameObject instBullet = Instantiate(Bullet, bulletPosition, Quaternion.identity);
        instBullet.GetComponent<BulletScript>().SetDirection(directionTarget);
    }

    IEnumerator ShootAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        Shoot(direction.normalized);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "Border")
        //{
        //    speed *= -1;
        //    transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        //}
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            Health -= 1;
        }
    }
}
