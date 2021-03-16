using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevat_button : MonoBehaviour
{

    public GameObject move_plataform;
    // Start is called before the first frame update
    private void OnTriggerStay()
    {
        move_plataform.transform.position += move_plataform.transform.up * Time.deltaTime;
    }

   
}
