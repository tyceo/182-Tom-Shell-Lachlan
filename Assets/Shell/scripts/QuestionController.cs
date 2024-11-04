using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionController : MonoBehaviour
{
    public TMP_Text textElement;  // Assign the TextMeshPro element in the Inspector
    public TMP_Text answer1Text;
    public TMP_Text answer2Text;    // Answer2 text element
    public TMP_Text answer3Text;

    // Method to update the text
    public void UpdateText(string newText)
    {
        textElement.text = newText;
    }
    public void UpdateAnswer1Text(string newText)
    {
        answer1Text.text = newText;
    }
    public void UpdateAnswer2Text(string newText)
    {
        answer2Text.text = newText;
    }

    public void UpdateAnswer3Text(string newText)
    {
        answer3Text.text = newText;
    }

    public void ChangeAnswer1TextColor(Color newColor)
    {
        answer1Text.color = newColor;
    }
    public void ChangeAnswer2TextColor(Color newColor)
    {
        answer2Text.color = newColor;
    }

    public void ChangeAnswer3TextColor(Color newColor)
    {
        answer3Text.color = newColor;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
