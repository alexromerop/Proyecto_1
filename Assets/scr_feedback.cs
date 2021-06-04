using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_feedback : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")|| collision.CompareTag("Enemy") || collision.CompareTag("Controlable"))
        {
            anim.SetTrigger("Move");
        }
    }
}
