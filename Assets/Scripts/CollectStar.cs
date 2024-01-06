using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CollectStar : MonoBehaviour
{
    public bool isWhite;

    private int blackLayer = 6;
    private int whiteLayer = 7;

    // Checks if correct player is touching correct star
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.layer == whiteLayer && isWhite)
            {
                Collect();
            }
            else if (collision.gameObject.layer == blackLayer && !isWhite)
            {
                Collect();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.layer == whiteLayer && isWhite)
            {
                Remove();
            }
            else if (collision.gameObject.layer == blackLayer && !isWhite)
            {
                Remove();
            }
        }
    }

    // Collect star
    private void Collect()
    {
        FindAnyObjectByType<AudioManager>().OnWin();
        GameObject.FindAnyObjectByType<LevelLoader>().starsCollected += 1;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponentInChildren<Light2D>().enabled = false;
    }
    // Remove star
    private void Remove()
    {
        FindAnyObjectByType<AudioManager>().OnWin();
        GameObject.FindAnyObjectByType<LevelLoader>().starsCollected -= 1;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponentInChildren<Light2D>().enabled = true;
    }
}
