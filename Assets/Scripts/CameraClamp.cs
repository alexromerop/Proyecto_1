using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Camara para moverte en sitios cerrados no atravesar paredes
public class CameraClamp: MonoBehaviour
{
    [SerializeField]
    public GameObject personaje;
    public float _x = -5.0f;
    public float x  = 5.0f;
    public float _y = 3.0f;
    public float y = 3.0f;

    


    void Update()
    {

        transform.position = new Vector4(
            Mathf.Clamp(personaje.transform.position.x, _x, x),
            Mathf.Clamp(personaje.transform.position.y, _y, y),
            transform.position.z);

            
         
    }
}