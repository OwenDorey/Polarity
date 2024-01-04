using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwitcher : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerMovement playerMovement = FindAnyObjectByType<PlayerMovement>();
            GameObject player = collision.gameObject;
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();

            if (player.layer == 6)
            {
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
            else if (player.layer == 7)
            {
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

            rb.gravityScale *= -1f;
        }
    }
}
