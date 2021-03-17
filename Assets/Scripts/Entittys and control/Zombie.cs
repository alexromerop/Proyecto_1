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
    public int Health = 1;


    private GameObject boxTaken;
    private float LastShoot;
    private bool taken;
    public void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        taken = false;
    }
    public void Update()
    {
        
        if (GetComponent<Player_movment>().enabled == true)
        {
            
            if (Input.GetKeyDown(KeyCode.E) && Time.time > LastShoot + 0.3f)
            {
                if (boxTaken != null)
                {
                    LeaveBox(boxTaken);
                    LastShoot = Time.time;
                }
            }

            zombie_pos = transform.position;
        }
        horizontal = GetComponent<Player_movment>().horizontal;
    }
   
    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("trigger");
        if (other.gameObject.tag.Equals("Cogible"))
        {
            if(!taken)
            boxTaken = other.gameObject;
            if (Input.GetKey(KeyCode.E) && !taken)
            {
                //other.gameObject.GetComponent<BoxCollider2D>().enabled= false;
                TakeBox(other.gameObject);
                Debug.Log("Take");
                taken = true;
                other.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
       /* if (other.gameObject.tag.Equals("Cogible"))
        {
            other.gameObject.GetComponent<BoxCollider2D>().enabled = true;

        }*/

            if (other.gameObject.tag.Equals("Bullet"))
        {
            if (gameObject.tag.Equals("Enemy"))
                Health -= 1;
            if (Health == 0)
            {
                Debug.Log("Dead");
                Destroy(gameObject);
            }
        }
    }
    private void TakeBox(GameObject box)
    {
        box.GetComponent<Rigidbody2D>().position = zombie.GetComponent<Rigidbody2D>().position;

        
        

        if (horizontal < 0.0f)
        {
            
                box.transform.position = zombie.transform.position + new Vector3(0, 0.33f, 0); 
            
        }
        if (horizontal > 0.0f)
        {
            
                box.transform.position = zombie.transform.position + new Vector3(0, 0.33f, 0);
            
        }
        box.transform.SetParent(zombie.transform);
        box.GetComponent<Rigidbody2D>().simulated = false;

    }

    private void LeaveBox(GameObject box)
    {
        box.GetComponent<Rigidbody2D>().position = transform.position;
        box.GetComponent<Rigidbody2D>().simulated = true;
        box.transform.parent = null;
        taken = false;
    }
}

