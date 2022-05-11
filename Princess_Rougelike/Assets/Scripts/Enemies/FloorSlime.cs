using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSlime : MonoBehaviour
{
    //floats
    private float heatlh = 3;

    //scpits
    Player playerScipt;

    //gameobject
    public GameObject slime;

    // Start is called before the first frame update
    void Start()
    {
        //finds player
        playerScipt = GameObject.Find("Player").GetComponent<Player>();

        //finds slime
        slime = GameObject.Find("Slime");

        transform.position = new Vector3 (slime.transform.position.x, slime.transform.position.y, slime.transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        heatlh -= Time.deltaTime;
        Debug.Log(heatlh);
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
