using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIInput : MonoBehaviour
{
    [SerializeField] private AIManager manager;
    [SerializeField] private LightScript lights;

    private bool mouseHovering = false;
    public bool aiEvil;
    public bool currentlyEvil = false;
    public int randomizedEvilIntervals;

    // Start is called before the first frame update
    void Start()
    {
        
        int EvilChance = Random.Range(0, 2);
        if (EvilChance == 0)
        {
            aiEvil = true;
            manager.evilAICount++;
        }
        
        lights.evilEvent.AddListener(startEvilCoroutine);
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseHovering == true)
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
            Destroy(gameObject); //play animation then destroy
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
    }

    public IEnumerator createEvilEffect()
    {
        while (true)
        {
            randomizedEvilIntervals = Random.Range(1, 4);
            yield return new WaitForSeconds(randomizedEvilIntervals);
            Debug.Log("IM EVIL");
            currentlyEvil = true;
            yield return new WaitForSeconds(2);
            currentlyEvil = false;
            Debug.Log("Not Evil");
        }

    }


    private void OnMouseEnter()
    {
        
        mouseHovering = true;
    }

    private void OnMouseExit()
    {
        mouseHovering = false;
    }
}
