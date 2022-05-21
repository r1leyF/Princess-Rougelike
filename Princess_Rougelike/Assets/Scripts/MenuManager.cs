using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Image smallClouds;
    public Image midClouds;
    public Image largeClouds;
    Vector2 startPos;
    public float smallSpeed = 30;
    public float midSpeed = 30;
    public float largeSpeed = 30;
    RectTransform smallRect;
    RectTransform midRect;
    RectTransform largeRect;

    public GameObject aboutScreen;
    public GameObject titleScreen;
    public GameObject controlsScreen;

    LevelLoader loader;

    // Start is called before the first frame update
    void Start()
    {
        smallRect = smallClouds.GetComponent<RectTransform>();
        startPos = smallRect.anchoredPosition;
        midRect = midClouds.GetComponent<RectTransform>();
        startPos = midRect.anchoredPosition;
        largeRect = largeClouds.GetComponent<RectTransform>();
        startPos = largeRect.anchoredPosition;

        aboutScreen.SetActive(false);
        controlsScreen.SetActive(false);
        titleScreen.SetActive(true);

        loader = GameObject.Find("LevelLoad").GetComponent<LevelLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        Scroll(smallClouds, smallRect, smallSpeed, startPos);
        Scroll(midClouds, midRect, midSpeed, startPos);
        Scroll(largeClouds, largeRect, largeSpeed, startPos);
    }
    void Scroll(Image image, RectTransform rect, float speed, Vector2 startPos)
    {
        image.transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (rect.anchoredPosition.x < startPos.x - 3200)
        {
            rect.anchoredPosition = startPos;
        }
    }
    public void StartGame()
    {
        loader.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ShowAbout()
    {
        aboutScreen.SetActive(true);
        titleScreen.SetActive(false);
    }
    public void ShowControls()
    {
        controlsScreen.SetActive(true);
        titleScreen.SetActive(false);
    }
    public void Back()
    {
        aboutScreen.SetActive(false);
        controlsScreen.SetActive(false);
        titleScreen.SetActive(true);
    }

}
