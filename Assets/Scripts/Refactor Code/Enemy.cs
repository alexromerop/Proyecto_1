using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IPossessable
{
    [SerializeField] float speed;

    bool canMove;
    public void Possess()
    {
        enabled = true; //Active Update of the object
    }

    public void UnPossess()
    {
        enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // si Ipossebile is enabled Update is called by the gamobject attached
        if(canMove)
        {
            Debug.Log("Move Out of the Way");
           
        }
    }
}
