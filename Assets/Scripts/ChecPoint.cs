using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChecPoint : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D vollision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerRespawn>().ReachedCheckPoint(transform.position.x,transfor.position.y);
        }
    }
}
