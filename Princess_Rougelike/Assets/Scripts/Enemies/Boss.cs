using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    //float
    private float startCoolDown = .9f;
    private float coolDown;
    private float jumpDistance = 15;
    private float speed = 5;
    private float heatlh = 10;
    private float attackDistance = 12;
    private float gobilnCoolDown = 5;

    //game objectt
    public GameObject player;
    public GameObject goblin;
    UnityEngine.AI.NavMeshAgent agent;
    GameManager manager;

    //vecotr 3
    private Vector3 goblinSpawnPos;


    // Start is called before the first frame update
    void Start()
    {
        //gets player 
        player = GameObject.Find("Player");
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.speed = speed;
        coolDown = startCoolDown;
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Player" && manager.gameRunning)
        {
            otherObj.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 5, ForceMode.Impulse);
            GetComponent<Enemy>().attack();
        }
    }
    void Update()
    {
        //Debug.Log(coolDown);

        if (manager.gameRunning)
        {
            transform.LookAt(player.transform.position);
            float distance = Vector3.Distance(transform.position, player.transform.position);

            gobilnCoolDown = gobilnCoolDown - Time.deltaTime;
            if (gobilnCoolDown <= 0)
            {
                //Movment();
                goblinSpawnPos = new Vector3(Random.Range(-17.85f, 17.85f), 0, Random.Range(10.55f, -10.55f));
                Instantiate(goblin, transform.position, Quaternion.identity);
                gobilnCoolDown = 5;
            }

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
        if (coolDown <= -0.27f)
        {
            coolDown = startCoolDown;
        }

    }
    void followPlayer()
    {
        agent.SetDestination(player.transform.position);
    }
}
