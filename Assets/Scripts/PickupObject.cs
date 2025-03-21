using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PickupObject : MonoBehaviour
{
    private GameManager gameManager;
    public Movement player;

    public GameObject roomCheck;

    public GameObject dialougeBox;
    public TMP_Text dialougeText;
    public bool playerInRange = false;

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

    private bool inDialouge;

    public bool isKeyItem;

    public bool isBullet;
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

    public bool hasEnemies;

    public NavMeshAgent[] enemies;

    private AudioSource pickupSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        roomCheck = GameObject.Find("RoomEntryCheck");
        player = GameObject.Find("Player").GetComponent<Movement>();
        dialougeBox = GameObject.Find("DialougeBox");
        dialougeText = GameObject.Find("DialougeText").GetComponent<TMP_Text>();
        pickupSound = GetComponent<AudioSource>();
        if(isKeyItem)
        {
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
        else if(isBullet)
        {
            if (bullet1)
            {
                if (gameManager.bullet1)
                {
                    Destroy(gameObject);
                }
            }
            if (bullet2)
            {
                if (gameManager.bullet2)
                {
                    Destroy(gameObject);
                }
            }
            if (bullet3)
            {
                if (gameManager.bullet3)
                {
                    Destroy(gameObject);
                }
            }
            if (bullet4)
            {
                if (gameManager.bullet4)
                {
                    Destroy(gameObject);
                }
            }
            if (bullet5)
            {
                if (gameManager.bullet5)
                {
                    Destroy(gameObject);
                }
            }
            if (bullet6)
            {
                if (gameManager.bullet6)
                {
                    Destroy(gameObject);
                }
            }
            if (bullet7)
            {
                if (gameManager.bullet7)
                {
                    Destroy(gameObject);
                }
            }
            if (bullet8)
            {
                if (gameManager.bullet8)
                {
                    Destroy(gameObject);
                }
            }
            if (bullet9)
            {
                if (gameManager.bullet9)
                {
                    Destroy(gameObject);
                }
            }
            if (bullet10)
            {
                if (gameManager.bullet10)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton1))
            {
                player.enabled = false;
                dialougeBox.GetComponent<RawImage>().enabled = true;
                dialougeText.enabled = true;
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
                if(player.inventorySpace >= 8)
                {
                    if (inDialouge)
                    {
                        CloseDialouge();
                    }
                    else
                    {
                        inDialouge = true;
                        dialougeText.text = "You don't have enough space in your inventory.";
                    }
                }
                else
                {
                    if (isKeyItem)
                    {
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
                                pickupSound.Play();
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
                                pickupSound.Play();
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
                                pickupSound.Play();
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
                                pickupSound.Play();
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
                                pickupSound.Play();
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
                                pickupSound.Play();
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
                                pickupSound.Play();
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
                                pickupSound.Play();
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
                                pickupSound.Play();
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
                                pickupSound.Play();
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
                                pickupSound.Play();
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
                                pickupSound.Play();
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
                                pickupSound.Play();
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
                                pickupSound.Play();
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
                                pickupSound.Play();
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
                                pickupSound.Play();
                                dialougeText.text = "You pick up a blue book. It has a small metal thing sticking out of its pages. Maybe its a key for something?";
                            }
                        }
                    }
                    else if (isBullet)
                    {
                        if (inDialouge)
                        {
                            player.gameObject.GetComponentInChildren<GunScript>().ammoCount++;
                            if (bullet1)
                            {
                                gameManager.bullet1 = true;
                            }
                            if (bullet2)
                            {
                                gameManager.bullet2 = true;
                            }
                            if (bullet3)
                            {
                                gameManager.bullet3 = true;
                            }
                            if (bullet4)
                            {
                                gameManager.bullet4 = true;
                            }
                            if (bullet5)
                            {
                                gameManager.bullet5 = true;
                            }
                            if (bullet6)
                            {
                                gameManager.bullet6 = true;
                            }
                            if (bullet7)
                            {
                                gameManager.bullet7 = true;
                            }
                            if (bullet8)
                            {
                                gameManager.bullet8 = true;
                            }
                            if (bullet9)
                            {
                                gameManager.bullet9 = true;
                            }
                            if (bullet10)
                            {
                                gameManager.bullet10 = true;
                            }
                            CloseDialouge();
                        }
                        else
                        {
                            inDialouge = true;
                            pickupSound.Play();
                            dialougeText.text = "You pick up a bullet.";
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

    void CloseDialouge()
    {
        player.enabled = true;
        dialougeBox.GetComponent<RawImage>().enabled = false;
        dialougeText.text = "You are not supposed to see this";
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
        if (player.inventorySpace < 8)
        {
            if(isKeyItem)
            {
                player.inventorySpace++;
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
    }
}
