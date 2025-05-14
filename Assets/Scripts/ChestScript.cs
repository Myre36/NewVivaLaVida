using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChestScript : MonoBehaviour
{
    // Open door sound effect
    public AudioSource ChestOpen;

    //A refrence to the game manager
    private GameManager gameManager;

    //A refrence to the player movement script
    private Movement player;

    //Bool to check if the player is in rnage of the door
    public bool playerInRange;

    //A bool to check if the player is already in dialouge
    private bool inDialouge;

    //A refrence to the dialouge box
    public GameObject dialougeBox;

    //A refrence to the dialouge text
    public TMP_Text dialougeText;

    //Bools to check what chest this is
    public bool chest1;
    public bool chest2;
    public bool chest3;
    public bool chest4;
    public bool chest5;
    public bool chest6;
    public bool chest7;
    public bool chest8;
    public bool chest9;
    public bool chest10;

    //For chest check
    public GameObject HorseChest;
    public GameObject SChest;
    public GameObject CrownChest;
    public GameObject SunChest;
    public GameObject RustyChest;

    public GameObject SChest2;
    public GameObject CrownChest_1;
    public GameObject CrownChest_2;


    public int ammoAmmount;

    public bool hasHealing;

    public GameObject closedLid;
    public GameObject openLid;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Assigning all the refrences
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("Player").GetComponent<Movement>();
        dialougeBox = GameObject.Find("DialougeBox");
        dialougeText = GameObject.Find("DialougeText").GetComponent<TMP_Text>();
        ChestOpen = GetComponent<AudioSource>();

        if (chest1)
        {
            if(gameManager.chest1)
            {
                closedLid.SetActive(false);
                openLid.SetActive(true);
                this.enabled = false;
            }
        }
        else if (chest2)
        {
            if (gameManager.chest2)
            {
                closedLid.SetActive(false);
                openLid.SetActive(true);
                this.enabled = false;
            }
        }
        else if (chest3)
        {
            if (gameManager.chest3)
            {
                closedLid.SetActive(false);
                openLid.SetActive(true);
                this.enabled = false;
            }
        }
        else if (chest4)
        {
            if (gameManager.chest4)
            {
                closedLid.SetActive(false);
                openLid.SetActive(true);
                this.enabled = false;
            }
        }
        else if (chest5)
        {
            if (gameManager.chest5)
            {
                closedLid.SetActive(false);
                openLid.SetActive(true);
                this.enabled = false;
            }
        }
        else if (chest6)
        {
            if (gameManager.chest6)
            {
                closedLid.SetActive(false);
                openLid.SetActive(true);
                this.enabled = false;
            }
        }
        else if (chest7)
        {
            if (gameManager.chest7)
            {
                closedLid.SetActive(false);
                openLid.SetActive(true);
                this.enabled = false;
            }
        }
        else if (chest8)
        {
            if (gameManager.chest8)
            {
                closedLid.SetActive(false);
                openLid.SetActive(true);
                this.enabled = false;
            }
        }
        else if (chest9)
        {
            if (gameManager.chest9)
            {
                closedLid.SetActive(false);
                openLid.SetActive(true);
                this.enabled = false;
            }
        }
        else if (chest10)
        {
            if (gameManager.chest10)
            {
                closedLid.SetActive(false);
                openLid.SetActive(true);
                this.enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInRange)
        {
            if(Input.GetKeyUp(KeyCode.E))
            {
                //Freezes the player and turns on the dialouge
                player.enabled = false;
                dialougeBox.GetComponent<RawImage>().enabled = true;
                dialougeText.enabled = true;

                if (hasHealing)
                {
                    dialougeText.text = "You got " + ammoAmmount + " bullets and a healing item.";
                }
                else
                {
                    dialougeText.text = "You got " + ammoAmmount + " bullets.";
                }

                if (chest1)
                {
                    if(gameManager.tunnelKey)
                    {
                        if(inDialouge)
                        {
                            gameManager.chest1 = true;
                            UnlockChest();
                            Destroy(HorseChest);
                        }
                        else
                        {
                            inDialouge = true;
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
                            dialougeText.text = "The lock on the chest is in the shape of a horse.";
                        }
                    }
                }
                else if(chest2)
                {
                    if (gameManager.kingsKeyOne)
                    {
                        if (inDialouge)
                        {
                            gameManager.chest2 = true;
                            UnlockChest();
                            Destroy(CrownChest);
                        }
                        else
                        {
                            inDialouge = true;
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
                            dialougeText.text = "The lock on the chest is shaped like a blue crown.";
                        }
                    }
                }
                else if (chest3)
                {
                    if (gameManager.secondFloorKey)
                    {
                        if (inDialouge)
                        {
                            gameManager.chest3 = true;
                            UnlockChest();
                        }
                        else
                        {
                            inDialouge = true;
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
                            dialougeText.text = "The lock on the chest is marked with the number 2.";
                        }
                    }
                }
                else if (chest4)
                {
                    if (gameManager.servantsKey)
                    {
                        if (inDialouge)
                        {
                            gameManager.chest4 = true;
                            UnlockChest();
                        }
                        else
                        {
                            inDialouge = true;
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
                            dialougeText.text = "The lock on the chest is marked with the letter S.";
                        }
                    }
                }
                else if (chest5)
                {
                    if (gameManager.planetariumKey)
                    {
                        if (inDialouge)
                        {
                            gameManager.chest5 = true;
                            UnlockChest();
                        }
                        else
                        {
                            inDialouge = true;
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
                            dialougeText.text = "The lock on the chest is shaped like a sun.";
                        }
                    }
                }
                else if (chest6)
                {
                    if (gameManager.basementKey)
                    {
                        if (inDialouge)
                        {
                            gameManager.chest6 = true;
                            UnlockChest();
                        }
                        else
                        {
                            inDialouge = true;
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
                            dialougeText.text = "The lock on the chest is rusty, like it hasn't been used in a long time.";
                        }
                    }
                }
                else if (chest7)
                {
                    if (gameManager.servantsKey)
                    {
                        if (inDialouge)
                        {
                            gameManager.chest7 = true;
                            UnlockChest();
                        }
                        else
                        {
                            inDialouge = true;
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
                            dialougeText.text = "The lock on the chest is marked with the letter S.";
                        }
                    }
                }
                else if (chest8)
                {
                    if (gameManager.kingsKeyTwo)
                    {
                        if (inDialouge)
                        {
                            gameManager.chest8 = true;
                            UnlockChest();
                        }
                        else
                        {
                            inDialouge = true;
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
                            dialougeText.text = "The lock on the chest is shaped like a blue crown.";
                        }
                    }
                }
                else if (chest9)
                {
                    if (gameManager.kingsKeyOne)
                    {
                        if (inDialouge)
                        {
                            gameManager.chest9 = true;
                            UnlockChest();
                            Destroy(CrownChest_2);
                        }
                        else
                        {
                            inDialouge = true;
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
                            dialougeText.text = "The lock on the chest is shaped like a blue crown.";
                        }
                    }
                }
                else if (chest10)
                {
                    if (gameManager.kingsKeyTwo)
                    {
                        if (inDialouge)
                        {
                            gameManager.chest10 = true;
                            UnlockChest();
                        }
                        else
                        {
                            inDialouge = true;
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
                            dialougeText.text = "The lock on the chest is shaped like a blue crown.";
                        }
                    }
                }
            }
        }
    }

    //Code to check when the player enters the door trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && this.enabled == true)
        {
            playerInRange = true;
            GetComponent<Outline>().enabled = true;
        }
    }

    //Code to check when the player exits the door trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && this.enabled == true)
        {
            playerInRange = false;
            GetComponent<Outline>().enabled = false;
        }
    }

    void UnlockChest()
    {
        player.enabled = true;
        dialougeBox.GetComponent<RawImage>().enabled = false;
        dialougeText.enabled = false;
        inDialouge = false;
        player.gameObject.GetComponentInChildren<GunScript>().ammoCount += ammoAmmount;
        if(hasHealing)
        {
            player.healingCharges++;
        }
        GetComponent<Outline>().enabled = false;
        closedLid.SetActive(false);
        openLid.SetActive(true);
        ChestOpen.Play();
        this.enabled = false;
    }

    void CloseDialouge()
    {
        player.enabled = true;
        dialougeBox.GetComponent<RawImage>().enabled = false;
        dialougeText.enabled = false;
        inDialouge = false;
    }
}
