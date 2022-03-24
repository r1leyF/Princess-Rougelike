using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 5;
    public int currHealth;
    public GameObject currWeapon;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    Weapon wpnInfo;
    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetWeapon(GameObject weapon, Chest chest)
    {
        //checks if the player already has a weapon
        if(currWeapon != null)
        {
            wpnInfo = currWeapon.GetComponent<Weapon>();
            //should change to put weapon back in chest
            Destroy(currWeapon);
        }

        //instantiates weapon prefab and assighs it to currWeapon
        currWeapon = Instantiate(weapon, transform.GetChild(0).GetChild(1).transform.position, transform.GetChild(0).rotation, transform.GetChild(0));


    }

    //expects player to have a weapon
    public void Attack()
    {

        //play attack animation

        //gets the Weapon class from player's current weapon
        wpnInfo = currWeapon.GetComponent<Weapon>();

        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, wpnInfo.range, enemyLayers);

        foreach(Collider enemy in hitEnemies)
        {
            //damage enemy && do knock back
            //enemy.damage(wpnInfo.damage)
            Debug.Log("we hit" + enemy.name);
        }
    }

    //draws a circle around the attack range
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null || currWeapon == null)
            return;
        wpnInfo = currWeapon.GetComponent<Weapon>();
        Gizmos.DrawWireSphere(attackPoint.position, wpnInfo.range);
    }
}
