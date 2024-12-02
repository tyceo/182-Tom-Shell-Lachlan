using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BabyManager : MonoBehaviour
{
    public Sprite[] spriteOptions;
    public int randomIndex;
    public int randomIndex2;

    public GameObject Choise3;
    public GameObject Choise4;
    public int OneHit;
    public int OneHit2;

    public int NumberOfLevelsDone = 0;
    public int NumberOfLevelsNeeded = 7;
    public int IsStorymode = 0;
    public int Win = 0;
    public int Lose = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        NumberOfLevelsDone = 0;
        OneHit = 0;
        OneHit2 = 0;
        randomIndex = Random.Range(0, spriteOptions.Length);
        randomIndex2 = Random.Range(0, spriteOptions.Length);

        SpriteRenderer spriteRenderer = Choise3.GetComponent<SpriteRenderer>();
        SpriteRenderer spriteRenderer2 = Choise4.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteOptions[randomIndex];
        spriteRenderer2.sprite = spriteOptions[randomIndex2];

        Debug.Log(randomIndex);
        Scene currentScene = SceneManager.GetActiveScene();

        
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (randomIndex == randomIndex2)
        {

            randomIndex2 = Random.Range(0, spriteOptions.Length);
            SpriteRenderer spriteRenderer2 = Choise3.GetComponent<SpriteRenderer>();
            spriteRenderer2.sprite = spriteOptions[randomIndex2];

        }
        if (OneHit == 1)
        {
            OneHit = 0;
            spaceship(); // test
            if (randomIndex == 0)
            {
                cookalien();
                Debug.Log("cookalien");
            }

            if (randomIndex == 1)
            {
                aibad();
                Debug.Log("aibad");
            }
            if (randomIndex == 2)
            {
                connectcable();
                Debug.Log("connectcable");
            }
            if (randomIndex == 3)
            {
                trivia();
                Debug.Log("trivia");
            }
            if (randomIndex == 4)
            {
                spaceship();
                Debug.Log("Spaceship");
            }
        }

        if (OneHit2 == 1)
        {
            OneHit2 = 0;
            if (randomIndex2 == 0)
            {
                cookalien();
                Debug.Log("cookalien");
            }

            if (randomIndex2 == 1)
            {
                aibad();
                Debug.Log("aibad");
            }
            if (randomIndex2 == 2)
            {
                connectcable();
                Debug.Log("connectcable");
            }
            if (randomIndex2 == 3)
            {
                trivia();
                Debug.Log("trivia");
            }
            if (randomIndex2 == 4)
            {
                spaceship();
                Debug.Log("Spaceship");
            }

        }
    }
    public void cookalien()
    {
        SceneManager.LoadScene("Lachlan_Cook_The_Alien");
    }
    public void aibad()
    {
        SceneManager.LoadScene("Lachlan_Wack_An_AI");
    }

    public void connectcable()
    {
        SceneManager.LoadScene("Tom_Connect_The_Cable");
    }
    public void trivia()
    {
        SceneManager.LoadScene("Shell_Shoot_The_Right_Planet");
    }
    public void spaceship()
    {
        SceneManager.LoadScene("Tom_Asteroid_Dodger");
    }
}
