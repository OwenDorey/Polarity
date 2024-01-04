using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public GameObject fade;
    public Animator animator;
    public float transitionTime = 1f;
    public int starsCollected = 0;

    private void Awake()
    {
        fade.SetActive(true);
    }

    private void Update()
    {
        if (starsCollected == 2)
        {
            Destroy(GameObject.Find("BlackStar"));
            Destroy(GameObject.Find("WhiteStar"));
            starsCollected = 0;
            LoadNextLevel();
        }
    }

    public void ReloadLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
