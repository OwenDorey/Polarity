using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Transform blackSquare;
    public Rigidbody2D rbBlack;
    public Transform groundCheckBlack;
    public bool blackFlipped;

    private float horizontalBlack;
    public bool blackFacingRight;


    public Transform whiteSquare;
    public Rigidbody2D rbWhite;
    public Transform groundCheckWhite;
    public bool whiteFlipped;

    private float horizontalWhite;
    public bool whiteFacingRight;


    public LayerMask groundLayer;
    public float speed = 8f;
    public float jumpingPower = 10f;

    // Correct gravity set if upside down
    private void Start()
    {
        if (blackFlipped)
        {
            rbBlack.gravityScale *= -1f;
            blackFacingRight = !blackFacingRight;
        }
        else if (whiteFlipped)
        {
            rbWhite.gravityScale *= -1f;
            whiteFacingRight = !whiteFacingRight;
        }
    }

    // Move players
    private void Update()
    {
        rbBlack.velocity = new Vector2(horizontalBlack * speed, rbBlack.velocity.y);
        rbWhite.velocity = new Vector2(horizontalWhite * speed, rbWhite.velocity.y);

        if (!blackFacingRight && horizontalBlack > 0f)
        {
            FlipBlack();
        }
        else if (blackFacingRight && horizontalBlack < 0f)
        {
            FlipBlack();
        }

        if (!whiteFacingRight && horizontalWhite > 0f)
        {
            FlipWhite();
        }
        else if (whiteFacingRight && horizontalWhite < 0f)
        {
            FlipWhite();
        }
    }

    public void SwitchGravity(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            rbBlack.gravityScale *= -1f;
            rbWhite.gravityScale *= -1f;
            Rotation();
        }
    }

    // Rotate player when gravity switched
    private void Rotation()
    {
        if (!blackFlipped)
        {
            blackSquare.eulerAngles = new Vector3(0, 0, 180f);
        }
        else
        {
            blackSquare.eulerAngles = Vector3.zero;
        }
        blackFacingRight = !blackFacingRight;
        blackFlipped = !blackFlipped;

        if (!whiteFlipped)
        {
            whiteSquare.eulerAngles = new Vector3(0, 0, 180f);
        }
        else
        {
            whiteSquare.eulerAngles = Vector3.zero;
        }
        whiteFacingRight = !whiteFacingRight;
        whiteFlipped = !whiteFlipped;
    }

    // Flip jump if upside down
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsBlackGrounded())
        {
            if (blackFlipped)
            {
                rbBlack.velocity = new Vector2(rbBlack.velocity.x, jumpingPower * -1f);
            }
            else
            {
                rbBlack.velocity = new Vector2(rbBlack.velocity.x, jumpingPower);
            }   
        }

        if (context.performed && IsWhiteGrounded())
        {
            if (whiteFlipped)
            {
                rbWhite.velocity = new Vector2(rbWhite.velocity.x, jumpingPower * -1f);
            }
            else
            {
                rbWhite.velocity = new Vector2(rbWhite.velocity.x, jumpingPower);
            }
        }
    }

    public void Restart(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GameObject.FindAnyObjectByType<LevelLoader>().ReloadLevel();
        }
    }

    private bool IsBlackGrounded()
    {
        return Physics2D.OverlapCircle(groundCheckBlack.position, 0.2f, groundLayer);
    }
    private bool IsWhiteGrounded()
    {
        return Physics2D.OverlapCircle(groundCheckWhite.position, 0.2f, groundLayer);
    }

    private void FlipBlack()
    {
        blackFacingRight = !blackFacingRight;
        Vector3 blackLocalScale = blackSquare.localScale;
        blackLocalScale.x *= -1f;
        blackSquare.localScale = blackLocalScale;
        
    }

    private void FlipWhite()
    {
        whiteFacingRight = !whiteFacingRight;
        Vector3 whiteLocalScale = whiteSquare.localScale;
        whiteLocalScale.x *= -1f;
        whiteSquare.localScale = whiteLocalScale;
    }

    // White square moves in opposite direction
    public void Move(InputAction.CallbackContext context)
    {
        horizontalBlack = context.ReadValue<Vector2>().x;
        horizontalWhite = context.ReadValue<Vector2>().x * -1f;
    }
}
