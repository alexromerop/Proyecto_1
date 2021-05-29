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

    public Animator animator;
    public AudioManager audioManager;
        
    public bool in_ground;


    public int Health = 1;
    private int sceneIndex;

    public bool enableInput = true;

    public GameObject spawn;

    private bool controlled = false;

    void Start()
    {
        controlled = false;
        Rigidbody2D = GetComponent<Rigidbody2D>();
        if(GameManagerSingleton.instance == null)
        {
            sceneIndex = 0;
        } else { 
            sceneIndex = GameManagerSingleton.instance.scene; 
        }
        enableInput = true;
        //animator.SetBool("Possesed", controlled);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Health", Health);
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        animator.SetBool("Grounded", in_ground);
        
        if (enableInput)
        {
            horizontal = Input.GetAxisRaw("Horizontal");

            //flip body
            if (horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            else if (horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

            if (Physics2D.Raycast(transform.position, Vector3.down, 0.2f))
            {
                in_ground = true;
            }
            else in_ground = false;

            if (Input.GetKeyDown("space") && in_ground && !gameObject.tag.Equals("Player"))
            {
                if (!gameObject.name.Equals("Enemy_Zombie"))

                    Jump();
            }

           /* if (Input.GetKeyDown("r"))
            {
                Hit();
            }*/
        }
        if(Health <= 0)
        {
            Dead();
            //SceneManager.LoadScene(sceneIndex);
        }
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
            if (gameObject.tag.Equals("Controlable"))
                Health -= 1;
        }
        if (collision.gameObject.tag.Equals("Pinchos"))
        {
            if (gameObject.tag.Equals("Controlable"))
            {
                Health -= 1;
            }
        }
        }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Plataform"))
            transform.parent = null;
    }
    private void Dead()
    {
        enableInput = false;
        StartCoroutine(DeadAnimation());
        //SceneManager.LoadScene(sceneIndex);
    }
    public void Hit()
    {
        Rigidbody2D.AddForce(transform.up * Vector2.up);
        Health -= 1;
        //poner un  as muerto y un boton para reinicar el nivel, en otro void y en el update un if heal<=0
        //Destroy(gameObject);
    }
    public void Hit_fisico()
    {
        Health -= 1;
        if (Health == 0) Debug.Log("Dead");
    }
    IEnumerator DeadAnimation()
    {
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0);
        Debug.Log("Dead Enemy");
        //audioManager.PlayDeath();
        spawn.GetComponent<Respawn_Entitys>().DEATH();
       // if (gameObject.tag.Equals("Controlable"))
            //Destroy(gameObject);
       // else
            //SceneManager.LoadScene(sceneIndex);
    }
}

