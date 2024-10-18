using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public float movementRange = 5.0f;

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
        if (snakeX <= startX - movementRange)
        {
            snakeDirection = "right";
        }
        else if (snakeX >= startX + movementRange)
        {
            snakeDirection = "left";
        }

        MoveSnake();
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
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        FlipSnake();
    }

    void FlipSnake()
    {
        snakeDirection = (snakeDirection == "right") ? "left" : "right";
        FlipSprite();
    }

    void FlipSprite()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        isFlipped = !isFlipped; // Update the flip state
    }
}