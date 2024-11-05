using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TentacleChopping : MonoBehaviour
{
    [SerializeField] private GameObject choppedTentaclePrefab;
    private bool tentacleChopped = false;
    [SerializeField] private TentacleManager tentacleManager;
    [SerializeField] private GameObject correspondingChoppedTentacle;


    private void Start()
    {
            tentacleManager = (TentacleManager)FindAnyObjectByType(typeof(TentacleManager));
    }



    public void TentacleChopped()
    {
        if (tentacleChopped == false)
        {
            CreateChoppedTentacle();
            ChangeTentacleSprite();
            tentacleChopped = true;
            tentacleManager.ChangeTentacleAmount();
        }
        if (tentacleChopped == true)
        {
            Debug.Log("ALREADY CHOPPED");
        }
    }

    private void CreateChoppedTentacle()
    {
        correspondingChoppedTentacle.gameObject.SetActive(true);
    }


    private void ChangeTentacleSprite()
    {
        Destroy(gameObject); //Expand once there are sprites
    }
}
