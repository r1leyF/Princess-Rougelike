using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //Weapon stats changed in editor
    public int damage;
    public int range;
    public float atkRate;
    public float knockback;
    public int weaponIndex;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playAnim()
    {
        animator.SetTrigger("attack");
        animator.SetTrigger("attack");
    }
}
