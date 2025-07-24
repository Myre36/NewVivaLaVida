using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    //Functions for loading all the levels

    public void LoadFreeroam()
    {
        SceneManager.LoadScene("Room1_1");
    }

    public void LoadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadIntro()
    {
        SceneManager.LoadScene("Introduction");
    }

    public void LoadCreditsScene()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void LoadBalcony()
    {
        SceneManager.LoadScene("Room2_14");
    }

    public void LoadBoss()
    {
        SceneManager.LoadScene("KingsRoom");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
