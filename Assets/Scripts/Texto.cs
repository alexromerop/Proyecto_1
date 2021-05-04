using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Texto : MonoBehaviour
{
    string frase = "En el mundo de la discordia, Pan Ku es el encargado de restablecer el orden. Encuentra los orbes del equilibrio.";
    public Text texto;

    [SerializeField] Player_movment movement;
    private static bool isCalled;
    // Start is called before the first frame update
    private void Awake()
    {

    }
    void Start()
    {
        //movement = GetComponent<Player_movment>();
        if (!isCalled)
        {
            StartCoroutine(Reloj());
            StartCoroutine(Wait());
        }
        else
        {
            
        }
    }

    IEnumerator Reloj()
    {
        foreach (char caracter in frase)
        {
            texto.text = texto.text + caracter;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(14f);
        texto.gameObject.SetActive(false);
        
        isCalled = true;
    }
}