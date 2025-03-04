using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void LoadFreeroam()
    {
        SceneManager.LoadScene("Room1_1");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void LoadIntro()
    {
        SceneManager.LoadScene("Introduction");
    }
}
