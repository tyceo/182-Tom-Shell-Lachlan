using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement_astonaut : MonoBehaviour
{
    // Movement parameters
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask Floor; // Assign the "floor" layer to this in the inspector

    private Rigidbody2D rb;
    private bool isGrounded = false;


    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        Physics2D.gravity = new Vector3(0f, -10f, 0f);
    }

    void Update()
    {

        // Horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // Check if the player is grounded using raycasting
        isGrounded = IsGrounded();

        // Jumping (using "W" key)
        if (Input.GetKeyDown(KeyCode.W) && isGrounded && rb.velocity.y > -0.1 && rb.velocity.y < 0.1)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            
        }


    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("gravity1"))
        {
            Physics2D.gravity = new Vector3(0f, -5f, 0f);
        }
        if (other.CompareTag("gravity2"))
        {
            Physics2D.gravity = new Vector3(0f, -20f, 0f);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("gravity1"))
        {
            Physics2D.gravity = new Vector3(0f, -10f, 0f);
        }
        if (other.CompareTag("gravity2"))
        {
            Physics2D.gravity = new Vector3(0f, -10f, 0f);
        }
    }
    



    private bool IsGrounded()
    {
        Vector2 rayOrigin = transform.position - new Vector3(0f, 0.5f, 0f); // Slightly below the player's feet


        Vector2 rightOffset = new Vector2(0.34f, 0);
        Vector2 leftOffset = new Vector2(-0.34f, 0);

        RaycastHit2D hit = Physics2D.Raycast(rayOrigin + leftOffset, Vector2.down, 0.1f, Floor);
        Debug.DrawRay(rayOrigin + leftOffset, Vector2.down, Color.red);

        RaycastHit2D hitRight = Physics2D.Raycast(rayOrigin + rightOffset, Vector2.down + Vector2.right, 0.1f, Floor);
        Debug.DrawRay(rayOrigin + rightOffset, Vector2.down, Color.red);


        return hit.collider != null || hitRight.collider != null;


    }



}
