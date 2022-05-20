using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;
    public float speed;
    public Player player;
    public Animator animator;
    GameManager manager;
    float nextAttackTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if (Time.time >= nextAttackTime && manager.gameRunning)
        {
            if (Input.GetMouseButtonDown(0) && player.currWeapon != null)
            {
                player.Attack();
                //attack cooldown
                nextAttackTime = Time.time + 1 / player.currWeapon.GetComponent<Weapon>().atkRate;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.damage(1);
        }
    }
    private void FixedUpdate()
    {
        if (manager.gameRunning)
        {
            if(horizontalInput != 0 || verticalInput != 0)
            {
                animator.SetBool("moving", true);
            }
            else
            {
                animator.SetBool("moving", false);
            }
            transform.Translate(Vector3.right.normalized * horizontalInput * Time.deltaTime * speed);
            transform.Translate(Vector3.forward.normalized * verticalInput * Time.deltaTime * speed);
        }
    }
    
}
