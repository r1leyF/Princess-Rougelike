using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrapDoor : MonoBehaviour
{
    public Animator animator;
    public Transform spawnPoint;
    GameManager manager;
    LevelLoader loader;
    public AudioSource doorAudio;
    public AudioClip open;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        loader = GameObject.Find("LevelLoad").GetComponent<LevelLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Open(Transform player)
    {
        manager.gameRunning = false;

        yield return new WaitForSeconds(1);

        manager.level++;

        loader.StartTransition();
        yield return new WaitForSeconds(2);
        player.position = spawnPoint.position;
        yield return new WaitForSeconds(0.5f);
        manager.gameRunning = true;
        loader.EndTransition();
        Debug.Log("This is level 2");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetTrigger("Open");
            doorAudio.PlayOneShot(open, 2);
            StartCoroutine(Open(other.transform));
        }
    }
}
