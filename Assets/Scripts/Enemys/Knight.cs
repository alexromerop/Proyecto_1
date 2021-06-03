using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    public Animator animator;
    public GameObject[] targets;
    public int Health;
    Rigidbody2D rigidbody2D;
    public float speed;
    [SerializeField] bool isAttacking;
    public Vector3 direction;
    [SerializeField] float distance;
    

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Health = 3;
    }

    private void FixedUpdate()
    {
        if (!isAttacking)
        {
            rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
        }
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            direction = targets[i].transform.position - transform.position;
            distance = Mathf.Abs(targets[i].transform.position.x - transform.position.x);
            if (distance < 0.5f && direction.x >= 0.0f && direction.y < 0.5f)
            {
                isAttacking = true;
                animator.SetTrigger("Attack");
            } else if (distance < 0.5f && direction.x < 0.0f && direction.y < 0.5f)
            {
                isAttacking = true;
                animator.SetTrigger("Attack");
            } else
            {
                isAttacking = false;
            }
        }
        if (Health <= 0)
        {
            rigidbody2D.bodyType = RigidbodyType2D.Static;
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            speed *= -1;
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag.Equals("Bullet"))
        {
            

                Health -= 1;
        }
    }
}
