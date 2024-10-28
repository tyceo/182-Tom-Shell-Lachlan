using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleManager : MonoBehaviour
{
    private int Tentacles = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Tentacles == 0) 
        {
            Debug.Log("NO MORE TENTACLES");
        }
    }

    public void ChangeTentacleAmount()
    {
        Tentacles--;
    }

}
