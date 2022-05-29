using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemies;
    public GameObject boss;
    GameManager manager;
    private int enemySpawned;
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        /*for(int i = 0; i < 5; i++)
        {
            enemySpawned = Random.Range(0, 3);
            Instantiate(enemies[enemySpawned]);
        }*/
    }

    // Update is called once per frame
    void Update()
    {

    }

    //gobP - Percent goblin will show up   ghoP - Percent ghost will show up   sliP - Percent Slime will show up
    //eNum - the amount of enemies spawned
    public void SpawnEnemies(int eNum, int gobP, int ghoP, int sliP, Transform spawnPoint)
    {
        for (int i = 0; i < eNum; i++)
        {
            int rNum = Random.Range(1, 10);
            if (rNum >= 1 && rNum <= gobP)
            {
                Instantiate(enemies[2], new Vector3(spawnPoint.position.x, spawnPoint.position.y + 0.82f, spawnPoint.position.z), transform.rotation);
            }
            else if (rNum > gobP && rNum <= gobP + ghoP)
            {
                Instantiate(enemies[1], new Vector3(spawnPoint.position.x, spawnPoint.position.y + 0.82f, spawnPoint.position.z), transform.rotation);
            }
            else if (rNum > ghoP && rNum <= ghoP + sliP)
            {
                Instantiate(enemies[0], new Vector3(spawnPoint.position.x, spawnPoint.position.y + 0.82f, spawnPoint.position.z), transform.rotation);
            }
        }
        manager.enemyCount = eNum;
    }
    public void SpawnBoss(Transform spawnPoint)
    {
        Instantiate(boss, spawnPoint.position, transform.rotation);
        manager.EnterBoss();
    }
}
