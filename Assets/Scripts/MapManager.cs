using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    [SerializeField] private GameObject firstFloorMap;
    [SerializeField] private GameObject secondFloorMap;
    [SerializeField] private AudioSource openMapSound;
    [SerializeField] private AudioSource closeMapSound;

    private GameObject currentMap;

    private bool mapIsOpen;

    public bool firstFloor;

    public Animator mapAnimator;

    private void Start()
    {
        
    }

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

        if (Input.GetKeyDown(KeyCode.M))
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
        if (openMapSound != null)
        {
            openMapSound.Play();
        }
        mapIsOpen = true;
        mapAnimator.SetBool("IsOpen", true);
        
        yield return new WaitForSeconds(1f);
        currentMap.SetActive(true);

       
    }


    IEnumerator CloseMap()
    {
        if (closeMapSound != null)
        {
            closeMapSound.Play();
        }
        
        mapIsOpen = false;
        mapAnimator.SetBool("IsOpen", false);
        yield return new WaitForSeconds(0.1f);
        currentMap.SetActive(false);

        
    }
}