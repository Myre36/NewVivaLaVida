using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class UnlockItem : MonoBehaviour
{
    //Bools for what item is needed for this door
    public bool swordNeeded;
    public bool bookNeeded;
    public bool clothNeeded;
    //A check for if this room is the upper bathroom
    public bool upperBathroom;
    //A bool to check if the player is in range
    public bool playerInRange;
    //A bool for if the player in in dialouge
    private bool inDialouge;
    //A bool for if this room has enemies
    public bool hasEnemies;

    //A refrence to the gamemanager
    private GameManager gameManager;

    //A refrence to the player movement script
    public Movement player;

    //A refrence to the dialouge box
    public GameObject dialougeBox;
    //A refrence to the object that will be placed
    public GameObject placedObject;
    //A refrence to the key item that will unlock once the key item is placed
    public GameObject keyItem;

    //A refrence to the dialouge text
    public TMP_Text dialougeText;

    //An array of all the navmeshes of the enemies in this room
    public NavMeshAgent[] enemies;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Assigns all refrences
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("Player").GetComponent<Movement>();
        dialougeBox = GameObject.Find("DialougeBox");
        dialougeText = GameObject.Find("DialougeText").GetComponent<TMP_Text>();
        //Makes sure the placed item and key item exist depending on what the player has done
        if(swordNeeded)
        {
            if(gameManager.swordPlaced)
            {
                placedObject.SetActive(true);
                keyItem.SetActive(true);
                if (gameManager.planetariumKey)
                {
                    Destroy(keyItem);
                }
                this.enabled = false;
            }
        }
        else if(bookNeeded)
        {
            if(gameManager.bookPlaced)
            {
                gameManager.bookPlaced = true;
                GetComponent<DoorScript>().enabled = true;
                placedObject.SetActive(true);
                this.enabled = false;
            }
        }
        else if(clothNeeded)
        {
            if(gameManager.toiletClogged)
            {
                placedObject.SetActive(true);
                this.enabled = false;
            }
        }
        else if(upperBathroom)
        {
            if(gameManager.toiletClogged)
            {
                keyItem.SetActive(true);
                if(gameManager.servantsKey)
                {
                    Destroy(keyItem);
                }
                this.enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //If the player is in range of the item and presses the interact key
        if(playerInRange)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                //Turns off the player movement and turns on the dialoge
                player.enabled = false;
                dialougeBox.GetComponent<RawImage>().enabled = true;
                dialougeText.enabled = true;
                //If this room has enemies, the enemy movement will be paused
                if (hasEnemies)
                {
                    for (int i = 0; i < enemies.Length; i++)
                    {
                        if (enemies[i] != null)
                        {
                            NavMeshAgent currentEnemy = enemies[i];

                            currentEnemy.enabled = false;
                        }
                    }
                }
                //Depending on what is needed, and if you have the item in your inventory, the item will be placed
                if (swordNeeded)
                {
                    if(gameManager.sword)
                    {
                        if(inDialouge)
                        {
                            gameManager.swordPlaced = true;
                            for (int i = 0; i < player.inventoryTexts.Length; i++)
                            {
                                if (player.inventoryTexts[i].text == "Sword")
                                {
                                    player.inventoryTexts[i].text = "";
                                    break;
                                }
                            }
                            keyItem.SetActive(true);

                            PlaceItem();
                        }
                        else
                        {
                            inDialouge = true;
                            dialougeText.text = "You place the sword in cross with the other. A small click can be heard and something rises up from the table.";
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
                            dialougeText.text = "On the wall is a shield and a sword. It looks odd, like it's missing another sword.";
                        }
                    }
                }
                else if(clothNeeded)
                {
                    if (gameManager.clothPile)
                    {
                        if (inDialouge)
                        {
                            gameManager.toiletClogged = true;
                            for (int i = 0; i < player.inventoryTexts.Length; i++)
                            {
                                if (player.inventoryTexts[i].text == "Cloth Pile")
                                {
                                    player.inventoryTexts[i].text = "";
                                    break;
                                }
                            }
                            PlaceItem();
                        }
                        else
                        {
                            inDialouge = true;
                            dialougeText.text = "You place the pile of cloth into the toilet and flush. You hear the pipes rattle, and something bursts upstairs above you.";
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
                            dialougeText.text = "A small toilet. It looks old and ill taken care of. Maybe you could throw something in there?";
                        }
                    }
                }
                else if(bookNeeded)
                {
                    if (gameManager.book)
                    {
                        if (inDialouge)
                        {
                            gameManager.bookPlaced = true;
                            for (int i = 0; i < player.inventoryTexts.Length; i++)
                            {
                                if (player.inventoryTexts[i].text == "Weird Book")
                                {
                                    player.inventoryTexts[i].text = "";
                                    break;
                                }
                            }
                            GetComponent<DoorScript>().enabled = true;
                            PlaceItem();
                        }
                        else
                        {
                            inDialouge = true;
                            dialougeText.text = "You place the book into the correct spot and push it in. A small click can be heard, and the bookshelf pushes open.";
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
                            dialougeText.text = "It's a small bookcase with a variety of books. One book is missing though, and in the wall behind is a small slot, looks like a keyhole. Maybe you can find the book somewhere?";
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
            GetComponent<Outline>().enabled = true;
            playerInRange = true;
        }
    }

    //Code to check when the player exits the door trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<Outline>().enabled = false;
            playerInRange = false;
        }
    }

    //A function for placing down the item
    private void PlaceItem()
    {
        player.enabled = true;
        dialougeBox.GetComponent<RawImage>().enabled = false;
        dialougeText.enabled = false;
        inDialouge = false;
        if (hasEnemies)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i] != null)
                {
                    NavMeshAgent currentEnemy = enemies[i];

                    currentEnemy.enabled = true;
                }
            }
        }
        placedObject.SetActive(true);
        GetComponent<Outline>().enabled = false;
        this.enabled = false;
    }

    //A function for closing the dialouge
    private void CloseDialouge()
    {
        player.enabled = true;
        dialougeBox.GetComponent<RawImage>().enabled = false;
        dialougeText.enabled = false;
        if (hasEnemies)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i] != null)
                {
                    NavMeshAgent currentEnemy = enemies[i];

                    currentEnemy.enabled = true;
                }
            }
        }
        inDialouge = false;
    }
}
