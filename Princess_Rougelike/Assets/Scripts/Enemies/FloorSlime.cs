using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSlime : MonoBehaviour
{
    //floats
    private float heatlh = 3;

    //scpits
    public Player playerScipt;

    //gameobject
    public GameObject[] slime;

    public Slim slimeScript;

    // Start is called before the first frame update
    void Start()
    {
        //finds player
        playerScipt = GameObject.Find("Player").GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        heatlh -= Time.deltaTime;
        if (heatlh < 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Player")
        {
            playerScipt.damage(1);

        }
    }
}
