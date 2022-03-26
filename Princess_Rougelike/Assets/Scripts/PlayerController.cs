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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        

    }
    private void FixedUpdate()
    {
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
        if(Time.time <= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0) && player.currWeapon != null)
            {
                player.Attack();
                //attack cooldown
                nextAttackTime = Time.time + 1 / player.currWeapon.GetComponent<Weapon>().atkRate;
            }
        }
    }
    
}
