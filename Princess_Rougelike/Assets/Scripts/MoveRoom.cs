using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRoom : MonoBehaviour
{
    public Camera cam;
    public Transform camPoint;
    SpawnManager spawn;
    GameManager manager;
    public GameObject parent;
    public GameObject doors;
    // Start is called before the first frame update
    void Start()
    {
        cam = (Camera)FindObjectOfType(typeof(Camera));
        spawn = GameObject.Find("SpawnManger").GetComponent<SpawnManager>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(manager.enemyCount <= 0)
        {
            doors.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cam.transform.position = camPoint.position;
            if (parent.CompareTag("EnemyRoom"))
            {
                if(manager.level == 1)
                {
                    spawn.SpawnEnemies(3, 9, 1, 0, parent.transform);
                }
                else if (manager.level == 2)
                {
                    spawn.SpawnEnemies(5, 3, 7, 0, parent.transform);
                }
                else if (manager.level == 3)
                {
                    spawn.SpawnEnemies(5, 1, 2, 7, parent.transform);
                }
                parent.gameObject.tag = "Untagged";
                tpPlayer(other.transform);
                doors.SetActive(true);
            }

            if (parent.CompareTag("BossRoom"))
            {
                if (manager.level == 1)
                {
                    spawn.SpawnBoss(parent.transform);
                }
            }
        }
    }

    void tpPlayer(Transform player)
    {
        //enter from right
        if(player.position.x > transform.position.x && player.position.z < transform.position.z + 3 && player.position.z > transform.position.z - 3)
        {
            Debug.Log("right");
            player.Translate(new Vector3(- 2.7f, 0, 0));
        }
        //enter from left
        else if (player.position.x < transform.position.x && player.position.z < transform.position.z + 3 && player.position.z > transform.position.z - 3)
        {
            Debug.Log("left");
            player.Translate(new Vector3(2.7f, 0, 0));
        }
        //enter from top
        else if (player.position.z > transform.position.z && player.position.x < transform.position.x + 3 && player.position.x > transform.position.x - 3)
        {
            Debug.Log("top");
            player.Translate(new Vector3(0, 0, - 2.7f));
        }
        //enter from bottom
        else if (player.position.z < transform.position.z && player.position.x < transform.position.x + 3 && player.position.x > transform.position.x - 3)
        {
            Debug.Log("bottom");
            player.Translate(new Vector3(0, 0,  + 2.7f));
        }
    }
}
