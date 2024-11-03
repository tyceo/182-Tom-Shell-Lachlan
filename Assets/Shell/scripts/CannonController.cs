using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject projectilePrefab;  // Drag your projectile prefab here in the Inspector
    public float projectileSpeed = 10f;  // Set a fixed speed for the projectile

    void Update()
    {
        // Get the position of the mouse in the world
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;  // Set z to 0 for 2D calculation

        // Calculate the direction from the cannon to the mouse
        Vector3 direction = mousePosition - transform.position;

        // Calculate the angle in degrees and apply it to the z-axis rotation
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 270));

        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            SpawnProjectile(mousePosition);
        }

    }

    void SpawnProjectile(Vector3 targetPosition)
    {
        // Set the spawn position to (0, -5, 0) for the projectile
        Vector3 spawnPosition = new Vector3(0, -5, 0);
        GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);

        // Calculate the direction from spawn to target and normalize to ensure constant speed
        Vector3 direction = (targetPosition - spawnPosition).normalized;

        // Set the projectile's velocity to move it at a fixed speed toward the cursor
        projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
    }
}
