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
            
            if (Input.GetKeyDown(KeyCode.E) /*&& Time.time > LastShoot + 0.3f*/)
            {
                if (boxTaken != null)
                {
                    LeaveBox(boxTaken);
                }
            }

            zombie_pos = transform.position;
        }
        horizontal = GetComponent<Player_movment>().horizontal;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Cogible"))
        {
            boxTaken = other.gameObject;
            if (Input.GetKey(KeyCode.E) && !taken){
                TakeBox(other.gameObject);
                Debug.Log("Take");
                taken = true;
            }
        }

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

        box.transform.SetParent(zombie.transform);
        box.GetComponent<Rigidbody2D>().simulated = false;
        if (horizontal < 0.0f)
        {
            if (Physics2D.Raycast(transform.position, Vector3.left, 0.8f))
            {
                transform.position = zombie.transform.position;
            }
        }
        if (horizontal > 0.0f)
        {
            if (Physics2D.Raycast(transform.position, Vector3.right, 0.8f))
            {
                transform.position = zombie.transform.position;
            }
        }
    }

    private void LeaveBox(GameObject box)
    {
        box.GetComponent<Rigidbody2D>().position = transform.position;
        box.GetComponent<Rigidbody2D>().simulated = true;
        box.transform.parent = null;
        taken = false;
    }
}

