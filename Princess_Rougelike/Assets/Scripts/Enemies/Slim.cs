using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slim : MonoBehaviour
{
    //floats
    private float speed = 2;
    private float heatlh = 3;
    private float coolDOwn = 3;

    private int damgae = 1;

    private bool idk = false;

    //vector3
    private Vector3 playerPosition;

    //gameobject
    //public GameObject player;
    public GameObject floorSlime;

    //scpits
    //Player playerScipt;
    Enemy enemyScript;


    // Start is called before the first frame update
    void Start()
    {
        //finds player
        //player = GameObject.Find("Player");
        //playerScipt = GameObject.Find("Player").GetComponent<Player>();

        //finds player
        enemyScript = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();

        enemyScript.speed = speed;
        enemyScript.heatlh = heatlh;
        enemyScript.damage = damgae;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown
        if(!idk)
        {
            //Movment();
            Instantiate(floorSlime);
        }
    }
    /*
    //moves and rotates the player
    void Movment()
    {
        //rotate bullets twards player
        playerPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(playerPosition);

        //moves slime
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    // enemy takes damage
    public void TakeDamage(float dmg)
    {
        heatlh = heatlh - dmg;
        Debug.Log(heatlh);
        if (heatlh <= 0)
        {
            Destroy(gameObject);
        }
    }
    */
    void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "FloorSlime")
        {
            idk = true;

        }
        else
        {

        }
    }
    
}