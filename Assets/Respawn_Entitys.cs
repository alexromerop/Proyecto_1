using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn_Entitys : MonoBehaviour
{
    public GameObject Entity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Entity.GetComponent<Player_movment>().Health <= 0)
        {
            StartCoroutine("Esperar");
            Entity.GetComponent<Player_movment>().Health++;

        }
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(1);
       
            Entity.transform.position = transform.position;
        
            
        
    }
}
