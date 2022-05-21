using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] allWeapons;
    public GameObject[] allItems;
    public GameObject gameOverScreen;
    public bool gameRunning = true;
    public int enemyCount;
    public int level;
    LevelLoader loader;
    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.SetActive(false);
        level = 1;
        loader = GameObject.Find("LevelLoad").GetComponent<LevelLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameOver()
    {
        gameRunning = false;
        gameOverScreen.SetActive(true);
    }
    public void restart()
    {
        loader.LoadLevel(0);
    }

}
