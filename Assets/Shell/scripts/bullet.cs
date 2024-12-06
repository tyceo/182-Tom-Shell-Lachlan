using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnBecameInvisible()
    {
        // Destroy the projectile when it goes off-screen
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
