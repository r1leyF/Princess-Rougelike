using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrapDoor : MonoBehaviour
{
    public Animator animator;
    public Transform spawnPoint;
    public GameObject boss;

    GameManager manager;
    LevelLoader loader;
<<<<<<< Updated upstream
    SpawnManager spawnManager;
=======
    public bool lastTrapDoor;
>>>>>>> Stashed changes
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        loader = GameObject.Find("LevelLoad").GetComponent<LevelLoader>();
        spawnManager = GameObject.Find("SpawnMangerr").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Open(Transform player)
    {
        animator.SetTrigger("Open");

        manager.gameRunning = false;

        yield return new WaitForSeconds(1);

        manager.level++;

<<<<<<< Updated upstream
        loader.StartTransition();
        yield return new WaitForSeconds(2);
        player.position = spawnPoint.position;
        Debug.Log("good");
        Instantiate(boss, spawnPoint.position, transform.rotation);
        Debug.Log("okay");
        yield return new WaitForSeconds(0.5f);
        manager.gameRunning = true;
        loader.EndTransition();
        Debug.Log("This is level 2");
=======
        if (!lastTrapDoor)
        {
            loader.StartTransition();
            yield return new WaitForSeconds(2);
            player.position = spawnPoint.position;
            yield return new WaitForSeconds(0.5f);
            manager.gameRunning = true;
            loader.EndTransition();
        }
        else
        {
            loader.LoadLevel(2);
        }
        
>>>>>>> Stashed changes
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Open(other.transform));
        }
    }
}
