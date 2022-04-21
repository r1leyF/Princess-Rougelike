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
    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.SetActive(false);
        FollowMouse.canFollow = true;
        PlayerController.canMove = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameOver()
    {
        FollowMouse.canFollow = false;
        PlayerController.canMove = false;
        gameOverScreen.SetActive(true);
    }
    public void restart()
    {
        SceneManager.LoadScene(0);
    }

}
