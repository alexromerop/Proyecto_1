using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    public Animator animator;
    public GameObject[] targets;
    Rigidbody2D rigidbody2D;
    [SerializeField] float speed;
    [SerializeField] bool isAttacking;
    

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
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
            Vector3 direction = targets[i].transform.position - transform.position;
            float distance = Mathf.Abs(targets[i].transform.position.x - transform.position.x);
            if (distance < 0.5f && direction.x >= 0.0f)
            {
                isAttacking = true;
                animator.SetTrigger("Attack");
            } else
            {
                isAttacking = false;
            }
        }
        animator.SetFloat("Speed", speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            speed *= -1;
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }
    }
}
