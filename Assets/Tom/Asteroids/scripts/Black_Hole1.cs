using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black_Hole1 : MonoBehaviour
{
    public float growDuration = 4f;  // Time to grow
    public float stayDuration = 2f; // Time to stay at full size
    public float shrinkDuration = 4f; // Time to shrink
    private Vector3 targetScale = Vector3.one; // Target scale
    private Vector3 initialScale = Vector3.zero; // Initial scale
    public GameObject thisone2;

    /*private void Start()
    {
        transform.localScale = initialScale; // Start at size 0
        
    }
    */

    private IEnumerator GrowAndShrink()
    {
        // Grow phase
        yield return ScaleOverTime(initialScale, targetScale, growDuration);

        // Stay phase
        yield return new WaitForSeconds(stayDuration);

        // Shrink phase
        yield return ScaleOverTime(targetScale, initialScale, shrinkDuration);
    }

    private IEnumerator ScaleOverTime(Vector3 startScale, Vector3 endScale, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration; // Normalize time
            transform.localScale = Vector3.Lerp(startScale, endScale, t);
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for next frame
        }

        transform.localScale = endScale; // Ensure it ends exactly at the target scale
    }
    IEnumerator Start()
    {
        transform.localScale = initialScale; // Start at size 0
        thisone2.SetActive(true);
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(7f, 15f));
            yield return StartCoroutine(GrowAndShrink());
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            thisone2.SetActive(false);
        }

    }

   
}
