using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerAlien : MonoBehaviour
{
    public Slider slider;
    public float duration = 15f; // Duration for progress to reach max, in seconds

    private float elapsedTime = 0f; // Tracks the elapsed time

    private void Start()
    {
        slider.value = 0; // Start at full
    }

    public void Update()
    {
        // Increment the elapsed time by the time passed since last frame
        elapsedTime += Time.deltaTime;

        // Calculate the progress percentage based on elapsed time and duration
        float progress = slider.maxValue - Mathf.Clamp01(elapsedTime / duration);

        // Set the slider's value to the calculated progress
        slider.value = progress * slider.maxValue;

        
    }
}