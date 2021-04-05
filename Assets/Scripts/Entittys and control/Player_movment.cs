using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_movment : MonoBehaviour
{



    
  
    public float Speed;
    public float JumpForce;
    public bool in_control;

    Rigidbody2D Rigidbody2D;
    public float horizontal;
    

        
    public bool in_ground;


    public int Health = 1;
    private int sceneIndex;
    
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        sceneIndex = GameManagerSingleton.instance.scene;
        horizontal = Input.GetAxisRaw("Horizontal");
        
        //añadir voladores en controller.loquesea
     
        

        //flip body
        if (horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        
        


       if (Physics2D.Raycast(transform.position, Vector3.down, 0.2f))
        {
            in_ground = true;
        }
        else in_ground = false;
       


        if (Input.GetKeyDown("space")&& in_ground && !gameObject.tag.Equals("Player"))
        {
            Jump();
        }

        if (Input.GetKeyDown("r"))
        {
            Hit();
        }
       

    //habilidades segun enemigos
    }
    private void Jump()
    {
        
        Rigidbody2D.AddForce(transform.up*JumpForce);

    }


    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(horizontal*Speed, Rigidbody2D.velocity.y);
    }

    //para estarse en la posicion 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Plataform"))
            transform.parent = collision.transform;

        if (collision.gameObject.tag.Equals("Bullet")) {
            if (gameObject.tag.Equals("Player"))
                Hit();
            // Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag.Equals("Pinchos"))
        {
            if (gameObject.tag.Equals("Controlable"))
            {
                Hit_fisico();
            }
        }
        if (collision.gameObject.tag.Equals("Infinite"))
        {
            if (gameObject.tag.Equals("Controlable"))
            {
                Debug.Log("Respawn on Checkpoint, Reload Scene");
                Hit_fisico();
            }
        } 
}
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Plataform"))
            transform.parent = null;
    }
    public void Hit()
    {
        Health-= 1;
        if (Health == 0) Debug.Log("Dead");

        //poner un  as muerto y un boton para reinicar el nivel, en otro void y en el update un if heal<=0
        //SceneManager.LoadScene("Map_test");
        SceneManager.LoadScene(sceneIndex);
    }
    public void Hit_fisico()
    {
        Health -= 1;
        if (Health == 0) Debug.Log("Dead");

        
    }
}

