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
        
        transform.position = new Vector3(transform.position.x + Random.Range(-15f, 15f), 0.0f, transform.position.z + Random.Range(-9f, 9f));
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {

            Destroy(gameObject);
        }
        if (dead)
        {
            transform.Translate(Vector3.down * 5 * Time.deltaTime);
        }

    }


    //enemy hits player

    void Movment()
    {
        //rotate bullets twards player
        playerPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
 

        //moves bullets
        
        //transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    public void attack()
    {
        playerScipt.damage(damage);
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
        if (CompareTag("Goblin") || CompareTag("Boss"))
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
            if (CompareTag("Goblin") || CompareTag("Boss"))
            {
                enemyAudio.PlayOneShot(goblinDie, 1);
            }
            //prevents player from hitting an alreday dead enemy and incrementing the enemy count
            if (!dead)
            {
                manager.enemyCount--;
            }
            StartCoroutine(die());
        }
    }
    IEnumerator die()
    {
        Debug.Log("k");
        yield return new WaitForSeconds(.1f);
        Debug.Log("Dead");
        dead = true;
    }
}
