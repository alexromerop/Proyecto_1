using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{

    public GameObject[] CanMove;
    [SerializeField]
    public GameObject Prota;
    public GameObject Box;
    public GameObject zombie;
    Rigidbody2D Rigidbody2D;
    public float horizontal;
    public Vector2 zombie_pos;



    private float LastShoot;
    public void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        
    }
    public void Update()
    {
        
        if (GetComponent<Player_movment>().enabled == true)
        {
            if (Input.GetKeyDown(KeyCode.E) /*&& Time.time > LastShoot + 0.3f*/)
            {
                Take_box();
                //LastShoot = Time.time;
            }

            zombie_pos = transform.position;
        }
        horizontal = GetComponent<Player_movment>().horizontal;
    }
    private void Take_box()
    {
        if (horizontal < 0.0f)
        {
            if (Physics2D.Raycast(transform.position, Vector3.left, 0.8f))
            {
                Box.GetComponent<Rigidbody2D>().position = zombie.GetComponent<Rigidbody2D>().position;

                Box.transform.SetParent(zombie.transform);
                Box.GetComponent<Rigidbody2D>().bodyType++;
                Box.GetComponent<Rigidbody2D>().bodyType++;
                transform.position = zombie.transform.position;



            }
        }
        if (horizontal > 0.0f)
        {
            if (Physics2D.Raycast(transform.position, Vector3.right, 0.8f))
            {
                
              
                Box.transform.SetParent(zombie.transform);
               //Box.GetComponent<Rigidbody2D>().bodyType++;
                //Box.GetComponent<Rigidbody2D>().bodyType++;
                Box.transform.position = zombie_pos + new Vector2(0, 0.3f);

                



                transform.position = zombie.transform.position;
                    
            }
        }
                   

        
    }
}

