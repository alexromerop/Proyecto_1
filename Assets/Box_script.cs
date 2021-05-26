using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_script : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D Rigidbody2D;
    public GameObject box;
    public GameObject puede_mover;
    public int contador;
    

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(contador);
       if (contador == 1)
       {
            Debug.Log("waiting");
            StartCoroutine(Wait_box());
       }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("BoxDownGround"))
        {
            box.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag.Equals("terrain"))
        //{
        //   transform.position = transform.position;
        //}
    }

    IEnumerator Wait_box()
    {
        yield return new WaitForSeconds(0.35f);
        if (contador == 0)
        {
            box.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
        contador = 0;
        Debug.Log("stop");
    }
}