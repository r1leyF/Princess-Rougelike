using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRoom : MonoBehaviour
{
    public Camera cam;
    public Transform camPoint;
    // Start is called before the first frame update
    void Start()
    {
        cam = (Camera)FindObjectOfType(typeof(Camera));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cam.transform.position = camPoint.position;
        }
    }
}
