using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessionBehaviour : MonoBehaviour
{
    GameObject player;
    public GameObject possedGameobject;
    Transform wayPoint;
    [SerializeField] float speed;


    bool toPosses;
    bool hover;
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        if (possedGameobject == null)
        {
            possedGameobject = GameObject.FindGameObjectWithTag("Controlable");
        }
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            wayPoint = player.transform;
        }

        toPosses = false;
    }

    private void FixedUpdate()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

        if ((wayPoint.position - transform.position).sqrMagnitude < 0.1f) toPosses = true;
        

        if (Input.GetMouseButtonDown(0) && hover == true)
        {
            if ((wayPoint.position - transform.position).sqrMagnitude < 2f){
                StopAllCoroutines();
                StartCoroutine(MoveTo(transform.position, speed));
                hover = false;
            }    
        }

        if (toPosses)
        {
            Posses();
        }
    }

    private void OnMouseOver()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        Debug.Log("Mouse Over Something");
        hover = true;
    }

    IEnumerator MoveTo(Vector2 destination, float speed)
    {
        while ((wayPoint.position - transform.position).sqrMagnitude > 0.05f)
        {
            wayPoint.position = Vector2.MoveTowards(wayPoint.position, destination, speed * Time.deltaTime);
            yield return null;
        }
    }

    void Posses()
    {
        GameObject instPossesed = Instantiate(possedGameobject, transform.position, Quaternion.identity);
        Destroy(gameObject);
        player.SetActive(false);
    }
}
