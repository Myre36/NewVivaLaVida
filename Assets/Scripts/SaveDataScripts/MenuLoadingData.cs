using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class MenuLoadingData : MonoBehaviour
{
    private static MenuLoadingData instance;

    [SerializeField]
    private GameObject loadGameButton;

    public bool isLoadingData;

    private void Awake()
    {
        //This code is used to make sure there are never more than one game manager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string path = Application.persistentDataPath + "/player.dat";

        if(File.Exists(path))
        {
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(loadGameButton);
            Destroy(this.gameObject);
        }
    }

    public void StartLoadedGame()
    {
        isLoadingData = true;
        SceneManager.LoadScene("Room1_1");
    }
}
