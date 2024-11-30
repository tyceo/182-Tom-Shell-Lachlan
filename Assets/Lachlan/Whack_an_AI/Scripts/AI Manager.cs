using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AIManager : MonoBehaviour
{
    //public GameObject[] allAI;
    
    public int evilAICount = 0;
    public int playerHealth = 2;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth == 0)
        {
            Debug.Log("FAILURE");
            SceneManager.LoadScene("Lose_Scene");
        }
        if(evilAICount == 0)
        {
            Debug.Log("Game Won");
        }
    }
}
