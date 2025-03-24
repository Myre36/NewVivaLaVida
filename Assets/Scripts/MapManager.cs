using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    [SerializeField] private GameObject firstFloorMap;
    [SerializeField] private GameObject secondFloorMap;
    [SerializeField] private AudioClip openMapSound;
    [SerializeField] private AudioClip closeMapSound;

    private GameObject currentMap;

    private bool mapIsOpen;

    public bool firstFloor;

    public Animator mapAnimator;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            audioSource.PlayOneShot(openMapSound);
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
            audioSource.PlayOneShot(closeMapSound);
        }
        
        mapIsOpen = false;
        mapAnimator.SetBool("IsOpen", false);
        yield return new WaitForSeconds(0.1f);
        currentMap.SetActive(false);

        
    }
}