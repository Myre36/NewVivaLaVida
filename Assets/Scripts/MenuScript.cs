using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    private DetermineController controllerDecider;

    private void Start()
    {
        controllerDecider = GameObject.Find("ControllerDecider").GetComponent<DetermineController>();
    }

    public void LoadFreeroam()
    {
        SceneManager.LoadScene("Room1_1");
    }
    public void LoadController()
    {
        controllerDecider.usingController = true;
        SceneManager.LoadScene("Room1_1");
    }

    public void LoadMenu()
    {
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

    public void Quit()
    {
        Application.Quit();
    }
}
