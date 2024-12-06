using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public int yes = 0;
    public float moveSpeed = 5f;

    void Start()
    {
        yes = 0;
    }
    void Update()
    {
        if (IsOffScreen())
        {
            yes = 0;
            transform.position = new Vector3(-0.06f, -3.32f, 0);
        }
        if (yes == 0)
        {
            // Get the mouse position in world space
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Calculate the direction from the object to the mouse
            Vector3 direction = mousePosition - transform.position;

            // Ensure the direction is in the 2D plane
            direction.z = 0;

            // Calculate the angle in degrees
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Apply the rotation to the object
            transform.rotation = Quaternion.Euler(0, 0, angle + 270);
            Vector3 facingDirection = transform.up;

        }

        bool IsOffScreen()
        {
            // Get the object's position in viewport space
            Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);

            // Check if it's outside the screen boundaries
            return viewportPosition.x < 0 || viewportPosition.x > 1 ||
                   viewportPosition.y < 0 || viewportPosition.y > 1;
        }

            if (Input.GetMouseButtonDown(0)) // Left mouse button clicked
        {
            yes = 1;
        }
        if (yes == 1)
        {
            Vector3 movement = new Vector3(Mathf.Cos((transform.eulerAngles.z + 90) * Mathf.Deg2Rad),
                                   Mathf.Sin((transform.eulerAngles.z + 90) * Mathf.Deg2Rad),
                                   0);

            // Apply the movement
            transform.position += movement * moveSpeed * Time.deltaTime;
        }
    }
    
}
