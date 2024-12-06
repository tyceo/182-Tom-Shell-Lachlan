using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TentacleManagerFrying : MonoBehaviour
{
    [SerializeField] private int friedTentacles;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (friedTentacles == 6)
        {
            Debug.Log("Won the Game");
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

    public void TentacleFried()
    {
        friedTentacles++;
    }


}
