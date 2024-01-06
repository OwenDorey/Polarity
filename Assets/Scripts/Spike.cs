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
        // Make sure player can't die after beating level
        if (collision.gameObject.tag == "Player" && !levelLoader.hasWon)
        {
            // Particles and sound effects
            FindAnyObjectByType<AudioManager>().OnDeath();
            collision.gameObject.GetComponent<ParticleSystem>().Play();

            // Remove player visuals
            Destroy(collision.gameObject.GetComponentInChildren<SpriteRenderer>());
            Destroy(collision.gameObject.GetComponentInChildren<Light2D>());    

            // Stops player from moving
            rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezePosition;

            // Restarts level
            levelLoader.ReloadLevel();
        }
    }
}
