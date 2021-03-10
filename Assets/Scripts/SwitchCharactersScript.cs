using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharactersScript : MonoBehaviour
{
    //referencias al game Object

    public GameObject Prota, Enemy_Skeleton;


    public int whichAvatarIsOn = 1;



    private float LastSwitch;



     public void Start () 
    {
        Prota.gameObject.SetActive(true);
        Enemy_Skeleton.gameObject.SetActive(true);
    }

    public void SwitchAvatar()
    {
        switch (whichAvatarIsOn){
            //enemigo poseido
            case 1:

                //cambia a 2
                whichAvatarIsOn = 2;

                Prota.gameObject.SetActive(false);
                Enemy_Skeleton.gameObject.SetActive(true);
                break;

            case 2:

                whichAvatarIsOn = 1;

                Prota.gameObject.SetActive(true);
                Enemy_Skeleton.gameObject.SetActive(false);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.E) && Time.time> LastSwitch + 1f)
        {
            SwitchAvatar();
            LastSwitch = Time.time;
            
        }
    }
}
