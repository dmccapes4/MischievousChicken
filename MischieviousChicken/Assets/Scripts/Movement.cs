using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public float movementRange = 5.0f;
    public LayerMask collisionLayer;

    private float startX;
    private float snakeX;
    private string snakeDirection = "right";
    private bool isFlipped = false;

    void Start()
    {
        startX = transform.position.x;
        snakeX = startX;
    }

    void Update()
    {
        if (!IsColliding(snakeDirection))
        {
            MoveSnake();
        }
        else
        {
            ChangeDirection();
        }

        transform.position = new Vector3(snakeX, transform.position.y, transform.position.z);
    }

    void MoveSnake()
    {
        if (snakeDirection == "right")
        {
            snakeX += speed * Time.deltaTime;
            if (isFlipped)
            {
                FlipSprite();
                isFlipped = false;
            }
        }
        else
        {
            snakeX -= speed * Time.deltaTime;
            if (!isFlipped)
            {
                FlipSprite();
                isFlipped = true;
            }
        }

        snakeX = Mathf.Clamp(snakeX, startX - movementRange, startX + movementRange);
    }

    void ChangeDirection()
    {
        snakeDirection = (snakeDirection == "right") ? "left" : "right";
    }

    bool IsColliding(string direction)
    {
        Vector2 directionVector = direction == "right" ? Vector2.right : Vector2.left;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, directionVector, 0.1f, collisionLayer);
        return hit.collider != null;
    }

    void FlipSprite()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}