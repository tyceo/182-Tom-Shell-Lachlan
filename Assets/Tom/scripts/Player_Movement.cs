using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Player_Movement : MonoBehaviour
{

    public float moveSpeed = 5;
    public float velocity_x = 0;
    public float velocity_y = 0;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, (float)-0.5);

        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, (float)0.5);
        }


        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.right * Time.deltaTime * moveSpeed;
        }
    }
}



