using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public Slider progressBar; // Reference to the slider
    
    public float duration = 15f; // Duration for progress to reach max, in seconds
    public string nextSceneName = "NextScene"; // Name of the scene to load

    private float elapsedTime = 0f; // Tracks the elapsed time
    private bool gameWon = false;

    private void Start()
    {
        progressBar.value = progressBar.maxValue; // Start progress at 0
        //winScreen.color = new Color(winScreen.color.r, winScreen.color.g, winScreen.color.b, 0); // Make win screen invisible
    }

    private void Update()
    { 
        if (!gameWon)
        {
            // Increment the elapsed time by the time passed since last frame
            elapsedTime += Time.deltaTime;

            // Calculate the progress percentage based on elapsed time and duration
            float progress = progressBar.maxValue - Mathf.Clamp01(elapsedTime / duration);

            // Set the slider's value to the calculated progress
            progressBar.value = progress * progressBar.maxValue;

            // Check if the progress has completed
            if (elapsedTime >= duration)
            {
                ShowLoseScreen(); // Show the win screen
                gameWon = true;
            }
        }
    }

    private void ShowLoseScreen()
    {
        Debug.Log("Lost the game");
        //Invoke("LoadNextScene", 2f); // Change 2f to any delay time you want
    }

    private void LoadNextScene()
    {
        // Load the specified next scene
        SceneManager.LoadScene(nextSceneName);
    }
}
