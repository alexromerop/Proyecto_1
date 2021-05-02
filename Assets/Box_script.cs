using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_script : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D Rigidbody2D;
    public GameObject box;
    public GameObject puede_mover;

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("A");

        if (collision.gameObject.tag.Equals("terrain"))
        {
            Debug.Log("Aaa");

            box.GetComponent<Rigidbody2D>().bodyType += 2;
        }
        else
        {
            //box.GetComponent<Rigidbody2D>().bodyType += 2;
        }

    }
 
        }
