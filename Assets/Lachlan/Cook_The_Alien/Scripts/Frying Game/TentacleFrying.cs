using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleFrying : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Fryer")
        {
            
            Debug.Log("Triggered on fryer");
        }
    }

}
