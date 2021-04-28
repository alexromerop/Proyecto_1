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
        StartCoroutine("Esperar");
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(2);
        if (Entity.GetComponent<Player_movment>().Health <= 0)
        {
            Entity.transform.position = transform.position;
            Entity.GetComponent<Player_movment>().Health++;
        }
    }
}
