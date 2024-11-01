using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Rock : MonoBehaviour
{
    public float speed = 5f;                // Base speed of the asteroid
    public float speedVariance = 3f;        // Amount of random variance to add to speed
    public float spawnRadius = 10f;         // Radius at which asteroids spawn around the center
    public float directionVariance = 45f;   // Variance of up to 45 degrees to each side (90 total)
    public float rotationSpeedMin = -100f;  // Minimum rotation speed in degrees per second
    public float rotationSpeedMax = 100f;   // Maximum rotation speed in degrees per second

    private Vector3 targetPosition = Vector3.zero;  // Target position (center of the screen)
    private Vector3 spawnPosition;
    private float actualSpeed;                      // The speed with random variance
    private float rotationSpeed;                    // The random rotation speed of the asteroid
    /*
    private void Start()
    {

       
    }
    */
    IEnumerator Start()
    {
        yield return new WaitForSeconds(Random.Range(1f, 8f));
        StartCoroutine(LaunchAsteroid());
    }

    private IEnumerator LaunchAsteroid()
    {
        while (true)
        {
            // Choose a random spawn position around the center
            float angle = Random.Range(0, 360);
            spawnPosition = targetPosition + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * spawnRadius;

            // Move asteroid to spawn position
            transform.position = spawnPosition;

            // Calculate direction with random variance
            Vector3 direction = (targetPosition - spawnPosition).normalized;
            float varianceAngle = Random.Range(-directionVariance, directionVariance);
            direction = Quaternion.Euler(0, 0, varianceAngle) * direction;

            // Apply random speed variance
            actualSpeed = speed + Random.Range(-speedVariance, speedVariance);

            // Assign a random rotation speed
            rotationSpeed = Random.Range(rotationSpeedMin, rotationSpeedMax);

            // Set a 3-second timer for the asteroid's life
            float timer = 8f;

            // Move asteroid toward the center and rotate it while the timer is active
            while (timer > 0)
            {
                // Move the asteroid forward with random speed
                transform.position += direction * actualSpeed * Time.deltaTime;

                // Rotate the asteroid
                transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

                timer -= Time.deltaTime;
                yield return null;
            }

            
        }
    }
}
