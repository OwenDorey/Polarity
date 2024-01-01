using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private float horizontal;
    private bool isFacingRight = true;
    private bool top;

    public float speed = 8f;
    public float jumpingPower = 10f;

    private void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }
    }

    public void SwitchGravity(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            rb.gravityScale *= -1f;
            Rotation();
        }
    }

    private void Rotation()
    {
        if (top == false)
        {
            transform.eulerAngles = new Vector3 (0, 0, 180f);
        }
        else
        {
            transform.eulerAngles = Vector3.zero;
        }
        isFacingRight = !isFacingRight;
        top = !top;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }
}
