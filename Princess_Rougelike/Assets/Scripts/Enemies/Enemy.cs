using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //floats
    public float heatlh;
    public float speed;
    public float damage;

    //bool
    bool dead = false;

    //scpits
    Player playerScipt;
    GameManager manager;

    //game objectt
    public GameObject player;

    //vecotr 3
    private Vector3 playerPosition;

    //audio clips
    public AudioClip slimeHurt;
    public AudioClip slimeDie;
    public AudioClip ghostHurt;
    public AudioClip ghostDie;
    public AudioClip goblinHurt;
    public AudioClip goblinDie;

    AudioSource enemyAudio;

    // Start is called before the first frame update
    void Start()
    {
        //gets player shit
        player = GameObject.Find("Player");
        playerScipt = GameObject.Find("Player").GetComponent<Player>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        enemyAudio = GetComponent<AudioSource>();

        transform.position = new Vector3(Random.Range(-18.21f, 18.34f), 0.0f, Random.Range(-7.71f, 11.11f));
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.gameRunning)
        {
            Movment();
        }
        if (transform.position.y < -3)
        {
            Destroy(gameObject);
        }
        if (dead)
        {
            transform.Translate(Vector3.down * 5 * Time.deltaTime);
        }

    }


    //enemy hits player
    void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Player" && manager.gameRunning)
        {
            playerScipt.damage(damage);
        }
    }

    void Movment()
    {
        //rotate bullets twards player
        playerPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(playerPosition);

        //moves bullets
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }


    // enemy takes damage
    public void TakeDamage(float dmg)
    {
        heatlh = heatlh - dmg;
        if (CompareTag("Slime"))
        {
            enemyAudio.PlayOneShot(slimeHurt, 1);
        }
        if (CompareTag("Ghost"))
        {
            enemyAudio.PlayOneShot(ghostHurt, 0.3f);
        }
        if (CompareTag("Goblin"))
        {
            enemyAudio.PlayOneShot(goblinHurt, 1);
        }
        Debug.Log(heatlh);
        if (heatlh <= 0)
        {
            if (CompareTag("Slime"))
            {
                enemyAudio.PlayOneShot(slimeDie, 1);
            }
            if (CompareTag("Ghost"))
            {
                enemyAudio.PlayOneShot(ghostDie, 0.3f);
            }
            if (CompareTag("Goblin"))
            {
                enemyAudio.PlayOneShot(goblinDie, 1);
            }
            dead = true;
        }
    }
}
