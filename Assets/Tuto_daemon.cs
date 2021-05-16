using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Tuto_daemon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel;
    public GameObject Next_Daemon;

    /*

    public string[] Dialogo_Inicial;
    public string[] Dialogo_2;
    public string[] Dialogo_3;

    public Text txtDialogo;
    public bool Dialogo_activo;

    Coroutine aux_corutine;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Abrir_dialogo(int valor)
    {
        if (Dialogo_activo)
        {
            Cerrar_Dialogo();
            StartCoroutine()
        }


    }
   */

    private void Update()
    {
        if (Input.GetKeyDown("e"))
        {

            daemons_active();


        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") || collision.tag.Equals("Control")) {
           // panel.SetActive(true);
            //this.gameObject.SetActive(true);
        }
    }

   
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") || collision.tag.Equals("Control"))
        {

            daemons_active();
        }
    }

    private void daemons_active()
    {
        //efecto desaparecere
        panel.SetActive(false);
        this.gameObject.SetActive(false);
        //efecto aparecer
        Next_Daemon.SetActive(true);
    }
}
