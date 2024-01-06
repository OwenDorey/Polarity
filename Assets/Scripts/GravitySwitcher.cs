using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwitcher : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Get player components
            PlayerMovement playerMovement = FindAnyObjectByType<PlayerMovement>();
            GameObject player = collision.gameObject;
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();

            // If black square
            if (player.layer == 6)
            {
                // Flip if not flipped
                if (!playerMovement.blackFlipped)
                {
                    playerMovement.blackSquare.eulerAngles = new Vector3(0, 0, 180f);
                }
                else
                {
                    playerMovement.blackSquare.eulerAngles = Vector3.zero;
                }
                playerMovement.blackFacingRight = !playerMovement.blackFacingRight;
                playerMovement.blackFlipped = !playerMovement.blackFlipped;
            }
            // If white square
            else if (player.layer == 7)
            {
                // Flip if not flipped
                if (!playerMovement.whiteFlipped)
                {
                    playerMovement.whiteSquare.eulerAngles = new Vector3(0, 0, 180f);
                }
                else
                {
                    playerMovement.whiteSquare.eulerAngles = Vector3.zero;
                }
                playerMovement.whiteFacingRight = !playerMovement.whiteFacingRight;
                playerMovement.whiteFlipped = !playerMovement.whiteFlipped;
            }

            // Swap gravity + Sound effect
            rb.gravityScale *= -1f;
            FindAnyObjectByType<AudioManager>().OnFlip();
        }
    }
}
