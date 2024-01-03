using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Spike : MonoBehaviour
{
    private Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject.GetComponentInChildren<SpriteRenderer>());
            Destroy(collision.gameObject.GetComponentInChildren<Light2D>());
            collision.gameObject.GetComponent<ParticleSystem>().Play();

            rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
        }
    }
}
