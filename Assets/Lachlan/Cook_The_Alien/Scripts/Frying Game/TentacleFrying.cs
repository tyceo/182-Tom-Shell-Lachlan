using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleFrying : MonoBehaviour
{

    private bool frying = false;
    [SerializeField] private Sprite Fried;
    [SerializeField] TentacleManagerFrying tentacleManager;
    private bool finishedFrying;

    private void Start()
    {
        tentacleManager = FindObjectOfType<TentacleManagerFrying>();
    }


    public void OnTriggerStay2D(Collider2D collision)
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
        yield return new WaitForSecondsRealtime(5);
        if (frying == true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Fried;
            finishedFrying = true;
        }
        if (frying == false)
        {
            Debug.Log("stopped frying");
        }
    }



}
