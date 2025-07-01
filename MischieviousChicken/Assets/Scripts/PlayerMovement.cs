using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 7.0f;
    public float jumpForce = 7.0f;
    public float parallaxBackgroundSpeed = 0.1f;
    public float parallaxMidgroundSpeed = 0.3f;
    public float parallaxForegroundSpeed = 0.5f;
    public GameObject ParralaxBackground;
    public GameObject ParralaxMidground;
    public GameObject ParralaxForground;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private int jumpCount = 0;
    private const int maxJumps = 2;

    // New variable to track if the player is on a slope
    // Test comment for git sanity check
    private bool isOnSlope = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Maintain horizontal velocity if on slope
        if (isOnSlope)
        {
            // Keep the current horizontal velocity
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
        }
        else
        {
            // Update horizontal velocity based on input
            rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        }

        // Flip the sprite based on input direction
        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        }

        // Handle jumping
        if (Input.GetButtonDown("Jump") && jumpCount < maxJumps)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCount++;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            jumpCount = 0;  // Reset jump count when touching the ground
        }

        // Check if the player is on a slope
        if (collision.gameObject.layer == LayerMask.NameToLayer("Slope"))
        {
            isOnSlope = true;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Vector2 collisionNormal = collision.contacts[0].normal;

            // Reset horizontal velocity if colliding with ground
            if (Mathf.Abs(collisionNormal.x) > 0.1f)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }

        // Check if still on slope
        if (collision.gameObject.layer == LayerMask.NameToLayer("Slope"))
        {
            isOnSlope = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Reset slope status when exiting the slope
        if (collision.gameObject.layer == LayerMask.NameToLayer("Slope"))
        {
            isOnSlope = false;
        }
    }
}