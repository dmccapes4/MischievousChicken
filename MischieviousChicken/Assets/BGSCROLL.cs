using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 0.5f; // Speed of the background scroll
    private Transform player; // Reference to the player

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Assuming the player has the tag "Player"
    }

    void Update()
    {
        // Check player's movement direction
        float moveDirection = Input.GetAxis("Horizontal");

        // Scroll background based on player's movement
        if (moveDirection > 0) // Player is moving right
        {
            transform.position += Vector3.left * scrollSpeed * Time.deltaTime; // Scroll left
        }
        else if (moveDirection < 0) // Player is moving left
        {
            transform.position += Vector3.right * scrollSpeed * Time.deltaTime; // Scroll right
        }
    }
}