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
    public Transform camTransform;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
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
        if(transform.position.y < -5)
        {
            player.damage(10);
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
                rb.velocity = new Vector3(0, 0, 0);
            }
            rb.velocity = new Vector3(horizontalInput * Time.deltaTime * speed * 50, 0, verticalInput * Time.deltaTime * speed * 50);
        }
    }
    
}
