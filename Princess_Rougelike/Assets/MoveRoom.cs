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
            }
        }
    }
}
