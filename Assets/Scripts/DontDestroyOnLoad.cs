using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{
    //This is just a DontDestroyOnLoad script

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    //Destroys the object if it enters certain scenes
    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "Main Menu")
        {
            Destroy(this.gameObject);
        }
        if (currentScene.name == "Death scene")
        {
            Destroy(this.gameObject);
        }
    }
}
