using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleManagerFrying : MonoBehaviour
{
    [SerializeField] private int friedTentacles;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (friedTentacles == 6)
        {
            Debug.Log("Won the Game");
        }
    }

    public void TentacleFried()
    {
        friedTentacles++;
    }


}
