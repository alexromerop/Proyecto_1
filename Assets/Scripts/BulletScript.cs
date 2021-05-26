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
       
        
        Destroy(gameObject, 1.5f);
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
        Destroy(gameObject);
    }
}
