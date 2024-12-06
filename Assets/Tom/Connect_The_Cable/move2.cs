using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move2 : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed of the platform's movement
    public float moveRange = 3f; // Maximum distance the platform moves from its start point

    private Vector3 startPosition; // The starting position of the platform
    private bool movingDown = true; // Direction of the platform's movement (starts by moving down)

    void Start()
    {
        // Record the starting position
        startPosition = transform.position;
    }

    void Update()
    {
        // Move the platform up and down
        MovePlatform();
    }

    private void MovePlatform()
    {
        // Determine the direction
        if (movingDown)
        {
            // Move down
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;

            // Check if the platform has reached the bottom
            if (transform.position.y <= startPosition.y - moveRange)
            {
                movingDown = false; // Switch direction to up
            }
        }
        else
        {
            // Move up
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;

            // Check if the platform has reached the top
            if (transform.position.y >= startPosition.y)
            {
                movingDown = true; // Switch direction to down
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = transform;
            print("touch");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = null;
            print("touch no more");
        }
    }
}
