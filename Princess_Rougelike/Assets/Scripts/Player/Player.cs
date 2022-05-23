using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 5;
    public float currHealth;
    public float invincibilityDurationSeconds = .5f;
    public GameObject currWeapon;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    Weapon wpnInfo;
    GameManager gameManager;
    Enemy monster;
    Enemy enemin;
    private bool isInvincible;
    public AudioClip swoosh;
    public AudioClip hurt;
    public AudioClip died;

    private AudioSource playerAudio;

    public string hitenemy;
    // Start is called before the first frame update
    void Start()
    {
        //monster = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerAudio = GetComponent<AudioSource>();
        currHealth = maxHealth;
        //currHealth = 100;
        HealthBar.instance.SetupHearts(currHealth);
        isInvincible = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        //monster = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
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
    public void SetWeapon(GameObject weapon)
    {
        //checks if the player already has a weapon
        if (currWeapon != null)
        {
            Destroy(currWeapon);
        }

        //instantiates weapon prefab and assighs it to currWeapon
        currWeapon = Instantiate(weapon, transform.GetChild(0).GetChild(0).transform.position, transform.GetChild(0).rotation, transform.GetChild(0));
    }
    //expects player to have a weapon
    public void Attack()
    {
        Debug.Log("attack");
        playerAudio.PlayOneShot(swoosh, 3);

        //gets the Weapon class from player's current weapon
        wpnInfo = currWeapon.GetComponent<Weapon>();

        //plays animation
        wpnInfo.playAnim();

        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, wpnInfo.range, enemyLayers);

        foreach(Collider enemy in hitEnemies)
        {
            //damage enemy && do knock back
            Debug.Log("we hit " + enemy.name);
            enemin = enemy.GetComponent<Enemy>();
            enemin.TakeDamage(wpnInfo.damage);
        }
    }

    public void damage(float dmg)
    {
        //doesn't do anything if the player is invincible
        if (isInvincible) return;
        playerAudio.PlayOneShot(hurt, 0.2f);
        currHealth -= dmg;
        HealthBar.instance.RemoveHearts(dmg);
        if(currHealth <= 0)
        {
            playerAudio.PlayOneShot(died, 0.2f);
            gameManager.GameOver();
        }
        StartCoroutine(BecomeTemporarilyInvincible());
    }
    private IEnumerator BecomeTemporarilyInvincible()
    {

        isInvincible = true;
        yield return new WaitForSeconds(invincibilityDurationSeconds);
        isInvincible = false;
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
