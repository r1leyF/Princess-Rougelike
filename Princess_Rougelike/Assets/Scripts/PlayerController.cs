using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;
    public float speed;
    public Player player;
    float nextAttackTime = 0f;
    public static bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if (Time.time >= nextAttackTime && canMove)
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
        if (canMove)
        {
            transform.Translate(Vector3.right.normalized * horizontalInput * Time.deltaTime * speed);
            transform.Translate(Vector3.forward.normalized * verticalInput * Time.deltaTime * speed);
        }
    }
    
}
