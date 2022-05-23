using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //floats
    public float heatlh;
    public float speed;
    public float damage;
    public float pickUpDropChance;

    //bool
    bool dead = false;

    //scpits
    Player playerScipt;
    GameManager manager;

    //game objectt
    public GameObject player;
    public GameObject[] pickUps;

    //vecotr 3
    private Vector3 playerPosition;

    //audio clips
    public AudioClip slimeHurt;
    public AudioClip slimeDie;
    public AudioClip ghostHurt;
    public AudioClip ghostDie;
    public AudioClip goblinHurt;
    public AudioClip goblinDie;
    public AudioClip bossHurt;
    public AudioClip bossDie;

    AudioSource enemyAudio;


    // Start is called before the first frame update
    void Start()
    {
        //gets player shit
        player = GameObject.Find("Player");
        playerScipt = GameObject.Find("Player").GetComponent<Player>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        enemyAudio = GetComponent<AudioSource>();

        if (!CompareTag("Boss"))
        {
            transform.position = new Vector3(transform.position.x + Random.Range(-15f, 15f), 0.0f, transform.position.z + Random.Range(-9f, 9f));
        }
        if (CompareTag("Boss"))
        {
            manager.SetUpHealth(heatlh);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }


    //enemy hits player

    public void attack()
    {
        playerScipt.damage(damage);
    }
    // enemy takes damage
    public void TakeDamage(float dmg)
    {
        heatlh = heatlh - dmg;
        if (CompareTag("Boss"))
        {
            manager.SetHealthBar(heatlh);
        }
        //make sound based on tag
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
        if (CompareTag("Boss"))
        {
            enemyAudio.PlayOneShot(bossHurt, 1);
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
            if (CompareTag("Boss"))
            {
                enemyAudio.PlayOneShot(bossDie, 1);
            }
            //prevents player from hitting an alreday dead enemy and incrementing the enemy count
            if (!dead)
            {
                manager.enemyCount--;
            }
            dead = true;
            StartCoroutine(die());
        }
    }
    IEnumerator die()
    {
        yield return new WaitForSeconds(.2f);
        int randInt = Random.Range(1, 100);
        if (randInt <= pickUpDropChance)
        {
            Instantiate(pickUps[0], new Vector3(transform.position.x, transform.position.y + 0.9462098f, transform.position.z), transform.rotation);
        }
        Destroy(gameObject);
        if (CompareTag("Boss"))
        {
            manager.GameWin();
        }
    }
}
