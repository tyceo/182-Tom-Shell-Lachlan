using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinAndLose : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(WaitAndChangeScene());
    }

    private IEnumerator WaitAndChangeScene()
    {
        yield return new WaitForSeconds(3f); // Wait for 3 seconds
        SceneManager.LoadScene("Menu"); // Change to the Menu scene
    }
}
