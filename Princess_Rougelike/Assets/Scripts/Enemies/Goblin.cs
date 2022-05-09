using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    //floats
    private float speed = 2;
    private float jump = 10;
    private float coolDown = 3;
    private float heatlh = 3;

    private int damgae = 1;

    /*
    //vector3
    private Vector3 playerPosition;

    //gameobject
    public GameObject player;
    */

    //scpits
    Enemy enemyScript;
    
    // Start is called before the first frame update
    void Start()
    {
        //finds player
        enemyScript = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();

        enemyScript.speed = speed;
        enemyScript.heatlh = heatlh;
        enemyScript.damage = damgae;

    }
    /*
    // Update is called once per frame
    void Update()
    {
        coolDown -= Time.deltaTime;
        if(coolDown > 0)
        {
            Movment();
        }
        else
        {
            Jump();
            if(coolDown < -0.3)
            {
                coolDown = 3;
            }
        }
        //Debug.Log(coolDown);
    }
    
    //moves and rotates the player
    void Jump()
    {
        //rotate bullets twards player
        //playerPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        //transform.LookAt(playerPosition);

        //moves bullets
        transform.Translate(Vector3.forward * Time.deltaTime * jump);
    }
    
    //moves and rotates the player
    void Movment()
    {
        //rotate bullets twards player
        playerPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(playerPosition);

        //moves bullets
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    // enemy takes damage
    /*
    public void TakeDamage(float dmg)
    {
        heatlh = heatlh - dmg;
        Debug.Log(heatlh);
        if(heatlh <= 0)
        {
            Destroy(gameObject);
        }
    }    
    
    //enemy hits player
    void OnCollisionEnter(Collision otherObj)
    {
        if(otherObj.gameObject.tag == "Player")
        {
            playerScipt.damage(1);

        }
    }
    */
}
