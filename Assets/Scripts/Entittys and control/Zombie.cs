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
    


    private GameObject boxTaken = null;
    private float LastShoot;
    public bool taken;
    public float timetotake = 0;
    public void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        taken = false;
    }
    public void Update()
    {
        float delta = Time.deltaTime * 1000;
        if (timetotake > 0)
        {
            timetotake -= delta;
            if (timetotake <= 0)
            {
                timetotake = 0;
            }
        }
        if (GetComponent<Player_movment>().enabled == true)
        {
            if (boxTaken != null)
            {
                if (Input.GetKeyDown(KeyCode.E)&& timetotake==0)
                {
                
                    LeaveBox(boxTaken);
                    timetotake = 500;
                }
            }


            zombie_pos = transform.position;
        }
        horizontal = GetComponent<Player_movment>().horizontal;
    }
   
    private void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log("trigger");
        if (other.gameObject.tag.Equals("Cogible"))
        {
            Debug.Log("trigger");
            if (Input.GetKeyDown(KeyCode.E) && !taken && timetotake == 0)
            {
                //other.gameObject.GetComponent<BoxCollider2D>().enabled= false;
                TakeBox(other.gameObject);
                Debug.Log("Take");
                taken = true;
                timetotake = 500;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Cogible"))
        {
            other.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Cogible"))
        {
            other.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
    
    private void TakeBox(GameObject box)
    {
        //box.GetComponent<Rigidbody2D>().position = zombie.GetComponent<Rigidbody2D>().position;

        
        

        if (horizontal < 0.0f)
        {
            
                box.transform.position = zombie.transform.position + new Vector3(0, 0.33f, 0); 
            
        }
        if (horizontal >= 0.0f)
        {
            
                box.transform.position = zombie.transform.position + new Vector3(0, 0.33f, 0);
            
        }
        box.transform.SetParent(zombie.transform);
        box.GetComponent<Rigidbody2D>().isKinematic = true;
        //box.GetComponent<Rigidbody2D>().useFullKinematicContacts = true;
        boxTaken = box;

    }

    private void LeaveBox(GameObject box)
    {
        box.GetComponent<Rigidbody2D>().isKinematic = false;
        box.transform.SetParent(null);
        taken = false;
        boxTaken = null;
    }
}

