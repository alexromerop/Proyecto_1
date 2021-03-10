using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Camara para moverte en sitios cerrados no atravesar paredes
public class CameraClamp: MonoBehaviour
{
    [SerializeField]
    public GameObject personaje;
    public float leftx = -5.0f;
    public float rightx  = 5.0f;
    public float upy = 3.0f;
    public float downy = 3.0f;

    


    void Update()
    {

        transform.position = new Vector4(
            Mathf.Clamp(personaje.transform.position.x, leftx, rightx),
            Mathf.Clamp(personaje.transform.position.y, upy, downy),
            transform.position.z);

            
         
    }
}