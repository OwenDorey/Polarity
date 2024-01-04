using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public LevelLoader LevelLoader;
    public Button menuStart, levelSelectStart;
    public AudioSource click, select;
    public Animator animator;

    private void Start()
    {
        Cursor.visible = true;
        menuStart.Select();
    }
    public void StartGame()
    {
        click.Play();
        Cursor.visible = false;
        LevelLoader.LoadNextLevel();
    }

    public void OpenLevelSelect()
    {
        click.Play();
        animator.SetTrigger("Level");
        levelSelectStart.Select();
    }

    public void OpenMenu()
    {
        click.Play();
        animator.SetTrigger("Main");
        menuStart.Select();
    }

    public void LevelSelect(int levelIndex)
    {
        click.Play();
        LevelLoader.SelectLevel(levelIndex);
    }

    public void OnSelect()
    {
        select.Play();
    }
}
