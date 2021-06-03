using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    public GameObject door;
    public GameObject target;
    public Sprite sprite;
    public ParticleSystem particle;

    private Vector3 targetPos;
    private SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = gameObject.GetComponent<SpriteRenderer>();
        if (target != null)
        {
            targetPos = target.transform.position;
        }
    }
    public void MoveObject()
    {
        Debug.Log("Open Door");
        door.transform.position = Vector3.MoveTowards(door.transform.position, targetPos, 5);
        particle_on_object();
        ChangeSprite();

    }

    public void DestroyObject(GameObject gameObject)
    {
        Debug.Log("Platform destroyed");
        particle_on_object();

        Destroy(gameObject);
        //ChangeSprite();
    }

    private void ChangeSprite()
    {
        Debug.Log("Change Sprite");
        renderer.sprite = sprite;
    }

    public void particle_on_object(){
        particle.Play();

        }
}
