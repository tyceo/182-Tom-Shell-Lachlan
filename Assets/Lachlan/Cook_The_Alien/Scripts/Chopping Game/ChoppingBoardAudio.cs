using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppingBoardAudio : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void choppingSound()
    {
        audioSource.Play();
    }

}
