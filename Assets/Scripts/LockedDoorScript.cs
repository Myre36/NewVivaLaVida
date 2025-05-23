using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LockedDoorScript : MonoBehaviour
{
    //A refrence to the door script
    private DoorScript doorScript;

    //A refrence to the game manager
    private GameManager gameManager;

    //A refrence to the player movement script
    public Movement player;

    //Bool for if you are on the second floor
    public bool onSecondFloor;
    //Bool to check if the player is in rnage of the door
    public bool playerInRange;
    //Bools to check what door this is
    public bool firstDoor;
    public bool hallwayDoor;
    public bool servantsDoor;
    public bool planeteriumDoor;
    public bool secondFloorDoor;
    public bool meetingDoor;
    public bool libraryDoor;
    public bool tunnelDoor;
    public bool coinDoor;
    public bool basementDoor;
    public bool kingsDoor;
    //A bool to check if the player is already in dialouge
    private bool inDialouge;

    //A refrence to the dialouge box
    public GameObject dialougeBox;
    //Refrence to the lock
    public GameObject hanglock;

    //A refrence to the dialouge text
    public TMP_Text dialougeText;

    public AudioSource unlockSound;
    public AudioSource doorlockedSound;
    public AudioSource puzzlecompletedSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Assigning all the refrences
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("Player").GetComponent<Movement>();
        doorScript = this.GetComponent<DoorScript>();
        dialougeBox = GameObject.Find("DialougeBox");
        dialougeText = GameObject.Find("DialougeText").GetComponent<TMP_Text>();

        //The below code is just to check if the player has already unlocked this door. If they have, this door will unlock
        if(hallwayDoor)
        {
            if (gameManager.hallwayUnlocked)
            {
                doorScript.enabled = true;
                Destroy(hanglock);
                this.enabled = false;
            }
        }
        else if (firstDoor)
        {
            if (gameManager.firstUnlocked)
            {
                doorScript.enabled = true;
                Destroy(hanglock);
                this.enabled = false;
            }
        }
        else if (tunnelDoor)
        {
            if(gameManager.tunnelUnlocked)
            {
                doorScript.enabled = true;
                Destroy(hanglock);
                this.enabled = false;
            }
        }
        else if(servantsDoor)
        {
            if(gameManager.servantsUnlocked)
            {
                doorScript.enabled = true;
                Destroy(hanglock);
                this.enabled = false;
            }
        }
        else if(basementDoor)
        {
            if(gameManager.basementUnlocked)
            {
                doorScript.enabled = true;
                Destroy(hanglock);
                this.enabled = false;
            }
        }
        else if (secondFloorDoor)
        {
            if (gameManager.secondFloorUnlocked)
            {
                doorScript.enabled = true;
                Destroy(hanglock);
                this.enabled = false;
            }
        }
        else if(planeteriumDoor)
        {
            if (gameManager.planetariumUnlocked)
            {
                doorScript.enabled = true;
                Destroy(hanglock);
                this.enabled = false;
            }
        }
        else if (meetingDoor)
        {
            if (gameManager.meetingUnlocked)
            {
                doorScript.enabled = true;
                Destroy(hanglock);
                this.enabled = false;
            }
        }
        else if (coinDoor)
        {
            if (gameManager.coinUnlocked)
            {
                doorScript.enabled = true;
                Destroy(hanglock);
                this.enabled = false;
            }
        }
        else if (kingsDoor)
        {
            if (gameManager.kingsUnlocked)
            {
                doorScript.enabled = true;
                Destroy(hanglock);
                this.enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //If the player is in range of the door and presses the interaction key
        if(playerInRange)
        {
            if(Input.GetKeyDown(KeyCode.E) && !player.inMandatory)
            {
                //Freezes the player and turns on the dialouge
                player.enabled = false;
                dialougeBox.GetComponent<RawImage>().enabled = true;
                dialougeText.enabled = true;
                //It will check what door this is, and then check if you have the key to it. If you don't, it will display dialouge that tells you its locked. If you do, the door will unlock
                if (hallwayDoor)
                {
                    if (gameManager.hallwayKey)
                    {
                        if(inDialouge)
                        {
                            gameManager.hallwayUnlocked = true;
                            UnlockDoor();
                        }
                        else
                        {
                            inDialouge = true;
                            unlockSound.Play();
                            dialougeText.text = "You unlocked the east hallway.";
                        }
                    }
                    else
                    {
                        if(inDialouge)
                        {
                            CloseDialouge();
                        }
                        else
                        {
                            inDialouge = true;
                            dialougeText.text = "The door is locked. An orange citrine gemstone is engraved into the door.";
                            doorlockedSound.Play();
                        }
                    }
                }
                else if (firstDoor)
                {
                    if (gameManager.firstKey)
                    {
                        if (inDialouge)
                        {
                            gameManager.firstUnlocked = true;
                            UnlockDoor();
                        }
                        else
                        {
                            inDialouge = true;
                            unlockSound.Play();
                            dialougeText.text = "You unlocked the west hallway.";
                        }
                    }
                    else
                    {
                        if (inDialouge)
                        {
                            CloseDialouge();
                        }
                        else
                        {
                            inDialouge = true;
                            dialougeText.text = "The door is locked. A large emerald gemstone is engraved into the door.";
                            doorlockedSound.Play();
                        }
                    }
                }
                else if(tunnelDoor)
                {
                    if (gameManager.tunnelKey)
                    {
                        if (inDialouge)
                        {
                            gameManager.tunnelUnlocked = true;
                            UnlockDoor();
                        }
                        else
                        {
                            inDialouge = true;
                            unlockSound.Play();
                            dialougeText.text = "You unlocked the secret tunnel.";
                        }
                    }
                    else
                    {
                        if (inDialouge)
                        {
                            CloseDialouge();
                        }
                        else
                        {
                            inDialouge = true;
                            dialougeText.text = "A small door is hidden behind the small cupboard. It is locked with a horse-shaped lock.";
                            doorlockedSound.Play();
                        }
                    }
                }
                else if(servantsDoor)
                {
                    if (gameManager.servantsKey)
                    {
                        if (inDialouge)
                        {
                            gameManager.servantsUnlocked = true;
                            UnlockDoor();
                        }
                        else
                        {
                            inDialouge = true;
                            unlockSound.Play();
                            dialougeText.text = "You unlocked the servant's quarters.";
                        }
                    }
                    else
                    {
                        if (inDialouge)
                        {
                            CloseDialouge();
                        }
                        else
                        {
                            inDialouge = true;
                            dialougeText.text = "The door is locked. The wood is worn out, and it is decorated with a large S emblem.";
                            doorlockedSound.Play();
                        }
                    }
                }
                else if(basementDoor)
                {
                    if (gameManager.basementKey)
                    {
                        if (inDialouge)
                        {
                            gameManager.basementUnlocked = true;
                            UnlockDoor();
                        }
                        else
                        {
                            inDialouge = true;
                            unlockSound.Play();
                            dialougeText.text = "You unlocked the basement.";
                        }
                    }
                    else
                    {
                        if (inDialouge)
                        {
                            CloseDialouge();
                        }
                        else
                        {
                            inDialouge = true;
                            dialougeText.text = "The basement door is locked with large, old lock. Whatever key unlocks this must be old and rusty.";
                            doorlockedSound.Play();
                        }
                    }
                }
                else if (secondFloorDoor)
                {
                    if (gameManager.secondFloorKey)
                    {
                        if (inDialouge)
                        {
                            gameManager.secondFloorUnlocked = true;
                            UnlockDoor();
                        }
                        else
                        {
                            inDialouge = true;
                            unlockSound.Play();
                            dialougeText.text = "You unlocked the second floor.";
                        }
                    }
                    else
                    {
                        if (inDialouge)
                        {
                            CloseDialouge();
                        }
                        else
                        {
                            inDialouge = true;
                            dialougeText.text = "The door to the second floor is locked. Maybe you can find the key lying around somewhere?";
                            doorlockedSound.Play();
                        }
                    }
                }
                else if (planeteriumDoor)
                {
                    if (gameManager.planetariumKey)
                    {
                        if (inDialouge)
                        {
                            gameManager.planetariumUnlocked = true;
                            UnlockDoor();
                        }
                        else
                        {
                            inDialouge = true;
                            unlockSound.Play();
                            dialougeText.text = "You unlocked the planetarium.";
                        }
                    }
                    else
                    {
                        if (inDialouge)
                        {
                            CloseDialouge();
                        }
                        else
                        {
                            inDialouge = true;
                            dialougeText.text = "The door is locked. The doorknob is shaped like a sun.";
                            doorlockedSound.Play();
                        }
                    }
                }
                else if (meetingDoor)
                {
                    if (gameManager.meetingKey)
                    {
                        if (inDialouge)
                        {
                            gameManager.meetingUnlocked = true;
                            UnlockDoor();
                        }
                        else
                        {
                            inDialouge = true;
                            unlockSound.Play();
                            dialougeText.text = "You unlocked the meeting room.";
                        }
                    }
                    else
                    {
                        if (inDialouge)
                        {
                            CloseDialouge();
                        }
                        else
                        {
                            inDialouge = true;
                            dialougeText.text = "The door is locked. The door is engraved with a large saphire stone.";
                            doorlockedSound.Play();
                        }
                    }
                }
                else if (coinDoor)
                {
                    if (gameManager.coinOne && gameManager.coinTwo && gameManager.coinThree)
                    {
                        if (inDialouge)
                        {
                            gameManager.coinUnlocked = true;
                            for (int i = 0; i < player.inventoryTexts.Length; i++)
                            {
                                if (player.inventoryTexts[i].text == "Copper Coin")
                                {
                                    player.inventoryTexts[i].text = "";
                                    break;
                                }
                                else if (player.inventoryTexts[i].text == "Silver Coin")
                                {
                                    player.inventoryTexts[i].text = "";
                                    break;
                                }
                                else if (player.inventoryTexts[i].text == "Gold Coin")
                                {
                                    player.inventoryTexts[i].text = "";
                                    break;
                                }
                            }
                            UnlockDoor();
                        }
                        else
                        {
                            inDialouge = true;
                            unlockSound.Play();
                            dialougeText.text = "You place the three coins into the slots on the door. A small click can be heard.";
                            puzzlecompletedSound.Play();
                        }
                    }
                    else
                    {
                        if (inDialouge)
                        {
                            CloseDialouge();
                        }
                        else
                        {
                            inDialouge = true;
                            dialougeText.text = "You stand before a large, locked oak door. There seems to no keyhole on it. Three equally sized circles are engraved into the door. First hole is made of bronze, second in silver, third in gold. Maybe you have to fit something in them?";
                            doorlockedSound.Play();
                        }
                    }
                }
                else if (kingsDoor)
                {
                    if (gameManager.kingsKeyOne && gameManager.kingsKeyTwo)
                    {
                        if (inDialouge)
                        {
                            gameManager.kingsUnlocked = true;
                            UnlockDoor();
                        }
                        else
                        {
                            inDialouge = true;
                            unlockSound.Play();
                            dialougeText.text = "You unlock the door using both of the crown keys. With all your strength, you push the door open.";
                        }
                    }
                    else
                    {
                        if (inDialouge)
                        {
                            CloseDialouge();
                        }
                        else
                        {
                            inDialouge = true;
                            dialougeText.text = "You stand before a massive door, so huge it would require all your strength to even push it open. It is kept shut by two locks, one blue, the other red. You know it leads to the throne room.";
                            doorlockedSound.Play();
                        }
                    }
                }
            }
        }
    }

    //Code to check when the player enters the door trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    //Code to check when the player exits the door trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    //A function for unlocking the door
    void UnlockDoor()
    {
        player.enabled = true;
        Destroy(hanglock);
        dialougeBox.GetComponent<RawImage>().enabled = false;
        dialougeText.enabled = false;
        inDialouge = false;
        doorScript.enabled = true;
        doorScript.playerInDoor = true;
        this.enabled = false;
    }

    //A function to close the dialouge
    void CloseDialouge()
    {
        player.enabled = true;
        dialougeBox.GetComponent<RawImage>().enabled = false;
        dialougeText.enabled = false;
        inDialouge = false;
    }
}
