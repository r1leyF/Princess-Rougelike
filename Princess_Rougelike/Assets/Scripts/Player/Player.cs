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
    GameManager gameManager;
    Goblin goblin;

    public string hitenemy;
    // Start is called before the first frame update
    void Start()
    {
        goblin = GameObject.Find("goblin").GetComponent<Goblin>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        currHealth = maxHealth;
        HealthBar.instance.SetupHearts(currHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }
    //set the weapon of a player when interacting with a chest
    public void SetWeapon(GameObject weapon, Chest chest)
    {
        //checks if the player already has a weapon
        if(currWeapon != null)
        {
            wpnInfo = currWeapon.GetComponent<Weapon>();
            
            //changes the chests item to whatever the player was holding
            chest.itemIndex = wpnInfo.weaponIndex;

            //destroys the players old weapon
            Destroy(currWeapon);
        }
        //if the player didn't have a weapon make the chest empty
        else
        {
            chest.itemIndex = -1;
        }

        //instantiates weapon prefab and assighs it to currWeapon
        currWeapon = Instantiate(weapon, transform.GetChild(0).GetChild(0).transform.position, transform.GetChild(0).rotation, transform.GetChild(0));


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
            //exp - enemy.damage(wpnInfo.damage)
            Debug.Log("we hit " + enemy.name);
            hitenemy = enemy.name;
            //goblin.TakeDamage(wpnInfo.damage);
        }
    }

    public void damage(int dmg)
    {
        currHealth -= dmg;
        HealthBar.instance.RemoveHearts(dmg);
        if(currHealth <= 0)
        {
            gameManager.gameOver();
        }
    }

    //draws a sphere around the attack range for easy editing
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null || currWeapon == null)
            return;
        wpnInfo = currWeapon.GetComponent<Weapon>();
        Gizmos.DrawWireSphere(attackPoint.position, wpnInfo.range);
    }
}
