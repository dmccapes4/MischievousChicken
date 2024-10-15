using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
  public float speed = 2.0f;
  public float movementRange = 5.0f; // new variable to define movement range

  private float startX; // store the starting x position
  private float snakeX;
  private string snakeDirection = "right";
  private bool isFlipped = false; // new variable to track sprite flip

  void Start()
  {
    startX = transform.position.x; // store the starting x position
    snakeX = startX; // initialize snake's position
  }

  void Update()
  {
    if (snakeX <= startX - movementRange) {
      snakeDirection = "right";
    } else if (snakeX >= startX + movementRange) {
      snakeDirection = "left";
    }

    if (snakeDirection == "right") {
      snakeX += speed * Time.deltaTime;
      if (isFlipped) {
        FlipSprite(); // flip sprite back to original direction
        isFlipped = false;
      }
    } else {
      snakeX -= speed * Time.deltaTime;
      if (!isFlipped) {
        FlipSprite(); // flip sprite to face left
        isFlipped = true;
      }
    }

    transform.position = new Vector3(snakeX, transform.position.y, transform.position.z);
  }

  void FlipSprite()
  {
    Vector3 scale = transform.localScale;
    scale.x *= -1; // flip the sprite horizontally
    transform.localScale = scale;
  }
}