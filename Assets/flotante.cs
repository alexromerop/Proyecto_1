using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flotante : MonoBehaviour
{
    private float LastShoot;
    public GameObject Info_to_show;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseOver()
    {
        if (this.gameObject.tag.Equals("Controlable"))
        {
            if (Time.time > LastShoot + 2f)
            {
                GameObject boton = Instantiate(Info_to_show);
                boton.gameObject.transform.parent = this.gameObject.transform;
                boton.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x,
                    this.gameObject.transform.position.y + 0.35f, this.gameObject.transform.position.z);


                LastShoot = Time.time;
            }
        }

    }
    private void OnMouseDown()
    {
        if(this.gameObject.tag.Equals("Enemy"))
        {
            if (Time.time > LastShoot + 2f)
            {
                GameObject boton = Instantiate(Info_to_show);
                boton.gameObject.transform.parent = this.gameObject.transform;
                boton.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x,
                    this.gameObject.transform.position.y + 0.35f, this.gameObject.transform.position.z);


                LastShoot = Time.time;
            }
        }
    }
}
