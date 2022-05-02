using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slim : MonoBehaviour
{
    //floats
    private float speed = 2;
    private float heatlh = 3;

    //vector3
    private Vector3 playerPosition;

    //gameobject
    public GameObject player;
    public GameObject floorSlime;

    //scpits
    Player playerScipt;

    // Start is called before the first frame update
    void Start()
    {
        //finds player
        player = GameObject.Find("Player");
        playerScipt = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Movment();
        Instantiate(floorSlime);
    }    

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
    /*
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
    //enemy hits player
    void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Player")
        {
            playerScipt.damage(1);

        }
    }
}