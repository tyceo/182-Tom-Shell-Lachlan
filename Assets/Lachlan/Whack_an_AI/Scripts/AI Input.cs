using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIInput : MonoBehaviour
{
    [SerializeField] private AIManager manager;
    [SerializeField] private LightScript lights;
    [SerializeField] private Hammer hammer;
    [SerializeField] private Sprite AnimationFrame1;
    [SerializeField] private Sprite AnimationFrame2;
    [SerializeField] private Sprite AnimationFrame3;
    [SerializeField] private Sprite AnimationFrame4;
    [SerializeField] private Sprite AnimationFrame5;
    [SerializeField] private Sprite AnimationFrame6;


    [SerializeField] private bool mouseHovering = false;
    public bool aiEvil;
    public bool currentlyEvil = false;
    public int randomizedEvilIntervals;
    private bool dead;


    // Start is called before the first frame update
    void Start()
    {
        
        int EvilChance = Random.Range(0, 2);
        if (EvilChance == 0)
        {
            aiEvil = true;
            manager.evilAICount++;
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseHovering == true && dead != true)
        {

            if (Input.GetMouseButtonDown(0))
            {
                HitTheAI();
            }
        }


    }


    private void HitTheAI()
    {
        if(currentlyEvil == true)
        {
            manager.evilAICount--;
            dead = true;
            StartCoroutine(AnimationAI());
            
        }

        if(currentlyEvil == false)
        {
            manager.playerHealth--;
            Debug.LogWarning("WRONG");
        }
    }

    public void startEvilCoroutine()
    {
        
        StartCoroutine(createEvilEffect());
        Debug.Log("should be routing");
    }


    private IEnumerator AnimationAI()
    {
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().sprite = AnimationFrame1;
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().sprite = AnimationFrame2;
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().sprite = AnimationFrame3;
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().sprite = AnimationFrame4;
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().sprite = AnimationFrame5;
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().sprite = AnimationFrame6;
    }


    public IEnumerator createEvilEffect()
    {
        while (true)
        {
            randomizedEvilIntervals = Random.Range(1, 4);
            yield return new WaitForSeconds(randomizedEvilIntervals);
            Debug.Log("IM EVIL");
            currentlyEvil = true;
            lights.gameObject.GetComponent<SpriteRenderer>().sprite = lights.redLight;
            yield return new WaitForSeconds(2);
            currentlyEvil = false;
            Debug.Log("Not Evil");
            lights.SetColour();
            if (dead == true)
            {
                break;
            }
        }

    }


    private void OnMouseEnter()
    {
        mouseHovering = true;
        hammer.hammerHovering = true;
    }

    private void OnMouseExit()
    {
        mouseHovering = false;
        hammer.hammerHovering = false;
    }
}
