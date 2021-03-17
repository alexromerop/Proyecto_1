using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    public GameObject door;
    //private Vector3 direction;
    //public float speed;
    public GameObject target;
    private Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        //direction = Vector3.up;
        targetPos = target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenDoor()
    {
        Debug.Log("Open Door");
        door.transform.position += Vector3.MoveTowards(door.transform.position, targetPos, 2);

    }
}
