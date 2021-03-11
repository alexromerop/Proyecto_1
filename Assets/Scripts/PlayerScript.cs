using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public ControlScript control;
    public enum Possesions
    {
        Rat,
        Skeleton,
        Zombie
    }
    void OnMouseDown()
    {
        control.Posses(this.gameObject);
        GetComponent<Player_movment>().enabled = true;
    }
}
