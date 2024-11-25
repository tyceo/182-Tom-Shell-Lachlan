using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Rock : MonoBehaviour
{
    public float speed = 5f;                
    public float speedVariance = 3f;        
    public float spawnRadius = 10f;         
    public float directionVariance = 45f;   
    public float rotationSpeedMin = -100f;  
    public float rotationSpeedMax = 100f;   
    public float timerDuration = 8f;        

    private Vector3 targetPosition = Vector3.zero;
    private Vector3 spawnPosition;
    private float actualSpeed;
    private float rotationSpeed;

    public GameObject thisone;

    IEnumerator Start()
    {
        thisone.SetActive(true);
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3f, 10f));
            yield return StartCoroutine(LaunchAsteroid());
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            thisone.SetActive(false);
        }

    }

    public IEnumerator LaunchAsteroid()
    {
        
        float angle = Random.Range(0, 360);
        spawnPosition = targetPosition + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * spawnRadius;

        transform.position = spawnPosition;

        Vector3 direction = (targetPosition - spawnPosition).normalized;
        float varianceAngle = Random.Range(-directionVariance, directionVariance);
        direction = Quaternion.Euler(0, 0, varianceAngle) * direction;

        actualSpeed = speed + Random.Range(-speedVariance, speedVariance);

        rotationSpeed = Random.Range(rotationSpeedMin, rotationSpeedMax);

        // Timer for asteroid life
        float timer = timerDuration;

        while (timer > 0)
        {
            transform.position += direction * actualSpeed * Time.deltaTime;
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

            timer -= Time.deltaTime;
            yield return null;
        }
    }
}
