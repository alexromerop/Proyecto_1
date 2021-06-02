using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fx_scr : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;


    private Vector2 Direction;
    private Rigidbody2D rigidbody2d;
   

    // Start is called before the first frame update

    private void Update()
    {
        
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        //this.transform.loca = Direction;
    }
    public void SetDirection(Vector3 direction)
    {
        Direction = direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("wateer");
        if (collision.gameObject.layer.Equals("Control"))
        {

            Debug.Log("wateer");

        }
           
        
        
    }
    private void OnParticleCollision(GameObject other)
    {
        

        if (other.gameObject.tag.Equals("Cogible"))
        {
            StartCoroutine(Unset());


        }

    }

    IEnumerator Unset()
    {
        yield return new WaitForSeconds(0.4f);
        Destroy(this.gameObject);

    }
}
