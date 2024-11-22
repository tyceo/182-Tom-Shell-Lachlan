using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public int question1Answer1 = 0;
    public int question1Answer2 = 0;
    public int question1Answer3 = 0;
    public QuestionController tmpTextChanger;
    public int currentQuestion = 0;
    public int numberanswered = 0;
    public int correctAnswer = 1;
    public bool gameLost = false;
    public bool gameStillGoing = true;

    public SpriteRenderer targetSpriteRenderer; // Reference to the target object's SpriteRenderer
    public Sprite sprite1; // First sprite
    public Sprite sprite2; // Second sprite
    public Sprite sprite3; // Third sprite

    public SpriteRenderer bulletthing;


    public Slider progressBar;

    public RawImage winScreen; //lose
    public RawImage realwinScreen;
    public float duration = 15f; // Duration for progress to reach max, in seconds
    public string nextSceneName = "Tom_Asteroid_Dodger"; 

    private float elapsedTime = 0f; // Tracks the elapsed time
    public bool gameWon = false;

    //list
    private List<System.Action> functions; // List of functions
    private int currentIndex = 0;         // Tracks the next function to call in shuffled order
    private List<int> order;

    void Start()
    {
        targetSpriteRenderer.sprite = sprite1;
        bulletthing.sprite = sprite1;
        gameWon = false;
        gameLost = false;
        gameStillGoing = true;
        int question1Answer1 = 0;
        int question1Answer2 = 0;
        int question1Answer3 = 0;
        currentQuestion = 1;
        progressBar.value = 0; // Start progress at 0
        winScreen.color = new Color(winScreen.color.r, winScreen.color.g, winScreen.color.b, 0); // Make lose screen invisible
        realwinScreen.color = new Color(realwinScreen.color.r, realwinScreen.color.g, realwinScreen.color.b, 0); // Make win screen invisible

        //Question2();

        //list
        InitializeFunctions();
        NextFunction(); // Example: Call the first function at start
    }

    
    void Update()
    {
        if (gameLost == true)
        {
            ShowWinScreen(); //this is actually losing i am bad at nameing things
        }
        /*if (question1Answer1 == 1)
        {
            Debug.Log("answer received");
        }
        */      //just debug
        if (gameWon == true)
        {
            LoadNextScene();
        }

        if (!gameWon && gameStillGoing == true) //if not won timer go down
        {
            elapsedTime += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsedTime / duration);
            progressBar.value = progress * progressBar.maxValue;
            if (elapsedTime >= duration)
            {
                ShowWinScreen(); // Show the lose screen screen
                gameStillGoing = false;
            }
        }
        if (!gameWon && gameStillGoing == false)
        {
            elapsedTime = 1;
            progressBar.value = 1;

        }

            if (question1Answer1 == 1)
        {
            question1Answer1 = 0;
            Debug.Log("answer received");
            if (correctAnswer == 1)
            {
                NextFunction();
                if (currentQuestion == 3)
                {
                    //gameWon = true;
                    LoadNextScene();
                }
                if (currentQuestion == 2)
                {
                    currentQuestion = 3;
                }
                if (currentQuestion == 1)
                {
                    currentQuestion = 2;
                }
                
                
            }
            else if (correctAnswer == 2 || correctAnswer == 3)
            {
                gameLost = true;
            } 
        }

        if (question1Answer2 == 1)
        {
            
            question1Answer2 = 0;
            if (correctAnswer == 2)
            {
                NextFunction();
                if (currentQuestion == 3)
                {
                    //gameWon = true;
                    LoadNextScene();
                }
                if (currentQuestion == 2)
                {
                    currentQuestion = 3;
                }
                if (currentQuestion == 1)
                {
                    currentQuestion = 2;
                }
                


            }
            else if (correctAnswer == 1 || correctAnswer == 3)
            {
                gameLost = true;
            }
        }

        if (question1Answer3 == 1)
        {
            question1Answer3 = 0;
            if (correctAnswer == 3)
            {
                NextFunction();
                if (currentQuestion == 3)
                {
                    //gameWon = true;
                    LoadNextScene();
                }
                if (currentQuestion == 2)
                {
                    currentQuestion = 3;
                }
                if (currentQuestion == 1)
                {
                    currentQuestion = 2;
                }


            }
            else if (correctAnswer == 2 || correctAnswer == 1)
            {
                gameLost = true;
            }
        }
    }


    //list 
    void InitializeFunctions()
    {
        // Populate the list with your functions
        functions = new List<System.Action> { Question1, Question2, Question3, Question4, Question5, Question6, Question7, Question8, Question9, Question10, Question11, Question12, Question13, Question14, Question15 };

        // Create a shuffled order of indices
        order = new List<int>();
        for (int i = 0; i < functions.Count; i++)
            order.Add(i);

        // Shuffle the order
        for (int i = order.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            int temp = order[i];
            order[i] = order[randomIndex];
            order[randomIndex] = temp;
        }

        currentIndex = 0; // Reset the tracker
    }

    void NextFunction()
    {
        if (currentIndex >= order.Count)
        {
            Debug.Log("All functions have been called.");
            return;
        }

        // Get the next function index from the shuffled order
        int functionIndex = order[currentIndex];
        currentIndex++;

        // Call the corresponding function
        functions[functionIndex].Invoke();
    }

    private void ShowWinScreen() 
    {
        // Set the win screen image to fully visible
        winScreen.color = new Color(winScreen.color.r, winScreen.color.g, winScreen.color.b, 1);

        // Delay to give time for win screen to be visible before scene change
        //Invoke("LoadNextScene", 2f); // Change 2f to any delay time you want
    }

    private void LoadNextScene()
    {
        // Load the specified next scene
        SceneManager.LoadScene(nextSceneName);
        realwinScreen.color = new Color(realwinScreen.color.r, realwinScreen.color.g, realwinScreen.color.b, 1);
    }

    
    public void Question1()
    {
        correctAnswer = 1;
        tmpTextChanger.UpdateText("What is The Dwarf Planet?"); 
        tmpTextChanger.UpdateAnswer1Text("Pluto");
        tmpTextChanger.ChangeAnswer1TextColor(Color.black);
        tmpTextChanger.UpdateAnswer2Text("Pluto");
        tmpTextChanger.ChangeAnswer2TextColor(Color.black);
        tmpTextChanger.UpdateAnswer3Text("pluto");
        tmpTextChanger.ChangeAnswer3TextColor(Color.black);
        targetSpriteRenderer.sprite = sprite1;
        bulletthing.sprite = sprite1;
    }
    public void Question2()
    {
        correctAnswer = 1; 
        tmpTextChanger.UpdateText("Approximately how old is the Universe?"); 
        tmpTextChanger.UpdateAnswer1Text("13.7 Billion years old");
        tmpTextChanger.ChangeAnswer1TextColor(Color.green);
        tmpTextChanger.UpdateAnswer2Text("13.7 Million years old");
        tmpTextChanger.ChangeAnswer2TextColor(Color.red);
        tmpTextChanger.UpdateAnswer3Text("13.7 Thousand years old");
        tmpTextChanger.ChangeAnswer3TextColor(Color.blue);
    }
    public void Question3()
    {
        correctAnswer = 3;
        tmpTextChanger.UpdateText("What is the most common type of star found in the Milky Way?"); 
        tmpTextChanger.UpdateAnswer1Text("Blue Giant Stars");
        tmpTextChanger.ChangeAnswer1TextColor(Color.blue);
        tmpTextChanger.UpdateAnswer2Text("White Dwarf Stars");
        tmpTextChanger.ChangeAnswer2TextColor(Color.black);
        tmpTextChanger.UpdateAnswer3Text("Red Dwarf Stars");
        tmpTextChanger.ChangeAnswer3TextColor(Color.red);
    }
    public void Question4()
    {
        correctAnswer = 2;
        tmpTextChanger.UpdateText("What is at the center of the Milky Way galaxy?"); 
        tmpTextChanger.UpdateAnswer1Text("A black hole");
        tmpTextChanger.ChangeAnswer1TextColor(Color.black);
        tmpTextChanger.UpdateAnswer2Text("A black hole");
        tmpTextChanger.ChangeAnswer2TextColor(Color.black);
        tmpTextChanger.UpdateAnswer3Text("A black hole");
        tmpTextChanger.ChangeAnswer3TextColor(Color.black);
        targetSpriteRenderer.sprite = sprite2;
        bulletthing.sprite = sprite2;
    }
    public void Question5()
    {
        correctAnswer = 3;
        tmpTextChanger.UpdateText("Outside of the sun, what is the closest star to Earth?");
        tmpTextChanger.UpdateAnswer1Text("Alpha Centuari");
        tmpTextChanger.ChangeAnswer1TextColor(Color.black);
        tmpTextChanger.UpdateAnswer2Text("Alpha Centuari");
        tmpTextChanger.ChangeAnswer2TextColor(Color.black);
        tmpTextChanger.UpdateAnswer3Text("Alpha Centuari");
        tmpTextChanger.ChangeAnswer3TextColor(Color.black);
        targetSpriteRenderer.sprite = sprite2;
        bulletthing.sprite = sprite2;
    }
    public void Question6()
    {
        correctAnswer = 2;
        tmpTextChanger.UpdateText("Where is the Oort Cloud located?");
        tmpTextChanger.UpdateAnswer1Text("Between Mars and Jupiter");
        tmpTextChanger.ChangeAnswer1TextColor(Color.blue);
        tmpTextChanger.UpdateAnswer2Text("Past Pluto");
        tmpTextChanger.ChangeAnswer2TextColor(Color.black);
        tmpTextChanger.UpdateAnswer3Text("Beyond the Kuiper Belt");
        tmpTextChanger.ChangeAnswer3TextColor(Color.red);
    }
    public void Question7()
    {
        correctAnswer = 1;
        tmpTextChanger.UpdateText("Approximately how many miles is a lightyear?");
        tmpTextChanger.UpdateAnswer1Text("5.9 Trillion miles");
        tmpTextChanger.ChangeAnswer1TextColor(Color.blue);
        tmpTextChanger.UpdateAnswer2Text("1.9 Billion miles");
        tmpTextChanger.ChangeAnswer2TextColor(Color.black);
        tmpTextChanger.UpdateAnswer3Text("12.3 Million miles");
        tmpTextChanger.ChangeAnswer3TextColor(Color.red);
    }
    public void Question8()
    {
        correctAnswer = 2;
        tmpTextChanger.UpdateText("What accounts for approximately 85% of matter in the universe?");
        tmpTextChanger.UpdateAnswer1Text("Antimatter");
        tmpTextChanger.ChangeAnswer1TextColor(Color.blue);
        tmpTextChanger.UpdateAnswer2Text("Dark Matter");
        tmpTextChanger.ChangeAnswer2TextColor(Color.black);
        tmpTextChanger.UpdateAnswer3Text("Intergalactic Gas");
        tmpTextChanger.ChangeAnswer3TextColor(Color.red);
    }
    public void Question9()
    {
        correctAnswer = 1;
        tmpTextChanger.UpdateText("What is the coldest place in the universe?");
        tmpTextChanger.UpdateAnswer1Text("The Boomerang Nebula");
        tmpTextChanger.ChangeAnswer1TextColor(Color.black);
        tmpTextChanger.UpdateAnswer2Text("The Boomerang Nebula");
        tmpTextChanger.ChangeAnswer2TextColor(Color.black);
        tmpTextChanger.UpdateAnswer3Text("The Boomerang Nebula");
        tmpTextChanger.ChangeAnswer3TextColor(Color.black);
        targetSpriteRenderer.sprite = sprite1;
        bulletthing.sprite = sprite1;
    }
    public void Question10()
    {
        correctAnswer = 1;
        tmpTextChanger.UpdateText("What percent of the Milky Way is visible from Earth?");
        tmpTextChanger.UpdateAnswer1Text("0.000003%");
        tmpTextChanger.ChangeAnswer1TextColor(Color.blue);
        tmpTextChanger.UpdateAnswer2Text("0.5%");
        tmpTextChanger.ChangeAnswer2TextColor(Color.black);
        tmpTextChanger.UpdateAnswer3Text("1.3");
        tmpTextChanger.ChangeAnswer3TextColor(Color.red);
    }
    public void Question11()
    {
        correctAnswer = 2;
        tmpTextChanger.UpdateText("How many stars are in the Milky Way?");
        tmpTextChanger.UpdateAnswer1Text("100 Million");
        tmpTextChanger.ChangeAnswer1TextColor(Color.blue);
        tmpTextChanger.UpdateAnswer2Text("100 Billion");
        tmpTextChanger.ChangeAnswer2TextColor(Color.black);
        tmpTextChanger.UpdateAnswer3Text("100 Trillion");
        tmpTextChanger.ChangeAnswer3TextColor(Color.red);
    }
    public void Question12()
    {
        correctAnswer = 1;
        tmpTextChanger.UpdateText("What three things are comets made out of?");
        tmpTextChanger.UpdateAnswer1Text("Dust, rocks, and ice");
        tmpTextChanger.ChangeAnswer1TextColor(Color.blue);
        tmpTextChanger.UpdateAnswer2Text("Gases, crystals, and lava");
        tmpTextChanger.ChangeAnswer2TextColor(Color.black);
        tmpTextChanger.UpdateAnswer3Text("Metals, ice, and gas");
        tmpTextChanger.ChangeAnswer3TextColor(Color.red);
    }
    public void Question13()
    {
        correctAnswer = 3;
        tmpTextChanger.UpdateText("What is the name of the main theory that describes how our universe was created?");
        tmpTextChanger.UpdateAnswer1Text("The Cosmic Inflation Theory");
        tmpTextChanger.ChangeAnswer1TextColor(Color.blue);
        tmpTextChanger.UpdateAnswer2Text("The Steady State Theory");
        tmpTextChanger.ChangeAnswer2TextColor(Color.black);
        tmpTextChanger.UpdateAnswer3Text("The Big Bang Theory");
        tmpTextChanger.ChangeAnswer3TextColor(Color.red);
    }
    public void Question14()
    {
        correctAnswer = 3;
        tmpTextChanger.UpdateText("What type of galaxy is the Milky Way?");
        tmpTextChanger.UpdateAnswer1Text("Elliptical");
        tmpTextChanger.ChangeAnswer1TextColor(Color.blue);
        tmpTextChanger.UpdateAnswer2Text("Epic");
        tmpTextChanger.ChangeAnswer2TextColor(Color.black);
        tmpTextChanger.UpdateAnswer3Text("Spiral");
        tmpTextChanger.ChangeAnswer3TextColor(Color.red);
    }
    public void Question15()
    {
        correctAnswer = 3;
        tmpTextChanger.UpdateText("What is another name for the North Star?");
        tmpTextChanger.UpdateAnswer1Text("Sirius");
        tmpTextChanger.ChangeAnswer1TextColor(Color.blue);
        tmpTextChanger.UpdateAnswer2Text("Big bird");
        tmpTextChanger.ChangeAnswer2TextColor(Color.black);
        tmpTextChanger.UpdateAnswer3Text("Polaris");
        tmpTextChanger.ChangeAnswer3TextColor(Color.red);
    }


}
