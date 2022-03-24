using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 5;
    public int currHealth;
    public GameObject currWeapon;
    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetWeapon(GameObject weapon)
    {
        if(currWeapon != null)
        {
            Destroy(currWeapon);
        }
        currWeapon = Instantiate(weapon, transform.GetChild(0).GetChild(1).transform.position, transform.GetChild(0).rotation, transform.GetChild(0));


    }
}
