using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slim : MonoBehaviour
{
    //floats
    private float coolDown = 1f;


    //gameobject
    public GameObject floorSlime;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        coolDown = coolDown - Time.deltaTime;
        if (coolDown <= 0)
        {
            //Movment();
            Instantiate(floorSlime, transform.position, Quaternion.identity);
            coolDown = 1;
        }
    }

}