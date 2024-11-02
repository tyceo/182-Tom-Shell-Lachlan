using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    public float delayBeforeFade = 1.5f; // Time in seconds to wait before starting fade
    public float fadeDuration = 1f;      // Duration of the fade-out in seconds

    private CanvasGroup canvasGroup;

    private void Awake()
    {
        // Get the CanvasGroup component attached to the same GameObject
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1; // Ensure the image is fully visible initially
    }

    private void OnEnable()
    {
        // Start the coroutine that waits, then fades out
        StartCoroutine(WaitAndFade());
    }

    private IEnumerator WaitAndFade()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(delayBeforeFade);

        float startAlpha = canvasGroup.alpha;

        // Loop to decrease the alpha over the fade duration
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0, t / fadeDuration);
            yield return null;
        }

        // Ensure the alpha is exactly 0 at the end
        canvasGroup.alpha = 0;
    }
}
