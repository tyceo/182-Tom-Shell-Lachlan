using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour
{
    public Sprite[] spriteOptions;
    public int randomIndex;
    public int randomIndex2;
    // Reference to the object whose sprite will change
    public GameObject Choise1;
    public GameObject Choise2;
    public int OneHit;
    public int OneHit2;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        OneHit = 0;
        OneHit2 = 0;
        randomIndex = Random.Range(0, spriteOptions.Length);
        randomIndex2 = Random.Range(0, spriteOptions.Length);

        SpriteRenderer spriteRenderer = Choise1.GetComponent<SpriteRenderer>();
        SpriteRenderer spriteRenderer2 = Choise2.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteOptions[randomIndex];
        spriteRenderer2.sprite = spriteOptions[randomIndex2];
    }

    // Update is called once per frame
    void Update()
    {
        if (randomIndex == randomIndex2)
        {
            Debug.Log(randomIndex);
            randomIndex2 = Random.Range(0, spriteOptions.Length);
            SpriteRenderer spriteRenderer2 = Choise2.GetComponent<SpriteRenderer>();
            spriteRenderer2.sprite = spriteOptions[randomIndex2];
        }
        if (OneHit == 1)
        {
            OneHit = 0;
            if (randomIndex == 0)
            {
                cookalien();
            }
            if (randomIndex == 1)
            {
                aibad();
            }
            if (randomIndex == 2)
            {
                spaceship();
            }
            if (randomIndex == 3)
            {
                connectcable();
            }
            if (randomIndex == 4)
            {
                trivia();
            }
        }

        if (OneHit2 == 1)
        {
            OneHit2 = 0;
            if (randomIndex2 == 0)
            {
                cookalien();
            }
            if (randomIndex2 == 1)
            {
                aibad();
            }
            if (randomIndex2 == 2)
            {
                spaceship();
            }
            if (randomIndex2 == 3)
            {
                connectcable();
            }
            if (randomIndex2 == 4)
            {
                trivia();
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
    public void spaceship()
    {
        SceneManager.LoadScene("Tom_Asteroid_Dodger");
    }
    public void connectcable()
    {
        SceneManager.LoadScene("Tom_Connect_The_Cable");
    }
    public void trivia()
    {
        SceneManager.LoadScene("Shell_Shoot_The_Right_Planet");
    }
}
