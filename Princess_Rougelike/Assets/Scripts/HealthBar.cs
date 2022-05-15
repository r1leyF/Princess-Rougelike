using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public static HealthBar instance;
    [SerializeField] GameObject heartContainerPrefab;
    [SerializeField] List<GameObject> heartContainers;

    float totalHearts;
    float currHearts;
    HeartContainer currContainer;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        heartContainers = new List<GameObject>();
    }

    public void SetupHearts(float heartsIn)
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
            GameObject newHeart = Instantiate(heartContainerPrefab, transform);
            heartContainers.Add(newHeart);

            if(currContainer != null)
            {
                currContainer.next = newHeart.GetComponent<HeartContainer>();
            }
            currContainer = newHeart.GetComponent<HeartContainer>();
        }
        currContainer = heartContainers[0].GetComponent<HeartContainer>();
    }

    //manually set health to a specific value
    public void SetCurrentHealth(float health)
    {
        currHearts = health;
        currContainer.SetHeart(currHearts);
    }

    //add a specified amount of health
    public void AddHearts(float healthUp)
    {
        currHearts += healthUp;
        if(currHearts > totalHearts)
        {
            currHearts = (float)totalHearts;
        }
        currContainer.SetHeart(currHearts);
    }

    //remove a specified amount of health
    public void RemoveHearts(float healthDown)
    {
        currHearts -= healthDown;
        if(currHearts < 0)
        {
            currHearts = 0f;
        }
        currContainer.SetHeart(currHearts);
    }

    //add a heart and set player to full health
    public void AddContainer()
    {
        GameObject newHeart = Instantiate(heartContainerPrefab, transform);
        currContainer = heartContainers[heartContainers.Count - 1].GetComponent<HeartContainer>();
        heartContainers.Add(newHeart);

        if(currContainer != null)
        {
            currContainer.next = newHeart.GetComponent<HeartContainer>();
        }
        currContainer = heartContainers[0].GetComponent<HeartContainer>();

        totalHearts++;
        currHearts = totalHearts;
        SetCurrentHealth(currHearts);
    }
}
