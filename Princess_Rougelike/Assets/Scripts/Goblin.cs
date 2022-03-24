using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    //floats
    private float speed = 2;
    private float jump = 10;
    private float coolDown = 30;

    //vector3
    private Vector3 playerPosition;

    //gameobject
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //finds player
        player = GameObject.Find("Player");
    }

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
            if(coolDown < -2)
            {
                coolDown = 30;
            }
        }
        Debug.Log(coolDown);
    }
    
    //moves and rotates the player
    void Jump()
    {
        //rotate bullets twards player
        playerPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(playerPosition);

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
}
