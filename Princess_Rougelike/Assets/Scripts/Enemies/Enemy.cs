using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //floats
    public float heatlh;
    public float speed;

    //int
    public int damage;

    //scpits
    Player playerScipt;

    //game objectt
    public GameObject player;

    //vecotr 3
    private Vector3 playerPosition;


    // Start is called before the first frame update
    void Start()
    {
        //gets player shit
        player = GameObject.Find("Player");
        playerScipt = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Movment();
    }

    //enemy hits player
    void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Player")
        {
            playerScipt.damage(damage);

        }
    }

    void Movment()
    {
        //rotate bullets twards player
        playerPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(playerPosition);

        //moves bullets
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
}
