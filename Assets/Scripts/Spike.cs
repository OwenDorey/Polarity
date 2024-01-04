using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Spike : MonoBehaviour
{
    private Rigidbody2D rb;
    private LevelLoader levelLoader;

    private void Start()
    {
        levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !levelLoader.hasWon)
        {
            FindAnyObjectByType<AudioManager>().OnDeath();

            Destroy(collision.gameObject.GetComponentInChildren<SpriteRenderer>());
            Destroy(collision.gameObject.GetComponentInChildren<Light2D>());
            collision.gameObject.GetComponent<ParticleSystem>().Play();

            rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezePosition;

            levelLoader.ReloadLevel();
        }
    }
}
