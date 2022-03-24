using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject item;
    public bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (!isOpen && other.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();
            player.SetWeapon(item);
            isOpen = true;
        }
    }
}
