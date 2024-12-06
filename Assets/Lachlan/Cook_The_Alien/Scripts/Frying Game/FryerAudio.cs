using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryingAudio : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    private bool tentaclesInFryer = false;


    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();   
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tentaclesInFryer == false)
        {
            Debug.Log("frying sounds");
            source.Play();
        }
    }

    /*
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!tentaclesInFryer == false)
        {
            source.Stop();
        }

        tentaclesInFryer = false;
    }
    */

    private void OnTriggerStay2D(Collider2D collision)
    {
        tentaclesInFryer = true;


    }
}
