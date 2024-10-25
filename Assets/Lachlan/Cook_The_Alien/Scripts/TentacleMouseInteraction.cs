using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleMouseInteraction : MonoBehaviour
{
    private bool mouseHovering;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (mouseHovering == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                MouseChop();
            }
        }
    }


    private void MouseChop()
    {
        Debug.Log("Chopped Tentacle");
    }


    private void OnMouseEnter()
    {
        Debug.Log("Mouse has entered the object");
        mouseHovering = true;

    }

    private void OnMouseExit()
    {
        mouseHovering = false;
    }

}
