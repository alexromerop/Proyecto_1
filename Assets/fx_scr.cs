using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fx_scr : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;


    private Vector2 Direction;
    private Rigidbody2D rigidbody2d;
    public GameObject Player;
    public bool Atacando;

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

}
