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
    private float stalltime = 4;

    

    // public Transform player;
    private Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = other.transform;


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

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        rb = this.GetComponent<Rigidbody2D>();
        target = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
            Vector3 direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;

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
    }
}
