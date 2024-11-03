using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionManager : MonoBehaviour
{
    public int question1Answer1 = 0;
    public int question1Answer2 = 0;
    public int question1Answer3 = 0;
    public QuestionController tmpTextChanger;
    public int currentQuestion = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentQuestion = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentQuestion == 1)
        {
            currentQuestion = 0;
            Question1();
        }
    }
    public void Question1()
    {
        
        tmpTextChanger.UpdateText("What is The Dwarf Planet?");
        tmpTextChanger.UpdateAnswer1Text("Pluto");
        tmpTextChanger.ChangeAnswer1TextColor(Color.green);
        tmpTextChanger.UpdateAnswer2Text("Pluto");
        tmpTextChanger.ChangeAnswer2TextColor(Color.red);
        tmpTextChanger.UpdateAnswer3Text("pluto");
        tmpTextChanger.ChangeAnswer3TextColor(Color.yellow);
    }
}
