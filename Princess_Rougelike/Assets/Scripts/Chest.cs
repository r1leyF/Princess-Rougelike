using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public int itemIndex;
    public bool isEmpty = false;
    public bool opened = false;
    public Animator animator;
    GameManager manager;

    public AudioClip open;
    public AudioClip pickUp;
    AudioSource chestAudio;
    // Start is called before the first frame update
    void Start()
    {
        //gets a reference to the GameManager script
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        chestAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!opened && other.CompareTag("Player"))
        {
            chestAudio.PlayOneShot(open,2);
            animator.SetTrigger("Opened");
            opened = true;
        }
        //checks if the collision is with the player and if the chest is empty before switing items
        if (!isEmpty && other.CompareTag("Player"))
        {
            //get a reference to the PLayer script
            Player player = other.gameObject.GetComponent<Player>();

            //sets weapon using the weapons array
            player.SetWeapon(manager.allWeapons[itemIndex], this);

            chestAudio.PlayOneShot(pickUp, 1);
            //checks if it has been emptied
            if(itemIndex < 0)
            {
                isEmpty = true;
            }
            else
            {
                if(transform.childCount > 1)
                {
                    Destroy(transform.GetChild(1).gameObject);
                }
                Instantiate(manager.allWeapons[itemIndex], transform.position + new Vector3(0,0.5f,0.3f), transform.rotation, transform);
            }
        }
    }
}
