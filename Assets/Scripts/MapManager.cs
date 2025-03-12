using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    [SerializeField] private GameObject firstFloorMap;
    [SerializeField] private GameObject secondFloorMap;

    private GameObject currentMap;

    private bool mapIsOpen;

    public bool firstFloor;

    public Animator mapAnimator;


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
                StartCoroutine(CloseMap());
            }
            else
            {
                StartCoroutine(OpenMap());
            }
        }
    }

    IEnumerator OpenMap()
    {
        mapIsOpen = true;
        mapAnimator.SetBool("IsOpen", true);
        yield return new WaitForSeconds(1f);
        currentMap.SetActive(true);
    }


    IEnumerator CloseMap()
    {
        mapIsOpen = false;
        mapAnimator.SetBool("IsOpen", false);
        yield return new WaitForSeconds(0.1f);
        currentMap.SetActive(false);
    }
}