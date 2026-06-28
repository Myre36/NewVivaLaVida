using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class MenuLoadingData : MonoBehaviour
{
    [SerializeField]
    private GameObject loadGameButton;

    public bool isLoadingData;

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
