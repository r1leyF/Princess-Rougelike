using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Slim : MonoBehaviour
{
    //floats
    private float coolDown = .5f;


    //gameobject
    public GameObject floorSlime;
    public NavMeshAgent agent;
    GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    public float wanderRadius;
    public float wanderTimer;

    private Transform target;
    private float timer;

    // Use this for initialization
    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    // Update is called once per frame
    void Update()
    {
        coolDown -= Time.deltaTime;
        if (coolDown < 0)
        {
            Debug.Log("K");
            Instantiate(floorSlime, transform.position, transform.rotation);
            coolDown = .5f;
        }    
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }
    }
    void OnCollisionEnter(Collision otherObj)
    {
        Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
        agent.SetDestination(newPos);
        if (otherObj.gameObject.tag == "Player" && manager.gameRunning)
        {
            otherObj.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 5, ForceMode.Impulse);
            GetComponent<Enemy>().attack();
        }
    }
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}
