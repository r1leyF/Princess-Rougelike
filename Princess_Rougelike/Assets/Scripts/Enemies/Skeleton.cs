using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{
    //floats
    private float coolDown = 1;
    private float runAwayDistance = 10;
    private float speed = 4;
    public NavMeshAgent agent;

    //gameobject
    public GameObject player;
    public GameObject bone;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(coolDown);
        if (GameObject.Find("GameManager").GetComponent<GameManager>().gameRunning)
        {
            transform.LookAt(player.transform.position);
            float distance = Vector3.Distance(transform.position, player.transform.position);
            //Movment();
            coolDown -= Time.deltaTime;
            if (coolDown < 0)
            {
                Debug.Log("shoot");
                Instantiate(bone, transform.position + transform.forward * 2, Quaternion.identity);
                coolDown = 2;
            }
            if (distance <= runAwayDistance)
            {
                runAway();
            }
            else
            {
                agent.isStopped = false;
                followPlayer();

            }
        }

    }

    void runAway()
    {
        Vector3 dirToPlayer = transform.position - player.transform.position;
        agent.SetDestination(transform.position + dirToPlayer);
    }
    void followPlayer()
    {
        agent.SetDestination(player.transform.position);
    }
}