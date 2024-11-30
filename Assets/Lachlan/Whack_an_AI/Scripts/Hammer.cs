using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    private Vector2 mousePosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.Lerp(transform.position, mousePosition, 0.5f);



    }


    public void HammerAnimation()
    {

    }

}
