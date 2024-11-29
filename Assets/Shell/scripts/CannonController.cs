using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public float cooldownDuration = 1f; // Cooldown duration of 1 second
    private float timeOfLastShot = -1f; // Initialize to allow immediate shooting
    public AudioSource audioSource1;

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

        // Check if the left mouse button is clicked and cooldown has passed
        if (Input.GetMouseButtonDown(0) && Time.time >= timeOfLastShot + cooldownDuration)
        {
            SpawnProjectile(mousePosition);
            timeOfLastShot = Time.time; // Update the timestamp of the last shot
        }
    }

    void SpawnProjectile(Vector3 targetPosition)
    {
        // Set the spawn position to (0, -5, 0) for the projectile
        Vector3 spawnPosition = new Vector3(0, -4.7f, 0);
        audioSource1.Play();
        GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);

        // Calculate the direction from spawn to target and normalize to ensure constant speed
        Vector3 direction = (targetPosition - spawnPosition).normalized;

        // Set the projectile's velocity to move it at a fixed speed toward the cursor
        projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
    }
}