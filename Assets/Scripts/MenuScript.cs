using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void LoadFreeroam()
    {
        SceneManager.LoadScene("Room1_1");
    }
    public void LoadController()
    {
        gameManager.usingController = true;
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

    public void LoadCreditsScene()
    {
        SceneManager.LoadScene("CreditsScene");
    }
}
