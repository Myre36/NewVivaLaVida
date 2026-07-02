using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    [SerializeField] private GameObject firstFloorMap;
    [SerializeField] private GameObject secondFloorMap;
    [SerializeField] private AudioSource openMapSound;
    [SerializeField] private AudioSource closeMapSound;

    public GameObject currentMap;

    public bool mapIsOpen;

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
    public GameObject BlueCrownDoor;
    public GameObject RedCrownDoor;
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
    /*public bool hallwayUnlocked;
    public bool tunnelUnlocked;
    public bool servantsUnlocked;
    public bool basementUnlocked;
    public bool secondFloorUnlocked;
    public bool planetariumUnlocked;
    public bool meetingUnlocked;
    public bool coinUnlocked;
    public bool kingsUnlocked;*/
    public bool unlocked1_2;
    public bool unlocked1_3;
    public bool unlocked1_4;
    public bool unlocked1_5;
    public bool unlocked1_6;
    public bool unlocked1_7;
    public bool unlocked1_8;
    public bool unlocked1_9;
    public bool unlocked1_10;
    public bool unlocked1_11;
    public bool unlocked1_12;
    public bool unlocked1_13;
    public bool unlocked1_14;

    public bool unlockedKingsRoom;
    public bool unlocked2_1;
    public bool unlocked2_2;
    public bool unlocked2_3;
    public bool unlocked2_4;
    public bool unlocked2_5;
    public bool unlocked2_6;
    public bool unlocked2_7;
    public bool unlocked2_8;
    public bool unlocked2_9;
    public bool unlocked2_10;
    public bool unlocked2_12;
    public bool unlocked2_13;
    public bool unlocked2_14;

    public GameObject chest1Icon;
    public GameObject chest2Icon;
    public GameObject chest3Icon;
    public GameObject chest4Icon;
    public GameObject chest5Icon;
    public GameObject chest6Icon;
    public GameObject chest7Icon;
    public GameObject chest8Icon;
    public GameObject chest9Icon;
    public GameObject chest10Icon;


    [SerializeField]
    private Movement player;

    [SerializeField]
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
    }

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

        if (Input.GetKeyDown(KeyCode.M) && !player.inMandatory && !player.inDialouge)
        {
            if(player.inventoryIsOpen)
            {
                return;
            }

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
        if (currentScene.name == "Room1_1" && !firstUnlocked)
        {
            Destroy(cover1_1);
            firstUnlocked = true;
        }

        if (currentScene.name == "Room1_2" && !unlocked1_2)
        {
            Destroy(cover1_2);
            if(!unlocked1_6)
            {
                ServantsDoor.SetActive(true);
            }
            Destroy(OrangeDoor);
            unlocked1_2 = true;
        }

        if (currentScene.name == "Room1_3" && !unlocked1_3)
        {
            Destroy(cover1_3);
            unlocked1_3 = true;
        }

        if (currentScene.name == "Room1_4" && !unlocked1_4)
        {
            Destroy(cover1_4);
            unlocked1_4 = true;
        }

        if (currentScene.name == "Room1_5" && !unlocked1_5)
        {
            Destroy(cover1_5);
            unlocked1_5 = true;
        }

        if (currentScene.name == "Room1_6" && !unlocked1_6)
        {
            Destroy(cover1_6);
            Destroy(ServantsDoor);
            unlocked1_6 = true;
        }

        if (currentScene.name == "Room1_7" && !unlocked1_7)
        {
            Destroy(cover1_7);
            unlocked1_7 = true;
        }

        if (currentScene.name == "Room1_8" && !unlocked1_8)
        {
            Destroy(cover1_8);
            unlocked1_8 = true;
        }

        if (currentScene.name == "Room1_9" && !unlocked1_9)
        {
            Destroy(cover1_9);
            unlocked1_9 = true;
        }

        if (currentScene.name == "Room1_10" && !unlocked1_10)
        {
            Destroy(cover1_10);
            Destroy(HorseDoor);
            unlocked1_10 = true;
        }

        if (currentScene.name == "Room1_11" && !unlocked1_11)
        {
            Destroy(cover1_11);
            Destroy(EmeraldDoor);
            unlocked1_11 = true;
        }

        if (currentScene.name == "Room1_12" && !unlocked1_12)
        {
            Destroy(cover1_12);
            unlocked1_12 = true;
        }

        if (currentScene.name == "Room1_13" && !unlocked1_13)
        {
            Destroy(cover1_13);
            if(!unlocked1_10)
            {
                HorseDoor.SetActive(true);
            }
            unlocked1_13 = true;
        }

        if (currentScene.name == "Room1_14" && !unlocked1_14)
        {
            Destroy(cover1_14);
            unlocked1_14 = true;
        }

        if (currentScene.name == "KingsRoom" && !unlockedKingsRoom)
        {
            Destroy(coverkingsroom);
            Destroy(RedCrownDoor);
            Destroy(BlueCrownDoor);
            unlockedKingsRoom = true;
        }

        // Second floor
        if (currentScene.name == "Room2_1" && !unlocked2_1)
        {
            Destroy(cover2_1);
            unlocked2_1 = true;
        }

        if (currentScene.name == "Room2_2" && !unlocked2_2)
        {
            Destroy(cover2_2);
            if(!unlocked2_3)
            {
                SapphireDoor.SetActive(true);
            }
            unlocked2_2 = true;
        }

        if (currentScene.name == "Room2_3" && !unlocked2_3)
        {
            Destroy(cover2_3);
            Destroy(SapphireDoor);
            unlocked2_3 = true;
        }

        if (currentScene.name == "Room2_4" && !unlocked2_4)
        {
            Destroy(cover2_4);
            unlocked2_4 = true;
        }

        if (currentScene.name == "Room2_5" && !unlocked2_5)
        {
            Destroy(cover2_5);
            unlocked2_5 = true;
        }

        if (currentScene.name == "Room2_6" && !unlocked2_6)
        {
            Destroy(cover2_6);
            unlocked2_6 = true;
        }

        if (currentScene.name == "Room2_7" && !unlocked2_7)
        {
            Destroy(cover2_7);
            Destroy(SunDoor);
            unlocked2_7 = true;
        }

        if (currentScene.name == "Room2_8" && !unlocked2_8)
        {
            Destroy(cover2_8);
            if(!unlocked2_12)
            {
                CoinDoor.SetActive(true);
            }
            unlocked2_8 = true;
        }

        if (currentScene.name == "Room2_9" && !unlocked2_9)
        {
            Destroy(cover2_9);
            unlocked2_9 = true;
        }

        if (currentScene.name == "Room2_10" && !unlocked2_10)
        {
            Destroy(cover2_10);
            unlocked2_10 = true;
        }
        
        if (currentScene.name == "Room2_12" && !unlocked2_12)
        {
            Destroy(cover2_12);
            Destroy(CoinDoor);
            unlocked2_12 = true;
        }

        if (currentScene.name == "Room2_13" && !unlocked2_13)
        {
            Destroy(cover2_13);
            unlocked2_13 = true;
        }

        if (currentScene.name == "Room2_14" && !unlocked2_14)
        {
            Destroy(cover2_14);
            unlocked2_14 = true;
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

    public void StartCloseMap()
    {
        StartCoroutine(CloseMap());
    }

    public void LoadedMap()
    {
        Debug.Log("Starting to delete covers");

        if (firstUnlocked)
        {
            Destroy(cover1_1);
        }
        if(unlocked1_2)
        {
            Destroy(cover1_2);
            if(!unlocked1_6)
            {
                ServantsDoor.SetActive(true);
            }
            Destroy(OrangeDoor);
        }
        if (unlocked1_3)
        {
            Destroy(cover1_3);
        }
        if (unlocked1_4)
        {
            Destroy(cover1_4);
        }
        if (unlocked1_5)
        {
            Destroy(cover1_5);
        }
        if (unlocked1_6)
        {
            Destroy(cover1_6);
            Destroy(ServantsDoor);
        }
        if (unlocked1_7)
        {
            Destroy(cover1_7);
        }
        if (unlocked1_8)
        {
            Destroy(cover1_8);
        }
        if (unlocked1_9)
        {
            Destroy(cover1_9);
        }
        if (unlocked1_10)
        {
            Destroy(cover1_10);
            Destroy(HorseDoor);
        }
        if (unlocked1_11)
        {
            Destroy(cover1_11);
            Destroy(EmeraldDoor);
        }
        if (unlocked1_12)
        {
            Destroy(cover1_12);
        }
        if (unlocked1_13)
        {
            Destroy(cover1_13);
            if(!unlocked1_10)
            {
                HorseDoor.SetActive(true);
            }
        }
        if (unlocked1_14)
        {
            Destroy(cover1_14);
        }
        if (unlockedKingsRoom)
        {
            Destroy(coverkingsroom);
            Destroy(RedCrownDoor);
            Destroy(BlueCrownDoor);
        }
        if (unlocked2_1)
        {
            Destroy(cover2_1);
        }
        if (unlocked2_2)
        {
            Destroy(cover2_2);
            if(!unlocked2_3)
            {
                SapphireDoor.SetActive(true);
            }
        }
        if (unlocked2_3)
        {
            Destroy(cover2_3);
            Destroy(SapphireDoor);
        }
        if (unlocked2_4)
        {
            Destroy(cover2_4);
        }
        if (unlocked2_5)
        {
            Destroy(cover2_5);
        }
        if (unlocked2_6)
        {
            Destroy(cover2_6);
        }
        if (unlocked2_7)
        {
            Destroy(cover2_7);
            Destroy(SunDoor);
        }
        if (unlocked2_8)
        {
            Destroy(cover2_8);
            if(!unlocked1_12)
            {
                CoinDoor.SetActive(true);
            }
        }
        if (unlocked2_9)
        {
            Destroy(cover2_9);
        }
        if (unlocked2_10)
        {
            Destroy(cover2_10);
        }
        if (unlocked2_12)
        {
            Destroy(cover2_12);
            Destroy(CoinDoor);
        }
        if (unlocked2_13)
        {
            Destroy(cover2_13);
        }
        if (unlocked2_14)
        {
            Destroy(cover2_14);
        }

        Debug.Log("Starting to delete chest icons");

        if(gameManager == null)
        {
            gameManager = GetComponent<GameManager>();
        }

        if (gameManager.chest1)
        {
            Destroy(chest1Icon);
        }
        if (gameManager.chest2)
        {
            Destroy(chest2Icon);
        }
        if (gameManager.chest3)
        {
            Destroy(chest3Icon);
        }
        if (gameManager.chest4)
        {
            Destroy(chest4Icon);
        }
        if (gameManager.chest5)
        {
            Destroy(chest5Icon);
        }
        if (gameManager.chest6)
        {
            Destroy(chest6Icon);
        }
        if (gameManager.chest7)
        {
            Destroy(chest7Icon);
        }
        if (gameManager.chest8)
        {
            Destroy(chest8Icon);
        }
        if (gameManager.chest9)
        {
            Destroy(chest9Icon);
        }
        if (gameManager.chest10)
        {
            Destroy(chest10Icon);
        }

        Debug.Log("Finished deleting chest icons");
    }
}