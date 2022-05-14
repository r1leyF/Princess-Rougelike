using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    //float
    private float coolDown = 3;
    private float speed = 10;
    private float heatlh = 10;

    //game objectt
    public GameObject player;

    //vecotr 3
    private Vector3 playerPosition;


    // Start is called before the first frame update
    void Start()
    {
        //gets player 
        player = GameObject.Find("Player");

    }

    void Update()
    {
            coolDown = coolDown - Time.deltaTime;
        Debug.Log(coolDown);
        if(coolDown <0)
        {
            Jump();
        }

        if (coolDown <= -0.2f)
        {
            coolDown = 3;
        }

    }

    void Jump()
    {
        //rotate bullets twards player
        playerPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);

        //moves bullets
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
