using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement variables
    [SerializeField] float speed;
    Vector2 axis;
    Vector2 playerMovement;
    Vector2 jumpMovement;
    bool isIdle;
    bool canMove;
    bool left = false;

    //Other variables
    //Components
    Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        canMove = true;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        SetAxis();
        if (axis.x != 0)
        {
            isIdle = false;
        }
        else
        {
            isIdle = true;
            rigidbody.gravityScale = 2;
        }

        //Assign velocity
        playerMovement.x = axis.x * speed;
        playerMovement.y = axis.y * speed;

        if (canMove)
        {
            rigidbody.velocity = playerMovement;
        }

        //Flip Player
        if (canMove)
        {
            if (axis.x < 0 && !left)
            {
                FlipPlayer();
            }
            else if (axis.x > 0 && left)
            {
                FlipPlayer();
            }
        }
    }

    void FlipPlayer()
    {
        left = !left;
        transform.Rotate(0, 180, 0);
    }

    void SetAxis()
    {
        axis.x = Input.GetAxis("Horizontal");
        axis.y = Input.GetAxis("Vertical");
    }
}
