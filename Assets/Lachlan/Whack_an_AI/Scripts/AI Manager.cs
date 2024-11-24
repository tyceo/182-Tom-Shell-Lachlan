using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    //public GameObject[] allAI;
    public List<GameObject> allAI = new List<GameObject>();
    public int evilAICount;
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
        }
        if(evilAICount == 0)
        {
            Debug.Log("Game Won");
        }
    }
}
