using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OneWayDoor : MonoBehaviour
{
    //A bool for checking the correct way
    public bool correctWay;
    //A bool for if the player is in range of the door
    public bool playerInRange;
    //Bools for what door this is
    public bool kitchenDoor;
    public bool statueDoor;
    public bool diningDoor;
    //A bool for if the player is in dialouge
    private bool inDialouge;

    //A refrence to the door script
    private DoorScript doorScript;

    //A refrence to the game manager
    private GameManager gameManager;

    //A refrence to the player movement
    public Movement player;

    //A refrence to the dialouge box
    public GameObject dialougeBox;

    //A refrence to the dialouge text
    public TMP_Text dialougeText;

    public AudioSource unlockSound;
    public AudioSource doorlockedSound;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Assigning all refrences
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("Player").GetComponent<Movement>();
        doorScript = this.GetComponent<DoorScript>();
        dialougeBox = GameObject.Find("DialougeBox");
        dialougeText = GameObject.Find("DialougeText").GetComponent<TMP_Text>();

        //Checking if this door has been unlocked before. If it has, it will unlock
        if(kitchenDoor)
        {
            if(gameManager.kitchenUnlocked)
            {
                doorScript.enabled = true;
                this.enabled = false;
            }
        }
        else if (statueDoor)
        {
            if (gameManager.statueRoomUnlocked)
            {
                doorScript.enabled = true;
                this.enabled = false;
            }
        }
        else if (diningDoor)
        {
            if (gameManager.diningUnlocked)
            {
                doorScript.enabled = true;
                this.enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //If the player is in range and presses E
        if(playerInRange)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                //Disables player movement and turns on dialouge
                player.enabled = false;
                dialougeBox.GetComponent<RawImage>().enabled = true;
                dialougeText.enabled = true;
                //Checks what door this is and depending which side you are on, the door will unlock or not
                if(kitchenDoor)
                {
                    if(correctWay)
                    {
                        if (inDialouge)
                        {
                            gameManager.kitchenUnlocked = true;
                            UnlockDoor();
                        }
                        else
                        {
                            inDialouge = true;
                            unlockSound.Play();
                            dialougeText.text = "You unlocked the door. You should be able to come through on the other side now.";
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
                            dialougeText.text = "The door is locked from the other side.";
                            doorlockedSound.Play();
                        }
                    }
                }
                else if (statueDoor)
                {
                    if (correctWay)
                    {
                        if (inDialouge)
                        {
                            gameManager.statueRoomUnlocked = true;
                            UnlockDoor();
                        }
                        else
                        {
                            inDialouge = true;
                            unlockSound.Play();
                            dialougeText.text = "You unlocked the door. You should be able to come through on the other side now.";
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
                            dialougeText.text = "The door is locked from the other side.";
                            doorlockedSound.Play();
                        }
                    }
                }
                else if (diningDoor)
                {
                    if (correctWay)
                    {
                        if (inDialouge)
                        {
                            gameManager.diningUnlocked = true;
                            UnlockDoor();
                        }
                        else
                        {
                            inDialouge = true;
                            unlockSound.Play();
                            dialougeText.text = "You unlocked the door. You should be able to come through on the other side now.";
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
                            dialougeText.text = "The door is locked from the other side.";
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
        dialougeBox.GetComponent<RawImage>().enabled = false;
        dialougeText.enabled = false;
        inDialouge = false;
        doorScript.enabled = true;
        doorScript.playerInDoor = true;
        this.enabled = false;
    }

    //A function for closing the dialouge
    void CloseDialouge()
    {
        player.enabled = true;
        dialougeBox.GetComponent<RawImage>().enabled = false;
        dialougeText.enabled = false;
        inDialouge = false;
    }
}
