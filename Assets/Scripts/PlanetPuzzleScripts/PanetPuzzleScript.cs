using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PanetPuzzleScript : MonoBehaviour
{
    //A bool that checks if the stand has the correct planet enebaled
    public bool hasCorrectPlanet;
    //A bool to check if the player is in dialouge
    public bool inDialouge;
    //A bool to check if the player has solved the puzzle
    public bool puzzleOver = false;
    //A bool to check if the player is in range of the stand
    public bool playerInRange;

    //A refrence to the correct planet that this stand needs to solve the puzzle
    public GameObject correctPlanet;
    //A refrence to the planet that is currently on the stand
    public GameObject currentlyEnabledPlanet;
    //An array of all the planets
    public GameObject[] planets;
    //A refrence to the dialouge box
    public GameObject dialougeBox;

    //A refrence to the planet picker object
    public PlanetPickerScript planetPicker;

    //A refrence to the dialouge text
    public TMP_Text dialougeText;

    //A refrence to the player's movement script
    public Movement player;

    //A refrence to the game manager
    private GameManager gameManager;

    private void Start()
    {
        //Assigning some refrences
        dialougeBox = GameObject.Find("DialougeBox");
        dialougeText = GameObject.Find("DialougeText").GetComponent<TMP_Text>();
        planetPicker = GameObject.Find("PlanetPicker").GetComponent<PlanetPickerScript>();
        player = GameObject.Find("Player").GetComponent<Movement>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        //If the player has already solved the puzzle, the correct planet of this stand will be turned on
        if(gameManager.planetSolved)
        {
            currentlyEnabledPlanet.SetActive(false);
            currentlyEnabledPlanet = null;
            correctPlanet.SetActive(true);
            currentlyEnabledPlanet = correctPlanet;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Checking if the correct planet is on the stand
        if(currentlyEnabledPlanet == correctPlanet)
        {
            hasCorrectPlanet = true;
        }
        else
        {
            hasCorrectPlanet = false;
        }

        //If the player is in range of the stand and presses E
        if(playerInRange)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                //If they are not already in dialouge
                if(!inDialouge)
                {
                    //The player's movement will be turned off to prevent them from moving
                    player.enabled = false;
                    //The dialouge box will turn on
                    dialougeBox.GetComponent<RawImage>().enabled = true;
                    dialougeText.enabled = true;
                    inDialouge = true;

                    //If there is no planet on this stand, it will ask you that planet you want to place
                    if (currentlyEnabledPlanet == null)
                    {
                        dialougeText.text = "Which planet do you want to place here?";
                        //It will tell the planet picker that the button menu should be open
                        planetPicker.buttonMenuOpen = true;
                    }
                    //If there is a planet on this stand, the player try to pick up the planet
                    else
                    {
                        //If the player's inventory is full, it will not pick up the planet
                        if(player.inventorySpace >= 8)
                        {
                            dialougeText.text = "You do not have space in your inventory";
                        }
                        //If there is space in the player's inventory, they will pick up whatever planet is on the stand
                        else
                        {
                            //The player's inventory will increase by one
                            player.inventorySpace++;

                            //The dialouge will tell you which planet you picked up
                            dialougeText.text = "You picked up " + currentlyEnabledPlanet.name;

                            //If the planet on the stand is the sun, it will tell the planet picker that the player is holding the sun
                            //This code is repeated a lot, it's just to take into account all the other planets
                            if (currentlyEnabledPlanet.name == "Sun")
                            {
                                planetPicker.hasSun = true;
                                for (int i = 0; i < player.inventoryTexts.Length; i++)
                                {
                                    if (player.inventoryTexts[i].text == "")
                                    {
                                        player.inventoryTexts[i].text = "Sun";
                                        break;
                                    }
                                }
                            }
                            else if (currentlyEnabledPlanet.name == "Mercury")
                            {
                                planetPicker.hasMercury = true;
                                for (int i = 0; i < player.inventoryTexts.Length; i++)
                                {
                                    if (player.inventoryTexts[i].text == "")
                                    {
                                        player.inventoryTexts[i].text = "Mercury";
                                        break;
                                    }
                                }
                            }
                            else if (currentlyEnabledPlanet.name == "Venus")
                            {
                                planetPicker.hasVenus = true;
                                for (int i = 0; i < player.inventoryTexts.Length; i++)
                                {
                                    if (player.inventoryTexts[i].text == "")
                                    {
                                        player.inventoryTexts[i].text = "Venus";
                                        break;
                                    }
                                }
                            }
                            else if (currentlyEnabledPlanet.name == "Earth")
                            {
                                planetPicker.hasEarth = true;
                                for (int i = 0; i < player.inventoryTexts.Length; i++)
                                {
                                    if (player.inventoryTexts[i].text == "")
                                    {
                                        player.inventoryTexts[i].text = "Earth";
                                        break;
                                    }
                                }
                            }
                            else if (currentlyEnabledPlanet.name == "Mars")
                            {
                                planetPicker.hasMars = true;
                                for (int i = 0; i < player.inventoryTexts.Length; i++)
                                {
                                    if (player.inventoryTexts[i].text == "")
                                    {
                                        player.inventoryTexts[i].text = "Mars";
                                        break;
                                    }
                                }
                            }
                            else if (currentlyEnabledPlanet.name == "Jupiter")
                            {
                                planetPicker.hasJupiter = true;
                                for (int i = 0; i < player.inventoryTexts.Length; i++)
                                {
                                    if (player.inventoryTexts[i].text == "")
                                    {
                                        player.inventoryTexts[i].text = "Jupiter";
                                        break;
                                    }
                                }
                            }
                            else if (currentlyEnabledPlanet.name == "Saturn")
                            {
                                planetPicker.hasSaturn = true;
                                for (int i = 0; i < player.inventoryTexts.Length; i++)
                                {
                                    if (player.inventoryTexts[i].text == "")
                                    {
                                        player.inventoryTexts[i].text = "Saturn";
                                        break;
                                    }
                                }
                            }
                            else if (currentlyEnabledPlanet.name == "Uranus")
                            {
                                planetPicker.hasUranus = true;
                                for (int i = 0; i < player.inventoryTexts.Length; i++)
                                {
                                    if (player.inventoryTexts[i].text == "")
                                    {
                                        player.inventoryTexts[i].text = "Uranus";
                                        break;
                                    }
                                }
                            }
                            //This is for error checking
                            else
                            {
                                Debug.Log("Error: You are not supposed to see this. If you encounter this, alert the developer");
                                dialougeText.text = "Error: You are not supposed to see this. If you encounter this, alert the developer";
                            }
                            //This will turn off the planet that the player picked up
                            currentlyEnabledPlanet.SetActive(false);
                            currentlyEnabledPlanet = null;
                        }
                    }
                }
                //If the player is already in dialouge when the player presses E, they will go out of the dialouge and the dialouge text will turn off
                else
                {
                    player.enabled = true;
                    dialougeBox.GetComponent<RawImage>().enabled = false;
                    dialougeText.enabled = false;
                    inDialouge = false;
                    planetPicker.buttonMenuOpen = false;
                }
            }
        }
    }

    //If the player enters the stand's trigger, this stand will be registered as the current stand in range and the player will be able to interact with it
    private void OnTriggerEnter(Collider other)
    {
        if(!puzzleOver)
        {
            if (other.CompareTag("Player"))
            {
                playerInRange = true;

                //Turns on the outline
                GetComponent<Outline>().enabled = true;

                planetPicker.currentStand = this.gameObject;
            }
        }
    }

    //If the player exits the stand's trigger, this stand will be deselected and the player will not be able to interact with it
    private void OnTriggerExit(Collider other)
    {
        if(!puzzleOver)
        {
            if (other.CompareTag("Player"))
            {
                playerInRange = false;

                //Turns off the outline
                GetComponent<Outline>().enabled = false;

                planetPicker.currentStand = null;
            }
        }
    }
}
