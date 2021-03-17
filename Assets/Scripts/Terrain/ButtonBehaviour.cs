using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    public GameObject door;
    public GameObject target;

    private Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        door = GameObject.Find("Door");
        targetPos = target.transform.position;
    }
    public void OpenDoor()
    {
        Debug.Log("Open Door");
        door.transform.position = Vector3.MoveTowards(door.transform.position, targetPos, 5);

    }
}
