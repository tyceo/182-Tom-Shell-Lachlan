using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TentacleManager : MonoBehaviour
{
    private int Tentacles = 5;
    public Scene fryingScene;


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
            StartCoroutine(ChangeScene());
        }
    }

    public void ChangeTentacleAmount()
    {
        Tentacles--;
    }

    


    public IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene("Lachlan_Cook_The_Alien_Scene_2", LoadSceneMode.Single);
    }


}
