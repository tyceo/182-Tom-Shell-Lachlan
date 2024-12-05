using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleFrying : MonoBehaviour
{

    private bool frying = false;
    [SerializeField] private Sprite slightlyCooked;
    [SerializeField] private Sprite cooked;
    [SerializeField] private Sprite overcooked;
    [SerializeField] private Sprite burntTentacle; 
    [SerializeField] TentacleManagerFrying tentacleManager;
    private bool finishedFrying;
    private bool burnt = false;


    private void Start()
    {
        tentacleManager = FindObjectOfType<TentacleManagerFrying>();
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Fryer")
        {
            frying = true;
            StartCoroutine(fryingTentacle());
            
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fryer")
        {
            frying = false;
            StopCoroutine(fryingTentacle());

            if (finishedFrying == true)
            {
                tentacleManager.TentacleFried();
            }
        }
    }


    private IEnumerator fryingTentacle()
    {
        Debug.Log("start frying");
        
        if (frying == true)
        {
            yield return new WaitForSecondsRealtime(1.4f);
            gameObject.GetComponent<SpriteRenderer>().sprite = slightlyCooked;
            yield return new WaitForSecondsRealtime(1.4f);
            gameObject.GetComponent<SpriteRenderer>().sprite = cooked;
            finishedFrying = true;
            yield return new WaitForSecondsRealtime(1.4f);
            gameObject.GetComponent<SpriteRenderer>().sprite = overcooked;
            yield return new WaitForSecondsRealtime(1.8f);
            gameObject.GetComponent<SpriteRenderer>().sprite = burntTentacle;
            burnt = true;
            finishedFrying = false;
        }
        if (frying == false)
        {
            Debug.Log("stopped frying");
        }
    }



}
