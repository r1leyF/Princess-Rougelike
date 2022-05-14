using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slim : MonoBehaviour
{
    //floats
    private float coolDown = 0.5f;


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
            Instantiate(floorSlime);
            coolDown = 0.5f;
        }
    }

}