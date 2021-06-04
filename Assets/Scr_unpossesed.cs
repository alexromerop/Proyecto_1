using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_unpossesed : MonoBehaviour
{
    public float Speed;
    Rigidbody2D Rigidbody2D;
    public Animator animator;



    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.localScale.x <= 0&& Speed>=0)
        {
            this.gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

    }
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Speed, Rigidbody2D.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(Speed));

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            Speed *= -1;
            this.transform.localScale = new Vector2(this.transform.localScale.x * -1, this.transform.localScale.y);
        }
    }
}
