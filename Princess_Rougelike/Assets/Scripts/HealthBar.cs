using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    //currently unworking https://www.youtube.com/watch?v=yeFTUBm0PbM 7:33
    /*public static HealthBar instance;
    [SerializeField] GameObject heartContainerPrefab;
    [SerializeField] List<GameObject> heartContainers;

    int totalHearts;
    float currHearts;
    HeartContainer currContainer;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        heartContainers = new List<GameObject>();
    }

    public void SetupHearts(int heartsIn)
    {
        heartContainers.Clear();

        for (int i = transform.childCount - 1; i >= 1; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        totalHearts = heartsIn;
        currHearts = (float)totalHearts;
        for(int i = 0; i < totalHearts; i++)
        {
            GameObject current = Instantiate(heartContainerPrefab, transform);
            heartContainers.Add(current);

            if(currContainer != null)
            {
                currContainer.next = current.GetComponent<HeartContainer>();
            }
            currContainer = current.GetComponent<HeartContainer>();
        }
        currContainer = heartContainers[0].GetComponent<HeartContainer>();
    }*/
}
