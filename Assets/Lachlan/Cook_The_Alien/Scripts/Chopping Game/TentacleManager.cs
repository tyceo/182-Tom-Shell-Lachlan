using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TentacleManager : MonoBehaviour
{
    private int Tentacles = 6;
    public Scene fryingScene;
    [SerializeField] private AlienSquirming alienSquirm;
    


    private void Start()
    {
        alienSquirm = FindObjectOfType<AlienSquirming>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Tentacles == 0) 
        {
            alienSquirm.AlienDead();


            Debug.Log("NO MORE TENTACLES");
            StartCoroutine(ChangeScene());
        }
    }

    public void ChangeTentacleAmount()
    {
        Tentacles--;
        alienSquirm.alienDistressMeter++;
    }


    public IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene("Lachlan_Cook_The_Alien_Scene_2", LoadSceneMode.Single);
    }


}
