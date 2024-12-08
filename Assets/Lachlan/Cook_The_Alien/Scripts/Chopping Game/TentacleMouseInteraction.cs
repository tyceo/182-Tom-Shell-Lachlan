using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleMouseInteraction : MonoBehaviour
{
    private bool mouseHovering;
    private TentacleChopping tentacleChop;
    public GameObject cookTutorial;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FreezeAndDisappear());
        tentacleChop = this.GetComponent<TentacleChopping>();
    }

    IEnumerator FreezeAndDisappear()
    {
        // Freeze the game
        Time.timeScale = 0;

        // Wait for 3 real-time seconds while the game is frozen
        float pauseEndTime = Time.realtimeSinceStartup + 4f;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return null; // Wait for the next frame
        }

        // Unfreeze the game
        Time.timeScale = 1;

        // Make the object disappear
        if (cookTutorial != null)
        {
            cookTutorial.SetActive(false);
        }
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
        tentacleChop.TentacleChopped();
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
