using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessedEnemy : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            Unposses();
        }
    }
     
    void Unposses()
    {
        GameObject instEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        //player.transform.position = SetPlayerPosition(transform.position);
        //player.SetActive(true);
        GameObject instPlayer = Instantiate(player, SetPlayerPosition(transform.position), Quaternion.identity);
        
        Destroy(gameObject);
    }
    Vector3 SetPlayerPosition(Vector3 startPosition)
    {
        return startPosition + new Vector3(0,0.3f,0);
    }
}
