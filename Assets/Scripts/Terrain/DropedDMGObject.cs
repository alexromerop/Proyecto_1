using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropedDMGObject : MonoBehaviour
{
    public bool in_ground;
    public RaycastHit2D hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, 0.4f ) == false)
        {
            in_ground = true;
        }
        else in_ground = false;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        

       if (collision.gameObject.tag.Equals("Enemy"))
       {

            //if (in_ground == false) 
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }



       }
    }
}
