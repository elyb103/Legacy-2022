using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleAiMovement : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent agent;

    [SerializeField] Transform[] moveSpots;
    public float speed;
    public float startWaitTime;

    private int randomSpot;
    private float waitTime;
    private float stalltime = 0;
    private float oldx;




    // public Transform player;
    private Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = other.transform;
            Debug.Log(target.position);


        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = null;

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        oldx = transform.position.x;

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        rb = this.GetComponent<Rigidbody2D>();
        target = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (oldx > transform.position.x)
        {
            rb.rotation = 0;
        }
        else if (oldx < transform.position.x)
        {
            rb.rotation = 180;
        }
        if (target != null)
        {
            if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) > 0.4f)
            {
                agent.SetDestination(target.position);
            }
            if (stalltime <= 0)
            {
                stalltime = 10;
            }

        }

        else
        {
            if (stalltime > 0)
            {
                stalltime -= Time.deltaTime;
            }
            else
            {
                agent.SetDestination(moveSpots[randomSpot].position);
                // transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

                if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
                {
                    if (waitTime <= 0)
                    {
                        waitTime = startWaitTime;
                        randomSpot = Random.Range(0, moveSpots.Length);
                        Debug.Log(moveSpots[randomSpot]);

                    }
                    else
                    {
                        waitTime -= Time.deltaTime;
                    }

                }

            }

        }

        oldx = transform.position.x;



    }



}



/*
bool CanSeePlayer(float distance)
{
    bool val = false;
    float castDist = distance;

    Vector2 endPos = Castpoint.position + Vector3 * distance
        RaycastHit2D hit = Physics2D.Linecast(castPoint, endPos, 1 << LayerMask.NameToLayer("Action"));

    if (hit.collider != null)
    {
        if (hit.collider.gameObject.CompareTag("Player"))
        {
            //Agro Enemy
            var agentDestination = target.posistion
            }
        else
        {
            if (agentDestination != null)
            {

            }
        }
    }
}
*/

