using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public GameObject mainmenu;
    public GameObject levelselect;
    // Start is called before the first frame update
    void Start()
    {
        if (mainmenu != null) mainmenu.SetActive(true);
        if (levelselect != null) levelselect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void showlevelselect()
    {
        if (mainmenu != null) mainmenu.SetActive(false);
        if (levelselect != null) levelselect.SetActive(true);
    }
    public void quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void cookalien()
    {
        SceneManager.LoadScene("Lachlan_Cook_The_Alien");
    }
    public void aibad()
    {
        SceneManager.LoadScene("Lachlan_Wack_An_AI");
    }
    public void spaceship()
    {
        SceneManager.LoadScene("Tom_Asteroid_Dodger");
    }
    public void connectcable()
    {
        SceneManager.LoadScene("Tom_Connect_The_Cable");
    }
    public void trivia()
    {
        SceneManager.LoadScene("Shell_Shoot_The_Right_Planet");
    }
}
