using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour
{
    public Sprite[] spriteOptions;
    public int randomIndex;
    public int randomIndex2;
    
    public GameObject Choise1;
    public GameObject Choise2;
    public int OneHit;
    public int OneHit2;
    public int NumberOfLevelsDone = 0;
    public int NumberOfLevelsNeeded = 7;
    public int IsStorymode = 0;
    public int Win = 0;
    public int Lose = 0;
    public int Test = 0;

    private static StoryManager instance;
    //private Dictionary<string, int> sceneVisitCounts = new Dictionary<string, int>();
    public int menuStoryVisitCount = 0;

    void Awake()
    {
        IsStorymode = 1;
        if (instance != null)
        {
            // Destroy the old instance and replace it with the new one
            Destroy(instance.gameObject);
            
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        //SceneManager.sceneLoaded += OnSceneLoaded;
        
}
    // Start is called before the first frame update
    void Start()
    {
        FinishLevel();
        NumberOfLevelsDone = 0;
        OneHit = 0;
        OneHit2 = 0;
        randomIndex = Random.Range(0, spriteOptions.Length);
        randomIndex2 = Random.Range(0, spriteOptions.Length);

        SpriteRenderer spriteRenderer = Choise1.GetComponent<SpriteRenderer>();
        SpriteRenderer spriteRenderer2 = Choise2.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteOptions[randomIndex];
        spriteRenderer2.sprite = spriteOptions[randomIndex2];

        Debug.Log(randomIndex);
        Scene currentScene = SceneManager.GetActiveScene();

        if (IsStorymode == 0)
        {
            Destroy(gameObject);
        }
        if (Lose == 1)
        {
            Destroy(gameObject);
        }
        if (Win == 1)
        {
            Destroy(gameObject);
        }
        if (currentScene.name == "Win")
        {
            Debug.Log("We are in the Win scene");
            Destroy(gameObject);
        }
        if (currentScene.name == "Lose")
        {
            Debug.Log("We are in the Lose scene!");
            Destroy(gameObject);
        }
    }
    /*
    private void OnDestroy()
    {
        // Unsubscribe from the scene loaded event
        if (instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
    */

    public void FinishLevel()
    {
        NumberOfLevelsDone = NumberOfLevelsDone + 1;
    }
    

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the loaded scene is "Menu_Story"
        if (scene.name == "MenuStory")
        {
            menuStoryVisitCount++;
            Debug.Log($"Visited Menu_Story {menuStoryVisitCount} times.");
        }
    }

    /*
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string sceneName = scene.name;

        // Increment the visit count for the current scene
        if (sceneVisitCounts.ContainsKey(sceneName))
        {
            sceneVisitCounts[sceneName]++;
        }
        else
        {
            sceneVisitCounts[sceneName] = 1;
        }
        // Debug log for testing
        Debug.Log($"Visited {sceneName} {sceneVisitCounts[sceneName]} time(s).");
    }
    */

    // Update is called once per frame
    void Update()
    {
        
        //kill when enter normal level select
        


        if (randomIndex == randomIndex2)
        {
            
            randomIndex2 = Random.Range(0, spriteOptions.Length);
            SpriteRenderer spriteRenderer2 = Choise2.GetComponent<SpriteRenderer>();
            spriteRenderer2.sprite = spriteOptions[randomIndex2];
            Debug.Log("This is 2:");
            Debug.Log(randomIndex2);
        }
        if (OneHit == 1)
        {
            OneHit = 0;
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
