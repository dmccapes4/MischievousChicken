using UnityEngine;

public class MovingPlankHorizontal : MonoBehaviour
{
    public float moveDistance = 5.0f;
    public float moveSpeed = 2.0f;

    private Vector3 startPosition;
    private bool isMovingRight = true;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (isMovingRight)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;

            if (transform.position.x >= startPosition.x + moveDistance)
            {
                transform.position = startPosition + Vector3.right * moveDistance;
                isMovingRight = false;
            }
        }
        else
        {
            transform.position -= Vector3.right * moveSpeed * Time.deltaTime;

            if (transform.position.x <= startPosition.x)
            {
                transform.position = startPosition;
                isMovingRight = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.transform.SetParent(this.gameObject.transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.gameObject.transform.SetParent(null);
    }
}