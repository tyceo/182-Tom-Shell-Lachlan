using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block3 : MonoBehaviour
{
    public QuestionManager manager;
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object that collided with this block is the projectile
        if (collision.gameObject.CompareTag("Bullet"))
        {
            manager.question1Answer3 = 1;
            // Handle the collision
            Debug.Log("Projectile hit the 3rd block!");

            // Optionally destroy the projectile
            Destroy(collision.gameObject);


        }
    }
}
