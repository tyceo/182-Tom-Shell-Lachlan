using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Knife : MonoBehaviour
{
    private Vector2 mousePosition;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.Lerp(transform.position, mousePosition, 0.5f);
    }
}
