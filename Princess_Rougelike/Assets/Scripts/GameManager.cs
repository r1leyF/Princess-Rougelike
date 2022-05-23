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
    public GameObject gameWinScreen;
    public GameObject bossTitle;
    public GameObject bossHealth;
    Slider slider;
    public bool gameRunning = true;
    public int enemyCount;
    public int level;
    LevelLoader loader;
    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.SetActive(false);
        gameWinScreen.SetActive(false);
        bossTitle.SetActive(false);
        bossHealth.SetActive(false);
        level = 1;
        loader = GameObject.Find("LevelLoad").GetComponent<LevelLoader>();
        slider = bossHealth.GetComponent<Slider>();
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
    public void gameWin()
    {
        gameRunning = false;
        gameWinScreen.SetActive(true);
    }
    IEnumerator BossEntrance()
    {
        gameRunning = false;
        bossTitle.SetActive(true);
        bossHealth.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        gameRunning = true;
    }
    public void EnterBoss()
    {
        StartCoroutine(BossEntrance());
    }
    public void SetHealthBar(int amount)
    {
        slider.value = amount;
    }
    public void SetUpHealth(int max)
    {
        slider.maxValue = max;
    }
    public void restart()
    {
        loader.LoadLevel(0);
    }

}
