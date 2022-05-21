using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool left;
    public bool right;
    public bool top;
    public bool bot;
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

        if (other.CompareTag("Player"))
        {
            if (left)
            {
                other.gameObject.transform.Translate(new Vector3(transform.position.x - 22f, other.transform.position.y, other.transform.position.z));
            }
            if (right)
            {
                other.gameObject.transform.Translate(new Vector3(transform.position.x + 22f, other.transform.position.y, other.transform.position.z));
            }
            if (top)
            {
                other.gameObject.transform.Translate(new Vector3(other.transform.position.x, other.transform.position.y, transform.position.z + 13.5f));
            }
            if (bot)
            {
                other.gameObject.transform.Translate(new Vector3(other.transform.position.x, other.transform.position.y, transform.position.z - 13.5f));
            }
        }
    }
}
