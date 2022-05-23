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
    public Camera mainCam;
    Slider slider;
    public bool gameRunning = true;
    public int enemyCount;
    public int level;
    LevelLoader loader;

    public AudioClip gameOverSound;
    public AudioClip gameWinSound;
    public AudioClip heartPickUp;
    public AudioSource gameAudio;

    public AudioClip bossMusic;
    public AudioSource gameMusic;
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

    public void GameOver()
    {
        gameRunning = false;
        gameOverScreen.SetActive(true);
        gameMusic.volume = 0.05f;
        gameAudio.PlayOneShot(gameOverSound);
    }
    public void GameWin()
    {
        gameRunning = false;
        gameMusic.volume = 0.05f;
        gameAudio.PlayOneShot(gameWinSound);
        gameWinScreen.SetActive(true);
    }
    IEnumerator BossEntrance()
    {
        gameRunning = false;
        gameMusic.clip = bossMusic;
        gameMusic.Play();
        bossTitle.SetActive(true);
        bossHealth.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        gameRunning = true;
    }
    public void EnterBoss()
    {
        StartCoroutine(BossEntrance());
    }
    public void SetHealthBar(float amount)
    {
        slider.value = amount;
    }
    public void SetUpHealth(float max)
    {
        slider.maxValue = max;
    }
    public void restart()
    {
        loader.LoadLevel(0);
    }

    public void PlayPickUpSound()
    {
        gameAudio.PlayOneShot(heartPickUp,0.2f);
    }

}
