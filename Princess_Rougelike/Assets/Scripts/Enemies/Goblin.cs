using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Goblin : MonoBehaviour
{
    //float
    private float coolDown = 3;
    private float jumpDistance = 25;
    private float speed = 4;
    private float heatlh = 10;
    private float attackDistance = 25;

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

    }

    void Update()
    {
        coolDown = coolDown - Time.deltaTime;
        //Debug.Log(coolDown);
        if (GameObject.Find("GameManager").GetComponent<GameManager>().gameRunning)
        {
            followPlayer();
            float distance = Vector3.Distance(transform.position,player.transform.position);
            if ( distance <= attackDistance)
            {
                
            }
            Jump();
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
            coolDown = 3;
        }

    }
    void followPlayer()
    {
        transform.LookAt(player.transform.position);
        agent.SetDestination(player.transform.position);
    }
}
