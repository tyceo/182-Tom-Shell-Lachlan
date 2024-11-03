using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionManager : MonoBehaviour
{
    public int question1Answer1 = 0;
    public int question1Answer2 = 0;
    public int question1Answer3 = 0;
    public QuestionController tmpTextChanger;
    public int currentQuestion = 0;

    public Timer progressBar;

    public Image winScreen; // Reference to the win screen image
    public float duration = 15f; // Duration for progress to reach max, in seconds
    public string nextSceneName = "NextScene"; // Name of the scene to load

    private float elapsedTime = 0f; // Tracks the elapsed time
    private bool gameWon = false;

    // Start is called before the first frame update
    void Start()
    {
        currentQuestion = 1;
        progressBar.value = 0; // Start progress at 0
        winScreen.color = new Color(winScreen.color.r, winScreen.color.g, winScreen.color.b, 0); // Make win screen invisible

    }

    // Update is called once per frame
    void Update()
    {
        if (currentQuestion == 1)
        {
            currentQuestion = 0;
            Question1();
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
                ShowWinScreen(); // Show the win screen
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

    public void Question1()
    {
        
        tmpTextChanger.UpdateText("What is The Dwarf Planet?");
        tmpTextChanger.UpdateAnswer1Text("Pluto");
        tmpTextChanger.ChangeAnswer1TextColor(Color.green);
        tmpTextChanger.UpdateAnswer2Text("Pluto");
        tmpTextChanger.ChangeAnswer2TextColor(Color.red);
        tmpTextChanger.UpdateAnswer3Text("pluto");
        tmpTextChanger.ChangeAnswer3TextColor(Color.yellow);
    }
}
