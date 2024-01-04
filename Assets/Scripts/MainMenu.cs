using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public LevelLoader LevelLoader;

    public GameObject firstButton;
    public void StartGame()
    {
        LevelLoader.LoadNextLevel();
    }
}
