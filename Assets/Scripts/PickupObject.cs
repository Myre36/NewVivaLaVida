using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PickupObject : MonoBehaviour
{
    //A refrence to the game manager
    private GameManager gameManager;

    //A refrence to the player movement
    public Movement player;

    //Refrence to the dialouge box
    public GameObject dialougeBox;

    //Refrence to the dialouge text
    public TMP_Text dialougeText;

    //A bool that checks if the player is in range
    public bool playerInRange;
    //A bool to check what item this is
    public bool coinOne;
    public bool coinTwo;
    public bool coinThree;
    public bool sword;
    public bool clothPile;
    public bool book;
    public bool toiletClogged;
    public bool firstKey;
    public bool hallwayKey;
    public bool planetariumKey;
    public bool meetingKey;
    public bool secondFloorKey;
    public bool servantsKey;
    public bool tunnelKey;
    public bool basementKey;
    public bool kingsKeyOne;
    public bool kingsKeyTwo;
    //A bool for if the player is in dialouge
    private bool inDialouge;
    //A bool for if this is a key item
    public bool isKeyItem;
    //A bool for of this is a bullet
    public bool isBullet;
    //A bool for if this is a healing item
    public bool isPlant;
    //Bools for what bullet this is
    public bool bullet1;
    public bool bullet2;
    public bool bullet3;
    public bool bullet4;
    public bool bullet5;
    public bool bullet6;
    public bool bullet7;
    public bool bullet8;
    public bool bullet9;
    public bool bullet10;
    public bool bullet11;
    public bool bullet12;
    public bool bullet13;

    //A bool for if this room has enemies
    public bool hasEnemies;

    //Bools for plants
    public bool plantOne;
    public bool plantTwo;
    public bool plantThree;
    public bool plantFour;
    public bool plantFive;
    public bool plantSix;
    public bool plantSeven;

    //An array of all the enemy navmeshes
    public NavMeshAgent[] enemies;

    //The audiosource for the sound that plays when you pick this item up
    private AudioSource pickupitemSound;
    private AudioSource getkeysSound;

    private bool stopDialougeBug;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Assigning all refrences
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("Player").GetComponent<Movement>();
        dialougeBox = GameObject.Find("DialougeBox");
        dialougeText = GameObject.Find("DialougeText").GetComponent<TMP_Text>();
        pickupitemSound = GetComponent<AudioSource>();
        getkeysSound = GetComponent<AudioSource>();

        //Checks if this is a key item
        if (isKeyItem)
        {
            //Used to make sure the this item is destroyed if the player has already picked it up before
            if (hallwayKey)
            {
                if (gameManager.hallwayKey)
                {
                    Destroy(gameObject);
                }
            }
            else if (firstKey)
            {
                if (gameManager.firstKey)
                {
                    Destroy(gameObject);
                }
            }
            else if (tunnelKey)
            {
                if (gameManager.tunnelKey)
                {
                    Destroy(gameObject);
                }
            }
            else if (servantsKey)
            {
                if (gameManager.servantsKey)
                {
                    Destroy(gameObject);
                }
            }
            else if (basementKey)
            {
                if (gameManager.basementKey)
                {
                    Destroy(gameObject);
                }
            }
            else if (secondFloorKey)
            {
                if (gameManager.secondFloorKey)
                {
                    Destroy(gameObject);
                }
            }
            else if (planetariumKey)
            {
                if (gameManager.planetariumKey)
                {
                    Destroy(gameObject);
                }
            }
            else if (meetingKey)
            {
                if (gameManager.meetingKey)
                {
                    Destroy(gameObject);
                }
            }
            else if (coinOne)
            {
                if (gameManager.coinOne)
                {
                    Destroy(gameObject);
                }
            }
            else if (coinTwo)
            {
                if (gameManager.coinTwo)
                {
                    Destroy(gameObject);
                }
            }
            else if (coinThree)
            {
                if (gameManager.coinThree)
                {
                    Destroy(gameObject);
                }
            }
            else if (kingsKeyOne)
            {
                if (gameManager.kingsKeyOne)
                {
                    Destroy(gameObject);
                }
            }
            else if (kingsKeyTwo)
            {
                if (gameManager.kingsKeyTwo)
                {
                    Destroy(gameObject);
                }
            }
            else if (clothPile)
            {
                if (gameManager.clothPile)
                {
                    Destroy(gameObject);
                }
            }
            else if (sword)
            {
                if (gameManager.sword)
                {
                    Destroy(gameObject);
                }
            }
            else if (book)
            {
                if (gameManager.book)
                {
                    Destroy(gameObject);
                }
            }
        }
        //If this item is a bullet
        else if(isBullet)
        {
            //Makes sure the item is destroyed if the player has picked it up before
            if (bullet1)
            {
                if (gameManager.bullet1)
                {
                    Destroy(gameObject);
                }
            }
            else if (bullet2)
            {
                if (gameManager.bullet2)
                {
                    Destroy(gameObject);
                }
            }
            else if (bullet3)
            {
                if (gameManager.bullet3)
                {
                    Destroy(gameObject);
                }
            }
            else if (bullet4)
            {
                if (gameManager.bullet4)
                {
                    Destroy(gameObject);
                }
            }
            else if (bullet5)
            {
                if (gameManager.bullet5)
                {
                    Destroy(gameObject);
                }
            }
            else if (bullet6)
            {
                if (gameManager.bullet6)
                {
                    Destroy(gameObject);
                }
            }
            else if (bullet7)
            {
                if (gameManager.bullet7)
                {
                    Destroy(gameObject);
                }
            }
            else if (bullet8)
            {
                if (gameManager.bullet8)
                {
                    Destroy(gameObject);
                }
            }
            else if (bullet9)
            {
                if (gameManager.bullet9)
                {
                    Destroy(gameObject);
                }
            }
            else if (bullet10)
            {
                if (gameManager.bullet10)
                {
                    Destroy(gameObject);
                }
            }
            else if (bullet11)
            {
                if (gameManager.bullet11)
                {
                    Destroy(gameObject);
                }
            }
            else if (bullet12)
            {
                if (gameManager.bullet12)
                {
                    Destroy(gameObject);
                }
            }
            else if (bullet13)
            {
                if (gameManager.bullet13)
                {
                    Destroy(gameObject);
                }
            }
        }
        else if(isPlant)
        {
            if (plantOne)
            {
                if (gameManager.plantOne)
                {
                    Destroy(gameObject);
                }
            }
            else if (plantTwo)
            {
                if (gameManager.plantTwo)
                {
                    Destroy(gameObject);
                }
            }
            else if (plantThree)
            {
                if (gameManager.plantThree)
                {
                    Destroy(gameObject);
                }
            }
            else if (plantFour)
            {
                if (gameManager.plantFour)
                {
                    Destroy(gameObject);
                }
            }
            else if (plantFive)
            {
                if (gameManager.plantFive)
                {
                    Destroy(gameObject);
                }
            }
            else if (plantSix)
            {
                if (gameManager.plantSix)
                {
                    Destroy(gameObject);
                }
            }
            else if (plantSeven)
            {
                if (gameManager.plantSeven)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //If the player is in range and presses E
        if (playerInRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(isBullet)
                {
                    if(!gameManager.firstBullet)
                    {
                        //Turns off the player
                        player.enabled = false;
                        gameManager.firstBullet = true;
                    }
                    else
                    {
                        if(!inDialouge)
                        {
                            dialougeBox = GameObject.Find("SmallDialougeBox");
                            dialougeText = GameObject.Find("SmallDialougeText").GetComponent<TMP_Text>();
                            StartCoroutine(SmallDialouge());
                        }
                    }
                }
                else if(isPlant)
                {
                    if (!gameManager.firstPlant)
                    {
                        //Turns off the player
                        player.enabled = false;
                        gameManager.firstPlant = true;
                    }
                    else
                    {
                        if(!inDialouge)
                        {
                            dialougeBox = GameObject.Find("SmallDialougeBox");
                            dialougeText = GameObject.Find("SmallDialougeText").GetComponent<TMP_Text>();
                            StartCoroutine(SmallDialouge());
                        }
                    }
                }
                else
                {
                    //Turns off the player
                    player.enabled = false;
                }
                
                dialougeBox.GetComponent<RawImage>().enabled = true;
                dialougeText.enabled = true;
                //If this room has enemies, their movement will all be paused while the player is in dialouge
                if(hasEnemies)
                {
                    for(int i = 0; i < enemies.Length; i++)
                    {
                        if (enemies[i] != null)
                        {
                            NavMeshAgent currentEnemy = enemies[i];

                            currentEnemy.enabled = false;
                        }
                    }
                }
                //Checks if this is a key item
                if (isKeyItem)
                {
                    //Checks what item this is and picks it up
                    if (hallwayKey)
                    {
                        if (inDialouge)
                        {
                            gameManager.hallwayKey = true;
                            CloseDialouge();
                        }
                        else
                        {
                            inDialouge = true;
                            getkeysSound.Play();
                            dialougeText.text = "You pick up a key with an orange citrine gemstone as its head.";
                        }
                    }
                    else if (firstKey)
                    {
                        if (inDialouge)
                        {
                            gameManager.firstKey = true;
                            CloseDialouge();
                        }
                        else
                        {
                            inDialouge = true;
                            getkeysSound.Play();
                            dialougeText.text = "You pick up a key with an emerald gemstone as its head.";
                        }
                    }
                    else if (tunnelKey)
                    {
                        if (inDialouge)
                        {
                            gameManager.tunnelKey = true;
                            CloseDialouge();
                        }
                        else
                        {
                            inDialouge = true;
                            getkeysSound.Play();
                            dialougeText.text = "You pick up a key with a horse emblem as its head.";
                        }
                    }
                    else if (servantsKey)
                    {
                        if (inDialouge)
                        {
                            gameManager.servantsKey = true;
                            CloseDialouge();
                        }
                        else
                        {
                            inDialouge = true;
                            getkeysSound.Play();
                            dialougeText.text = "You pick up a key with a large S-shaped emblem as its head.";
                        }
                    }
                    else if (basementKey)
                    {
                        if (inDialouge)
                        {
                            gameManager.basementKey = true;
                            CloseDialouge();
                        }
                        else
                        {
                            inDialouge = true;
                            getkeysSound.Play();
                            dialougeText.text = "You pick up an old and rusty key. Whatever this unlocks, it must be a very old lock.";
                        }
                    }
                    else if (secondFloorKey)
                    {
                        if (inDialouge)
                        {
                            gameManager.secondFloorKey = true;
                            CloseDialouge();
                        }
                        else
                        {
                            inDialouge = true;
                            getkeysSound.Play();
                            dialougeText.text = "You pick up a small key. The head is engraved with a 2.";
                        }
                    }
                    else if (planetariumKey)
                    {
                        if (inDialouge)
                        {
                            gameManager.planetariumKey = true;
                            CloseDialouge();
                        }
                        else
                        {
                            inDialouge = true;
                            getkeysSound.Play();
                            dialougeText.text = "You pick up a shiny golden key. The head of it is shaped like the sun.";
                        }
                    }
                    else if (meetingKey)
                    {
                        if (inDialouge)
                        {
                            gameManager.meetingKey = true;
                            CloseDialouge();
                        }
                        else
                        {
                            inDialouge = true;
                            getkeysSound.Play();
                            dialougeText.text = "You pick up small key. Its head is decorated with small blue saphires.";
                        }
                    }
                    else if (coinOne)
                    {
                        if (inDialouge)
                        {
                            gameManager.coinOne = true;
                            CloseDialouge();
                        }
                        else
                        {
                            inDialouge = true;
                            pickupitemSound.Play();
                            dialougeText.text = "You pick up a large copper coin. Wonder if it can be used somewhere.";
                        }
                    }
                    else if (coinTwo)
                    {
                        if (inDialouge)
                        {
                            gameManager.coinTwo = true;
                            CloseDialouge();
                        }
                        else
                        {
                            inDialouge = true;
                            pickupitemSound.Play();
                            dialougeText.text = "You pick up a large silver coin. Maybe it will be of some use?";
                        }
                    }
                    else if (coinThree)
                    {
                        if (inDialouge)
                        {
                            gameManager.coinThree = true;
                            CloseDialouge();
                        }
                        else
                        {
                            inDialouge = true;
                            pickupitemSound.Play();
                            dialougeText.text = "You pick up a large gold coin. If it's of no use, you can pocket it for yourself.";
                        }
                    }
                    else if (kingsKeyOne)
                    {
                        if (inDialouge)
                        {
                            gameManager.kingsKeyOne = true;
                            CloseDialouge();
                        }
                        else
                        {
                            inDialouge = true;
                            getkeysSound.Play();
                            dialougeText.text = "You pick up a large blue key. It's head is a replica of the crown of Norway.";
                        }
                    }
                    else if (kingsKeyTwo)
                    {
                        if (inDialouge)
                        {
                            gameManager.kingsKeyTwo = true;
                            CloseDialouge();
                        }
                        else
                        {
                            inDialouge = true;
                            getkeysSound.Play();
                            dialougeText.text = "You pick up a large red key. It's head is a replica of the crown of Denmark.";
                        }
                    }
                    else if (clothPile)
                    {
                        if (inDialouge)
                        {
                            gameManager.clothPile = true;
                            CloseDialouge();
                        }
                        else
                        {
                            inDialouge = true;
                            pickupitemSound.Play();
                            dialougeText.text = "You pick up a pile of cloth. Maybe you can use it somewhere?";
                        }
                    }
                    else if (sword)
                    {
                        if (inDialouge)
                        {
                            gameManager.sword = true;
                            CloseDialouge();
                        }
                        else
                        {
                            inDialouge = true;
                            pickupitemSound.Play();
                            dialougeText.text = "You pick up a large sword. Weird place to keep one.";
                        }
                    }
                    else if (book)
                    {
                        if (inDialouge)
                        {
                            gameManager.book = true;
                            CloseDialouge();
                        }
                        else
                        {
                            inDialouge = true;
                            pickupitemSound.Play();
                            dialougeText.text = "You pick up a blue book. It has a small metal thing sticking out of its pages. Maybe its a key for something?";
                        }
                    }
                }
                //If this is a bullet, it will be picked up
                else if (isBullet)
                {
                    if (inDialouge)
                    {
                        player.gameObject.GetComponentInChildren<GunScript>().ammoCount++;
                        if (bullet1)
                        {
                            gameManager.bullet1 = true;
                        }
                        else if (bullet2)
                        {
                            gameManager.bullet2 = true;
                        }
                        else if (bullet3)
                        {
                            gameManager.bullet3 = true;
                        }
                        else if (bullet4)
                        {
                            gameManager.bullet4 = true;
                        }
                        else if (bullet5)
                        {
                            gameManager.bullet5 = true;
                        }
                        else if (bullet6)
                        {
                            gameManager.bullet6 = true;
                        }
                        else if (bullet7)
                        {
                            gameManager.bullet7 = true;
                        }
                        else if (bullet8)
                        {
                            gameManager.bullet8 = true;
                        }
                        else if (bullet9)
                        {
                            gameManager.bullet9 = true;
                        }
                        else if (bullet10)
                        {
                            gameManager.bullet10 = true;
                        }
                        else if (bullet11)
                        {
                            gameManager.bullet11 = true;
                        }
                        else if (bullet12)
                        {
                            gameManager.bullet12 = true;
                        }
                        else if (bullet13)
                        {
                            gameManager.bullet13 = true;
                        }
                        CloseDialouge();
                    }
                    else
                    {
                        inDialouge = true;
                        pickupitemSound.Play();
                        dialougeText.text = "You pick up a bullet.";
                    }
                }
                else if(isPlant)
                {
                    if(inDialouge)
                    {
                        player.healingCharges++;
                        if(plantOne)
                        {
                            gameManager.plantOne = true;
                        }
                        else if(plantTwo)
                        {
                            gameManager.plantTwo = true;
                        }
                        else if(plantThree)
                        {
                            gameManager.plantThree = true;
                        }
                        else if(plantFour)
                        {
                            gameManager.plantFour = true;
                        }
                        else if(plantFive)
                        {
                            gameManager.plantFive = true;
                        }
                        else if(plantSix)
                        {
                            gameManager.plantSix = true;
                        }
                        else if(plantSeven)
                        {
                            gameManager.plantSeven = true;
                        }
                        CloseDialouge();
                    }
                    else
                    {
                        inDialouge = true;
                        pickupitemSound.Play();
                        dialougeText.text = "You pick up a healing plant.";
                    }
                }
            }
        }
    }

    //Code to check when the player enters the door trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !stopDialougeBug)
        {
            GetComponent<Outline>().enabled = true;
            playerInRange = true;
        }
    }

    //Code to check when the player exits the door trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !stopDialougeBug)
        {
            GetComponent<Outline>().enabled = false;
            playerInRange = false;
        }
    }

    //A function for closing the dialouge
    void CloseDialouge()
    {
        //Turns the player on
        player.enabled = true;
        //Closes the dialouge
        dialougeBox.GetComponent<RawImage>().enabled = false;
        dialougeText.text = "You are not supposed to see this";
        dialougeText.enabled = false;
        inDialouge = false;
        //If this room has enemies, their movement will be turned back on
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
        if (isKeyItem)
        {
            for (int i = 0; i < player.inventoryTexts.Length; i++)
            {
                if (player.inventoryTexts[i].text == "")
                {
                    player.inventoryTexts[i].text = gameObject.name;
                    break;
                }
            }
        }
        Destroy(gameObject);
    }

    IEnumerator SmallDialouge()
    {
        stopDialougeBug = true;
        playerInRange = false;
        GetComponent<Renderer>().enabled = false;
        GetComponent<Outline>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);
        if(isPlant)
        {
            player.healingCharges++;
            if (plantOne)
            {
                gameManager.plantOne = true;
            }
            else if (plantTwo)
            {
                gameManager.plantTwo = true;
            }
            else if (plantThree)
            {
                gameManager.plantThree = true;
            }
            else if (plantFour)
            {
                gameManager.plantFour = true;
            }
            else if (plantFive)
            {
                gameManager.plantFive = true;
            }
            else if (plantSix)
            {
                gameManager.plantSix = true;
            }
            else if (plantSeven)
            {
                gameManager.plantSeven = true;
            }
        }
        else
        {
            player.gameObject.GetComponentInChildren<GunScript>().ammoCount++;
            if (bullet1)
            {
                gameManager.bullet1 = true;
            }
            else if (bullet2)
            {
                gameManager.bullet2 = true;
            }
            else if (bullet3)
            {
                gameManager.bullet3 = true;
            }
            else if (bullet4)
            {
                gameManager.bullet4 = true;
            }
            else if (bullet5)
            {
                gameManager.bullet5 = true;
            }
            else if (bullet6)
            {
                gameManager.bullet6 = true;
            }
            else if (bullet7)
            {
                gameManager.bullet7 = true;
            }
            else if (bullet8)
            {
                gameManager.bullet8 = true;
            }
            else if (bullet9)
            {
                gameManager.bullet9 = true;
            }
            else if (bullet10)
            {
                gameManager.bullet10 = true;
            }
            else if (bullet11)
            {
                gameManager.bullet11 = true;
            }
            else if (bullet12)
            {
                gameManager.bullet12 = true;
            }
            else if (bullet13)
            {
                gameManager.bullet13 = true;
            }
        }
        yield return new WaitForSeconds(3);
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
        dialougeBox.GetComponent<RawImage>().enabled = false;
        dialougeText.text = "You are not supposed to see this";
        dialougeText.enabled = false;
        inDialouge = false;
        Destroy(gameObject);
    }
}
