using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    public GameObject door;
    public GameObject target;
    public Sprite sprite;

    private Vector3 targetPos;
    private SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        //door = GameObject.Find("Door");
        if (renderer == null)
        {
            renderer = gameObject.GetComponent<SpriteRenderer>();
        }
        if(target != null)
        {
            targetPos = target.transform.position;
        }
    }
    public void MoveObject()
    {
        Debug.Log("Open Door");
        door.transform.position = Vector3.MoveTowards(door.transform.position, targetPos, 5);
        ChangeSprite();

    }

    public void DestroyObject(GameObject gameObject)
    {
        Debug.Log("Platform destroyed");
        Destroy(gameObject);
        ChangeSprite();
    }

    private void ChangeSprite()
    {
        Debug.Log("Change Sprite");
        renderer.sprite = sprite;
    }
}
