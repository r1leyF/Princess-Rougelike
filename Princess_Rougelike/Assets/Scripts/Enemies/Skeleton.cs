using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    //floats
    private float coolDown = 1;

    //gameobject
    public GameObject player;
    public GameObject bone;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Movment();
        coolDown -= Time.deltaTime;
        if (coolDown < 0)
        {
            Instantiate(bone, transform.position, Quaternion.identity);
            coolDown = 2;
        }
    }
}