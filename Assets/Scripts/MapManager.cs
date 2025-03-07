using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    [SerializeField] private GameObject firstFloorMap;
    [SerializeField] private GameObject secondFloorMap;

    private GameObject currentMap;

    private bool mapIsOpen;

    public bool firstFloor;


    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "Room1_1")
        {
            currentMap = firstFloorMap;
        }
        if (currentScene.name == "Room2_1")
        {
            currentMap = secondFloorMap;
        }

        if (Input.GetKeyDown(KeyCode.M) || Input.GetKeyDown(KeyCode.JoystickButton3))
        {
            if (mapIsOpen)
            {
                CloseMap();
            }
            else
            {
                OpenMap();
            }
        }
    }

    private void OpenMap()
    {
        currentMap.SetActive(true);
        mapIsOpen = true;
    }


    private void CloseMap()
    {
        currentMap.SetActive(false);
        mapIsOpen = false;
    }
}