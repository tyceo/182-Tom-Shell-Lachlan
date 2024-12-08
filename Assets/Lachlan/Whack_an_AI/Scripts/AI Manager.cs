using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AIManager : MonoBehaviour
{
    //public GameObject[] allAI;
    
    public int evilAICount = 0;
    public int playerHealth = 2;
    [SerializeField] private AudioSource correctAudio;
    [SerializeField] private AudioSource incorrectAudio;
    private bool gameWon = false;
    private bool lostHealth = false;

    public GameObject WhackTutorial;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FreezeAndDisappear());
        correctAudio = GetComponent<AudioSource>();

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
        if (WhackTutorial != null)
        {
            WhackTutorial.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth == 1)
        {
            if (lostHealth == false)
            {
                incorrectAudio.Play();
                lostHealth = true;
            }
            
        }
        //
        

        //
        if (playerHealth == 0)
        {
            Debug.Log("FAILURE");
            SceneManager.LoadScene("Lose_Scene");
            if (gameWon == false)
            {
                incorrectAudio.Play();
                gameWon = true;
            }

            //LOSE CONDITION
            SceneManager.LoadScene("Lose");
        }
        if(evilAICount == 0)
        {
            if(gameWon == false)
            {
                correctAudio.Play();
                gameWon = true;
            }
            
            Debug.Log("Game Won");
            //WIN CONDITION
            
            if (GameObject.Find("StoryManager") != null)
            {
                SceneManager.LoadScene("Menu_Story_Progress");
                //SceneManager.LoadScene("Menu_Story_Progress");
            }
            else
            {
                SceneManager.LoadScene("Win");
            }
        }
    }
}
