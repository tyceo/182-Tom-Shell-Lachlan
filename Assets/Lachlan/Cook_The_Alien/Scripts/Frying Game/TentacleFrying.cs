using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleFrying : MonoBehaviour
{

    private bool frying = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        }
    }


    private IEnumerator fryingTentacle()
    {
        Debug.Log("start frying");
        yield return new WaitForSecondsRealtime(5);
        if (frying == true)
        {
            Destroy(gameObject);
        }
        if (frying == false)
        {
            Debug.Log("stopped frying");
        }
    }



}
