using UnityEngine;

public class MovingPlank : MonoBehaviour
{
    public float moveDistance = 10.0f;
    public float moveSpeed = 2.0f;

    private Vector3 startPosition;
    private bool isMovingUp = true;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (isMovingUp)
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;

            if (transform.position.y >= startPosition.y + moveDistance)
            {
                transform.position = startPosition + Vector3.up * moveDistance;
                isMovingUp = false;
            }
        }
        else
        {
            transform.position -= Vector3.up * moveSpeed * Time.deltaTime;

            if (transform.position.y <= startPosition.y)
            {
                transform.position = startPosition;
                isMovingUp = true;
            }
        }
    }
}