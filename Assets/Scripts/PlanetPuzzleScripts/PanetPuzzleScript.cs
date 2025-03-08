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

    public TMP_Text dialougeText;

    public Movement player;

    private GameManager gameManager;

    private void Start()
    {
        dialougeBox = GameObject.Find("DialougeBox");
        dialougeText = GameObject.Find("DialougeText").GetComponent<TMP_Text>();
        planetPicker = GameObject.Find("PlanetPicker").GetComponent<PlanetPickerScript>();
        player = GameObject.Find("Player").GetComponent<Movement>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

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
        if(currentlyEnabledPlanet == correctPlanet)
        {
            hasCorrectPlanet = true;
        }
        else
        {
            hasCorrectPlanet = false;
        }

        if(playerInRange)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(!inDialouge)
                {
                    player.enabled = false;
                    if (currentlyEnabledPlanet == null)
                    {
                        dialougeText.text = "Which planet do you want to place here?";
                        planetPicker.buttonMenuOpen = true;
                    }
                    else
                    {
                        if(player.inventorySpace >= 8)
                        {
                            dialougeText.text = "You do not have space in your inventory";
                        }
                        else
                        {
                            player.inventorySpace++;
                            dialougeText.text = "You picked up " + currentlyEnabledPlanet.name;
                            if (currentlyEnabledPlanet.name == "Sun")
                            {
                                planetPicker.hasSun = true;
                            }
                            else if (currentlyEnabledPlanet.name == "Mercury")
                            {
                                planetPicker.hasMercury = true;
                            }
                            else if (currentlyEnabledPlanet.name == "Venus")
                            {
                                planetPicker.hasVenus = true;
                            }
                            else if (currentlyEnabledPlanet.name == "Earth")
                            {
                                planetPicker.hasEarth = true;
                            }
                            else if (currentlyEnabledPlanet.name == "Mars")
                            {
                                planetPicker.hasMars = true;
                            }
                            else if (currentlyEnabledPlanet.name == "Jupiter")
                            {
                                planetPicker.hasJupiter = true;
                            }
                            else if (currentlyEnabledPlanet.name == "Saturn")
                            {
                                planetPicker.hasSaturn = true;
                            }
                            else if (currentlyEnabledPlanet.name == "Uranus")
                            {
                                planetPicker.hasUranus = true;
                            }
                            else
                            {
                                Debug.Log("Error: You are not supposed to see this. If you encounter this, alert the developer");
                                dialougeText.text = "Error: You are not supposed to see this. If you encounter this, alert the developer";
                            }
                            currentlyEnabledPlanet.SetActive(false);
                            currentlyEnabledPlanet = null;
                        }

                        dialougeBox.GetComponent<RawImage>().enabled = true;
                        dialougeText.enabled = true;
                        inDialouge = true;
                    }
                }
                else
                {
                    player.enabled = true;
                    dialougeBox.GetComponent<RawImage>().enabled = false;
                    dialougeText.enabled = false;
                    inDialouge = false;
                    planetPicker.buttonMenuOpen = false;
                }
            }
            if(GetComponent<Outline>() == enabled)
            {
                GetComponent<Outline>().enabled = true;
            }
        }
        else
        {
            if(GetComponent<Outline>() == enabled)
            {
                GetComponent<Outline>().enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!puzzleOver)
        {
            if (other.CompareTag("Player"))
            {
                playerInRange = true;
                planetPicker.currentStand = this.gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(!puzzleOver)
        {
            if (other.CompareTag("Player"))
            {
                playerInRange = false;
                planetPicker.currentStand = null;
            }
        }
    }
}
