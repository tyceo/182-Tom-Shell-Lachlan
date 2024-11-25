using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightScript : MonoBehaviour
{
    [SerializeField] private AIInput AIReference;

    [SerializeField] private Sprite redLight;
    [SerializeField] private Sprite greenLight;
    [SerializeField] private Sprite blueLight;
    [SerializeField] private Sprite purpleLight;
    [SerializeField] private int colourChance;
    public UnityEvent evilEvent;



    // Start is called before the first frame update
    void Start()
    {
        colourChance = Random.Range(0, 3);
        SetColour();
        if (AIReference.AiEvil ==true)
        {
            evilEvent.Invoke();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (AIReference.AiEvil == true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = redLight;
        }

    }

    private void SetColour()
    {
        if (colourChance == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = greenLight;
        }
        else if (colourChance == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = blueLight;
        }
        else if (colourChance == 2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = purpleLight;
        }
    }


}
