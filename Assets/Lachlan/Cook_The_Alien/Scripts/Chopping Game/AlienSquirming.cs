using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSquirming : MonoBehaviour
{
    public float alienDistressMeter = 0f;
    private Vector3 alienTargetPosition;
    
    


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NewTargetPosition());
    }

    // Update is called once per frame
    void Update()
    {
        
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, alienTargetPosition, alienDistressMeter * Time.deltaTime);

        if (gameObject.transform.position == alienTargetPosition)
        {
            alienTargetPosition = new Vector2(Random.Range(-7f, 1f), Random.Range(3.62f, -2.88f));
        }


    }

    public void AlienDead()
    {
        alienDistressMeter = 0f;
    }


    public IEnumerator NewTargetPosition()
    {
        yield return new WaitForSecondsRealtime(1);

        alienTargetPosition = new Vector2(Random.Range(-7f, 1f), Random.Range(3.62f, -2.88f));

        StartCoroutine(NewTargetPosition());
    }


}
