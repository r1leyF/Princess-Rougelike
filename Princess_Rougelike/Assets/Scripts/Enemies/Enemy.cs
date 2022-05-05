using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //floats
    public float heatlh = 3;


    // Start is called before the first frame update
    void Start()
    {

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
