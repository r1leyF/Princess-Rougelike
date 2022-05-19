using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : MonoBehaviour
{
    //floats
    private float speed = 10;

    //scpits
    Player playerScipt;

    //gameobject
    public GameObject skeleton;
    public GameObject player;

    //vector 3
    private Vector3 playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        //finds player
        player = GameObject.Find("Player");
        playerScipt = GameObject.Find("Player").GetComponent<Player>();

        //finds slime
        skeleton = GameObject.Find("Ghost");

        playerPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(playerPosition);        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    void Jump()
    {
        //moves bullets
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Player")
        {
            playerScipt.damage(1);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

