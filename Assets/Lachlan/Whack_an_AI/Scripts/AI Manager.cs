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
    // Start is called before the first frame update
    void Start()
    {
        correctAudio = GetComponent<AudioSource>();

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
