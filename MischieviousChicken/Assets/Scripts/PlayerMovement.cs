using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 7.0f;
    public float jumpForce = 7.0f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Apply horizontal movement
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        // Flip the sprite when moving left
        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        }

        // Apply jump force when jump button is pressed
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    bool IsGrounded()
    {
        // Check if the player's collider is touching any colliders on the "Ground" layer
        return rb.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }
}