using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rigidbody2d;
    private Vector2 Direction;



    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Destroy(gameObject, 3f);
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        rigidbody2d.velocity = Direction * speed;
    }
    public void SetDirection(Vector3 direction)
    {
        Direction = direction;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("terrain"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag.Equals("Cogible"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag.Equals("MainCamera"))
        {
            Destroy(gameObject);
        }
        else
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 100);
        }
        if(collision != null && collision.gameObject.tag.Equals("Enemy"))
        {
            if (collision.gameObject.GetComponent<Knight>().speed == 1)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Direction * 100);
            }
            if (collision.gameObject.GetComponent<Knight>().speed == -1)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(collision.gameObject.GetComponent<Knight>().direction * 10);
            }
        }
        Destroy(gameObject); 
    }
}
