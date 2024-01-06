using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button menuStart, levelSelectStart;
    public AudioSource click, select;
    public LevelLoader LevelLoader;
    public Animator animator;

    // Selects button for controller support
    private void Start()
    {
        Cursor.visible = true;
        menuStart.Select();
    }
    // Starts level 1
    public void StartGame()
    {
        click.Play();
        Cursor.visible = false;
        LevelLoader.LoadNextLevel();
    }
    // Level select moves into view
    public void OpenLevelSelect()
    {
        click.Play();
        animator.SetTrigger("Level");
        levelSelectStart.Select();
    }
    // Menu moves into view
    public void OpenMenu()
    {
        click.Play();
        animator.SetTrigger("Main");
        menuStart.Select();
    }
    // Starts the selected level
    public void LevelSelect(int levelIndex)
    {
        click.Play();
        Cursor.visible = false;
        LevelLoader.SelectLevel(levelIndex);
    }
    // Select button sound
    public void OnSelect()
    {
        select.Play();
    }
    // Quit game
    public void Quit()
    {
        Application.Quit();
    }
}
