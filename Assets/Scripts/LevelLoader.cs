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
    public bool hasWon = false;

    private void Awake()
    {
        fade.SetActive(true);
    }

    private void Update()
    {
        if (starsCollected == 2)
        {
            hasWon = true;
            FindAnyObjectByType<AudioManager>().OnWin();

            Destroy(GameObject.Find("BlackStar"));
            Destroy(GameObject.Find("WhiteStar"));
            LoadNextLevel();
        }
    }

    public void ReloadLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    public void LoadNextLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (currentLevel == 10)
        {
            StartCoroutine(LoadLevel(0));
        }
        else
        {
            StartCoroutine(LoadLevel(currentLevel + 1));
        }   
    }

    public void SelectLevel(int levelIndex)
    {
        StartCoroutine(LoadLevel(levelIndex));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
