using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemies;

    private int enemiesSpawned;
    void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            enemiesSpawned = Random.Range(0, 3);
            Instantiate(enemies[enemiesSpawned]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
