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

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
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
