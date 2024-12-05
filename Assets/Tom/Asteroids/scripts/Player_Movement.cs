using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour
{
    public float speed = 10f; // Speed of the ship
    public float tiltAngle = 10f; // Maximum tilt angle
    public float tiltSpeed = 15f; // Tilt speed
    public float acceleration = 5f; // Forward acceleration speed
    private Vector2 velocity; // Current velocity of the ship
    private Rigidbody2D rb;
    public int health = 3;

    public SpriteRenderer ship;
    public Sprite hurtnone;
    public Sprite hurtsome;
    public Sprite hurtlot;
    public int dead = 0;

    //black hole

    

    void start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = 3;
        ship.sprite = hurtsome;
    }

    private void Update()
    {
        if (GameObject.Find("StoryManager") != null)
        {
            //Debug.Log("The object exists!");
            
            if (dead == 1)
            {
                SceneManager.LoadScene("Lose");
            }
        }
        else
        {
            
            if (dead == 1)
            {
                SceneManager.LoadScene("Lose");
            }
        }
        if (health == 3)
        {
            ship.sprite = hurtnone;
        }
        if (health == 2)
        {
            ship.sprite = hurtsome;
        }
        if (health == 1)
        {
            ship.sprite = hurtlot;
        }
        if (health == 0)
        {
            dead = 1;
        }

        // Handle movement input
        HandleMovement();
        // Check for wall collisions
        CheckBoundaries();
        if (Input.GetKey("escape"))
        {
            Application.Quit();

        }
        if (health <= 0)
        {
            //Application.Quit();
        }


    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            health = health - 1;
            //Application.Quit();
            print(health);
        }
        if (collision.gameObject.CompareTag("BlackHole"))
        {
            health = health - 1;
            //Application.Quit();
            print(health);
        }

    }

    private void HandleMovement()
    {
        // thrust forwards into space
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {

            velocity += (Vector2)(transform.up * acceleration * Time.deltaTime);
        }

        // Move the ship based on its current velocity
        transform.position += (Vector3)velocity * Time.deltaTime;

        // turning
        float tiltInput = Input.GetAxis("Horizontal"); // -1 for a 1 for d i think
        float tilt = tiltInput * tiltAngle;

        // Apply rotation
        transform.Rotate(0, 0, -tilt * tiltSpeed * Time.deltaTime);
    }

    private void CheckBoundaries()
    {
        // Get the screen boundaries
        Vector3 position = transform.position;

        // Teleport to the opposite side if out of bounds
        if (position.x < -Camera.main.orthographicSize * Camera.main.aspect)
        {
            position.x = Camera.main.orthographicSize * Camera.main.aspect;
        }
        else if (position.x > Camera.main.orthographicSize * Camera.main.aspect)
        {
            position.x = -Camera.main.orthographicSize * Camera.main.aspect;
        }

        if (position.y < -Camera.main.orthographicSize)
        {
            position.y = Camera.main.orthographicSize;
        }
        else if (position.y > Camera.main.orthographicSize)
        {
            position.y = -Camera.main.orthographicSize;
        }

        transform.position = position;
    }
}

