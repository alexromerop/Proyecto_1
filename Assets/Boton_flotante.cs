using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton_flotante : MonoBehaviour
{
    public float Life_time = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Life_time -= Time.deltaTime;
        if (Life_time <= 0)
        {
            Destroy(this.gameObject);
        }

        if (transform.parent.localScale.x==1&&this.transform.parent.localScale.x ==-0.3) {
            this.transform.localScale = new Vector3(0.3f, 0.3f, 1f);
        }
        if (transform.parent.localScale.x == -1 && this.transform.parent.localScale.x == 0.3)
        {
            this.transform.localScale = new Vector3(-0.3f, 0.3f, 1f);
        }
    }
}
