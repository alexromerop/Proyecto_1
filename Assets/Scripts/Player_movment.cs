using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_movment : MonoBehaviour
{

    public bool death;

    
    public enum Controller { Default, Rat, Skeleton, Zombie };
    public Controller controller = Controller.Default;
    public float Speed;
    public float JumpForce;
    public bool in_control;

    Rigidbody2D Rigidbody2D;
    private float horizontal;
    private float vertical;

        
    public bool in_ground;

    
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
}

    // Update is called once per frame
    void Update()
    {
    horizontal = Input.GetAxisRaw("Horizontal");
        
        //añadir voladores en controller.loquesea
        if (controller == Controller.Default)
            vertical = Input.GetAxisRaw("Vertical");

        //flip body
        if (horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        
        


       if (Physics2D.Raycast(transform.position, Vector3.down, 0.25f))
        {
            in_ground = true;
        }
        else in_ground = false;
       


        if (Input.GetKeyDown("space")&& in_ground)
        {
            Jump();
        }

        if (Input.GetKeyDown("c"))
        {
            death = true;
        }

    //habilidades segun enemigos
    }
    private void Jump()
    {
        
        Rigidbody2D.AddForce(transform.up*JumpForce);

    }


    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(horizontal, vertical);
    }

    //para estarse en la posicion 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Plataform"))
            this.transform.parent = collision.transform;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Plataform"))
            this.transform.parent = null;
    }
}

