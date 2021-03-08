using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataform_move_x : MonoBehaviour
{
    public bool x = false;
    public bool y = true;



    public float dirX, moveSpeed = 1f;
    public bool moveRight = true;


    void Update()
    {
        if (x)
        {
            if (transform.position.x > 3f)
                moveRight = false;
            if (transform.position.x < 1f)
                moveRight = true;

            if (moveRight)
                transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
            else
                transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }
        if (y)
        {
            if (transform.position.y > 4f)
                moveRight = false;
            if (transform.position.y < 1f)
                moveRight = true;

            if (moveRight)
                transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
            else
                transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
        }

    }

}
