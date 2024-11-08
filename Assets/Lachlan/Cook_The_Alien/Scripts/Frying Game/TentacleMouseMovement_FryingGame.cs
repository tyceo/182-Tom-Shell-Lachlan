using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleMouseMovement_FryingGame : MonoBehaviour
{
    private Vector2 mousePosition;
    [SerializeField] private bool mouseHovering;

    // Start is called before the first frame updat
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseHovering == true)
        {
            if (Input.GetMouseButton(0))
            {
                mousePosition = Input.mousePosition;
                mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = Vector2.Lerp(transform.position, mousePosition, 0.5f);
            }
        }

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
