using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    private Vector2 mousePosition;
    public bool hammerHovering;
    public Sprite hammerHit;
    public Sprite hammerNotHit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.Lerp(transform.position, mousePosition, 0.5f);

        if (hammerHovering == true && Input.GetMouseButtonDown(0))
        {
            Debug.Log("play that animation");
            StartCoroutine(AnimationHammer());
        }

    }

    private IEnumerator AnimationHammer()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().sprite = hammerHit;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().sprite = hammerNotHit;

    }

}
