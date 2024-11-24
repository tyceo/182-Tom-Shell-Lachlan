using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIInput : MonoBehaviour
{
    [SerializeField] private AIManager manager;


    private bool mouseHovering = false;
    public bool AiEvil;
    
    // Start is called before the first frame update
    void Start()
    {
        int EvilChance = Random.Range(0, 2);
        if (EvilChance == 0)
        {
            AiEvil = true;
            manager.evilAICount++;
        }
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
        if(AiEvil == true)
        {
            manager.evilAICount--;
            Destroy(gameObject);
        }

        if(AiEvil == false)
        {
            manager.playerHealth--;
            Debug.LogWarning("WRONG");
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
