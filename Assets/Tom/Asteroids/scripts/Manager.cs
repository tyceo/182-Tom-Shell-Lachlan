using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Manager : MonoBehaviour
{
    public Slider progressBar; // Reference to the slider
    public Image winScreen; // Reference to the win screen image
    public float duration = 15f; // Duration for progress to reach max, in seconds
    public string nextSceneName = "NextScene"; // Name of the scene to load

    private float elapsedTime = 0f; // Tracks the elapsed time
    private bool gameWon = false;
    public bool gameOver = false;

    public GameObject shipTutorial;

    private void Start()
    {
        StartCoroutine(FreezeAndDisappear());
        progressBar.value = 0; // Start progress at 0
        winScreen.color = new Color(winScreen.color.r, winScreen.color.g, winScreen.color.b, 0); // Make win screen invisible
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
        if (shipTutorial != null)
        {
            shipTutorial.SetActive(false);
        }
    }
    public void Update()
    {
        
        //story or not story mode
        if (GameObject.Find("StoryManager") != null)
        {
            //Debug.Log("The object exists!");
            if (gameWon == true)
            {
                SceneManager.LoadScene("Menu_Story_Progress");
            }
        }
        else
        {
            if (gameWon == true)
            {
                SceneManager.LoadScene("Win");
            }
        }

        if (!gameWon)
        {
            // Increment the elapsed time by the time passed since last frame
            elapsedTime += Time.deltaTime;

            // Calculate the progress percentage based on elapsed time and duration
            float progress = Mathf.Clamp01(elapsedTime / duration);

            // Set the slider's value to the calculated progress
            progressBar.value = progress * progressBar.maxValue;

            // Check if the progress has completed
            if (elapsedTime >= duration)
            {
                //ShowWinScreen(); // Show the win screen
                gameWon = true;
            }
        }
    }

    private void ShowWinScreen()
    {
        // Set the win screen image to fully visible
        winScreen.color = new Color(winScreen.color.r, winScreen.color.g, winScreen.color.b, 1);

        // Delay to give time for win screen to be visible before scene change
        Invoke("LoadNextScene", 2f); // Change 2f to any delay time you want
    }

    private void LoadNextScene()
    {
        // Load the specified next scene
        SceneManager.LoadScene(nextSceneName);
    }
}
