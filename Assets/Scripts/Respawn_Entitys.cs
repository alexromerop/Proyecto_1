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
    public void DEATH()
    {
        
            StartCoroutine("Esperar");
            Entity.GetComponent<Player_movment>().Health = 1;
            Entity.GetComponent<Player_movment>().enableInput = true;
        
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(0.4f);
       
            Entity.transform.position = transform.position;
        
            
        
    }
}
