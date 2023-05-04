using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");

    }
    public void Guide()
    {
        SceneManager.LoadScene("Guide");
    }
    public void About()
    {
        SceneManager.LoadScene("About");
    }
    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
    public void PauseAndContinue()
    {
        
        Time.timeScale = 0;
    }
    public void Continue()
    {
        Time.timeScale = 1;
    }
    /*public void test()
    {
        Debug.Log("Test");
    }*/
}
