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
    
    // Play open transition
    private void Awake()
    {
        fade.SetActive(true);
    }

    // Checks if level completed and loads next level
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

    // Restart level
    public void ReloadLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    // Loads next level (Menu if completed level 10)
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

    // Open menu scene
    public void LoadMenu()
    {
        StartCoroutine(LoadLevel(0));
    }

    // Loads chosen level
    public void SelectLevel(int levelIndex)
    {
        StartCoroutine(LoadLevel(levelIndex));
    }

    // Allows transition to play
    IEnumerator LoadLevel(int levelIndex)
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
