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

    //For Map check
    public GameObject cover1_1;
    public GameObject cover1_2;
    public GameObject cover1_3;
    public GameObject cover1_4;
    public GameObject cover1_5;
    public GameObject cover1_6;
    public GameObject cover1_7;
    public GameObject cover1_8;
    public GameObject cover1_9;
    public GameObject cover1_10;
    public GameObject cover1_11;
    public GameObject cover1_12;
    public GameObject cover1_13;
    public GameObject cover1_14;
    public GameObject coverkingsroom;
    public GameObject ServantsDoor;
    public GameObject HorseDoor;
    public GameObject EmeraldDoor;
    public GameObject CrownDoor;
    public GameObject OrangeDoor;


    public GameObject cover2_1;
    public GameObject cover2_2;
    public GameObject cover2_3;
    public GameObject cover2_4;
    public GameObject cover2_5;
    public GameObject cover2_6;
    public GameObject cover2_7;
    public GameObject cover2_8;
    public GameObject cover2_9;
    public GameObject cover2_10;
    public GameObject cover2_12;
    public GameObject cover2_13;
    public GameObject cover2_14;

    public GameObject SunDoor;
    public GameObject SapphireDoor;
    public GameObject CoinDoor;
    public GameObject SecondFloorDoor;


    // For area unlock
    public bool firstUnlocked;
    public bool hallwayUnlocked;
    public bool tunnelUnlocked;
    public bool servantsUnlocked;
    public bool basementUnlocked;
    public bool secondFloorUnlocked;
    public bool planetariumUnlocked;
    public bool meetingUnlocked;
    public bool coinUnlocked;
    public bool kingsUnlocked;

    private void Start()
    {
        if (firstUnlocked && cover1_1 != null)
        {
            cover1_1.SetActive(false);
        }
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

        // Destroying game objects for map exploration
        if (currentScene.name == "Room1_1")
        {
            Destroy(cover1_1);
        }

        if (currentScene.name == "Room1_2")
        {
            Destroy(cover1_2);
            ServantsDoor.SetActive(true);
            Destroy(OrangeDoor);
        }

        if (currentScene.name == "Room1_3")
        {
            Destroy(cover1_3);
        }

        if (currentScene.name == "Room1_4")
        {
            Destroy(cover1_4);
        }

        if (currentScene.name == "Room1_5")
        {
            Destroy(cover1_5);
        }

        if (currentScene.name == "Room1_6")
        {
            Destroy(cover1_6);
            Destroy(ServantsDoor);
        }

        if (currentScene.name == "Room1_7")
        {
            Destroy(cover1_7);
        }

        if (currentScene.name == "Room1_8")
        {
            Destroy(cover1_8);
        }

        if (currentScene.name == "Room1_9")
        {
            Destroy(cover1_9);
        }

        if (currentScene.name == "Room1_10")
        {
            Destroy(cover1_10);
            Destroy(HorseDoor);
        }

        if (currentScene.name == "Room1_11")
        {
            Destroy(cover1_11);
            Destroy(EmeraldDoor);
        }

        if (currentScene.name == "Room1_12")
        {
            Destroy(cover1_12);
        }

        if (currentScene.name == "Room1_13")
        {
            Destroy(cover1_13);
            HorseDoor.SetActive(true);
        }

        if (currentScene.name == "Room1_14")
        {
            Destroy(cover1_14);
        }

        if (currentScene.name == "KingsRoom")
        {
            Destroy(coverkingsroom);
            Destroy(CrownDoor);
        }

        // Second floor
        if (currentScene.name == "Room2_1")
        {
            Destroy(cover2_1);
        }

        if (currentScene.name == "Room2_2")
        {
            Destroy(cover2_2);
        }

        if (currentScene.name == "Room2_3")
        {
            Destroy(cover2_3);
            Destroy(SapphireDoor);
        }

        if (currentScene.name == "Room2_4")
        {
            Destroy(cover2_4);
        }

        if (currentScene.name == "Room2_5")
        {
            Destroy(cover2_5);
        }

        if (currentScene.name == "Room2_6")
        {
            Destroy(cover2_6);
        }

        if (currentScene.name == "Room2_7")
        {
            Destroy(cover2_7);
            Destroy(SunDoor);
        }

        if (currentScene.name == "Room2_8")
        {
            Destroy(cover2_8);
        }

        if (currentScene.name == "Room2_9")
        {
            Destroy(cover2_9);
        }

        if (currentScene.name == "Room2_10")
        {
            Destroy(cover2_10);
        }
        
        if (currentScene.name == "Room2_12")
        {
            Destroy(cover2_12);
        }

        if (currentScene.name == "Room2_13")
        {
            Destroy(cover2_13);
        }

        if (currentScene.name == "Room2_14")
        {
            Destroy(cover2_14);
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