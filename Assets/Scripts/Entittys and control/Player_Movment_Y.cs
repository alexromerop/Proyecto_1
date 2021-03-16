using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movment_Y : MonoBehaviour
{
    private float vertical;
    Rigidbody2D Rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");

    }

    private void FixedUpdate()
    {
        if (GetComponent<Player_movment>().enabled == true)
        {
            GetComponent<Rigidbody2D>().gravityScale=2;
            
                Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, vertical);
        }
    }
}
