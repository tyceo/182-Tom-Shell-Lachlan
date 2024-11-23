using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIInput : MonoBehaviour
{
    [SerializeField] private AIManager manager;


    private bool mouseHovering = false;
    public string AiType = "Evil";

    // Start is called before the first frame update
    void Start()
    {
        
        manager.allAI.Add(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseHovering == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                HitTheAI();
            }
        }
    }


    private void HitTheAI()
    {
        if(AiType == "Evil")
        {
            Destroy(gameObject);
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
