using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public LevelLoader LevelLoader;

    public GameObject firstButton;

    public AudioSource click, select;
    public void StartGame()
    {
        click.Play();
        LevelLoader.LoadNextLevel();

    }

    public void OnSelect()
    {
        select.Play();
    }
}
