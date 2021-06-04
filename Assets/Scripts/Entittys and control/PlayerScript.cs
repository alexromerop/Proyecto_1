using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerScript : MonoBehaviour
{
    public ControlScript control;
    public float speed;
    public GameObject player;
    public GameObject Info_to_show;

    public enum Possesions
    {
        Rat,
        Skeleton,
        Zombie
    }
    void Update()
    {
        if (Input.GetKeyDown("g")|| control.CurrentControl.GetComponent<Player_movment>().Health<=0)
        {
            /*if(control.CurrentControl.GetComponent<Player_movment>().Health <= 0)
            {
                //Destroy(control.CurrentControl);
                Destroy(control.CurrentControl);
            }*/
            control.CurrentControl.GetComponent<Animator>().SetBool("Possesed", false);
            StartCoroutine(UnPosses());
            //player.transform.position = control.transform.position;
        }
    }
    void OnMouseDown()
    {
        control.Posses(gameObject);
        gameObject.GetComponent<Scr_unpossesed>().enabled = true;

        GetComponent<Player_movment>().enabled = true;
        player.SetActive(false);
    }
    IEnumerator UnPosses()
    {
        yield return new WaitForSeconds(0.4f);
        control.UnPosses();
        control.CanControl[0].GetComponent<Player_movment>().enabled = true;
    }
}
