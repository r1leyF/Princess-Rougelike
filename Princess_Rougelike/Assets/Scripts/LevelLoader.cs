using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator animator;
    public float transitionTime = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadLevel(int buildIndex)
    {
        StartCoroutine(Load(buildIndex));
    }

    IEnumerator Load(int index)
    {
        animator.SetTrigger("ExitScene");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(index);
    }
}
