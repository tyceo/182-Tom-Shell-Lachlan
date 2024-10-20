using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public float speed = 3f; // Speed of the meteor
    private Vector2 direction; // Movement direction
    private float spawnOffset = 1.5f; // Offset from the screen edge

    private void Start()
    {
        SetSpawnPosition();
        SetRandomDirection();
    }

    private void Update()
    {
        transform.position += (Vector3)direction * speed * Time.deltaTime;

        if (IsOffScreen()) ResetMeteor();
    }

    private bool IsOffScreen()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        return pos.x < 0 || pos.x > 1 || pos.y < 0 || pos.y > 1;
    }

    private void ResetMeteor()
    {
        SetSpawnPosition();
        SetRandomDirection();
    }

    private void SetSpawnPosition()
    {
        float x, y;
        float cameraWidth = Camera.main.orthographicSize * Camera.main.aspect;
        float cameraHeight = Camera.main.orthographicSize;

        // Spawn from a random edge slightly off-screen
        if (Random.value > 0.5f) // Horizontal edge
        {
            x = Random.value > 0.5f ? cameraWidth + spawnOffset : -cameraWidth - spawnOffset; // Right or Left
            y = Random.Range(-cameraHeight, cameraHeight);
        }
        else // Vertical edge
        {
            y = Random.value > 0.5f ? cameraHeight + spawnOffset : -cameraHeight - spawnOffset; // Top or Bottom
            x = Random.Range(-cameraWidth, cameraWidth);
        }

        transform.position = new Vector3(x, y, 0);
    }

    private void SetRandomDirection()
    {
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
