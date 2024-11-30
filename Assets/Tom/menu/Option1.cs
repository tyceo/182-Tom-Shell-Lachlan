using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option1 : MonoBehaviour
{
    public StoryManager StoryManager;
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object that collided with this block is the projectile
        if (collision.gameObject.CompareTag("Player"))
        {
            StoryManager.OneHit = 1;
            // Handle the collision
            Debug.Log("Projectile hit the block!");

        }
    }
}
