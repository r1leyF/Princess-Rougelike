using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Goblin : MonoBehaviour
{
    //float
    private float startCoolDown = .5f;
    private float coolDown;
    private float jumpDistance = 32;
    private float speed = 4;
    private float heatlh = 10;
    private float attackDistance = 10;

    //game objectt
    public GameObject player;
    Rigidbody rb;
    NavMeshAgent agent;

    //vecotr 3
    private Vector3 playerPosition;


    // Start is called before the first frame update
    void Start()
    {
        //gets player 
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        coolDown = startCoolDown;

    }

    void Update()
    {
        //Debug.Log(coolDown);
        if (GameObject.Find("GameManager").GetComponent<GameManager>().gameRunning)
        {
            transform.LookAt(player.transform.position);
            float distance = Vector3.Distance(transform.position,player.transform.position);
            Debug.Log(distance);
            if (distance <= attackDistance)
            {
                agent.isStopped = true;
                coolDown = coolDown - Time.deltaTime;
                Jump();
            }
            else
            {
                agent.isStopped = false;
                followPlayer();

            }
        }

    }

    void Jump()
    {
        //rotate bullets twards player
        if (coolDown < 0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * jumpDistance);
        }
        if (coolDown <= -0.2f)
        {
            coolDown = startCoolDown;
        }

    }
    void followPlayer()
    {
        agent.SetDestination(player.transform.position);
    }
}
