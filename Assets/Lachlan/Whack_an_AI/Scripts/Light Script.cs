using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightScript : MonoBehaviour
{
    [SerializeField] private AIInput aiReference;

    [SerializeField] private Sprite redLight;
    [SerializeField] private Sprite greenLight;
    [SerializeField] private Sprite blueLight;
    [SerializeField] private Sprite purpleLight;
    [SerializeField] private int colourChance;
    public UnityEvent evilEvent;



    // Start is called before the first frame update
    void Start()
    {
        evilEvent.AddListener(startLightCoroutines);
        colourChance = Random.Range(0, 3);
        SetColour();
        if (aiReference.aiEvil ==true)
        {
            evilEvent.Invoke();
        }
        
    }

    // Update is called once per frame
    void Update()
    {

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


    public void startLightCoroutines()
    {
        StartCoroutine(LightChangingCoroutine());
    }

    private IEnumerator LightChangingCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(aiReference.randomizedEvilIntervals);
            gameObject.GetComponent<SpriteRenderer>().sprite = redLight;
            yield return new WaitForSeconds(2);
            if (aiReference == null)
            {
                break;
            }
            SetColour();


        }
    }

}
