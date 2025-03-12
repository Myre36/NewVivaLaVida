using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlanetPickerScript : MonoBehaviour
{
    //This is to make sure there is only one planet picker
    private static PlanetPickerScript instance;

    //Bools for if the player is holding all the planets
    public bool hasSun;
    public bool hasMercury;
    public bool hasVenus;
    public bool hasEarth;
    public bool hasMars;
    public bool hasJupiter;
    public bool hasSaturn;
    public bool hasUranus;
    //A bool that tells the scrip if the button menu is open or not
    public bool buttonMenuOpen;

    //Refrences to the buttons
    private Image noneButton;
    private TMP_Text noneText;
    private Image sunButton;
    private TMP_Text sunText;
    private Image mercuryButton;
    private TMP_Text mercuryText;
    private Image venusButton;
    private TMP_Text venusText;
    private Image earthButton;
    private TMP_Text earthText;
    private Image marsButton;
    private TMP_Text marsText;
    private Image jupiterButton;
    private TMP_Text jupiterText;
    private Image saturnButton;
    private TMP_Text saturnText;
    private Image uranusButton;
    private TMP_Text uranusText;

    //A refrence to the current stand that the player is interacting with
    public GameObject currentStand;
    //Refrence to the dialouge box
    private GameObject dialougeBox;

    //Refrence to the dialouge text
    private TMP_Text dialougeText;

    //Refrence to the player's movement script
    public Movement player;

    private void Start()
    {
        // This code is used to make sure there are never more than one of this
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        //Makes sure that this object does not destroy when a new scene is loaded
        DontDestroyOnLoad(this.gameObject);

        //Assigning all the buttons
        noneButton = GameObject.Find("NoneButton").GetComponent<Image>();
        noneText = GameObject.Find("NoneButton").GetComponentInChildren<TMP_Text>();

        sunButton = GameObject.Find("SunButton").GetComponent<Image>();
        sunText = GameObject.Find("SunButton").GetComponentInChildren<TMP_Text>();

        mercuryButton = GameObject.Find("MercuryButton").GetComponent<Image>();
        mercuryText = GameObject.Find("MercuryButton").GetComponentInChildren<TMP_Text>();

        venusButton = GameObject.Find("VenusButton").GetComponent<Image>();
        venusText = GameObject.Find("VenusButton").GetComponentInChildren<TMP_Text>();

        earthButton = GameObject.Find("EarthButton").GetComponent<Image>();
        earthText = GameObject.Find("EarthButton").GetComponentInChildren<TMP_Text>();

        marsButton = GameObject.Find("MarsButton").GetComponent<Image>();
        marsText = GameObject.Find("MarsButton").GetComponentInChildren<TMP_Text>();

        jupiterButton = GameObject.Find("JupiterButton").GetComponent<Image>();
        jupiterText = GameObject.Find("JupiterButton").GetComponentInChildren<TMP_Text>();

        saturnButton = GameObject.Find("SaturnButton").GetComponent<Image>();
        saturnText = GameObject.Find("SaturnButton").GetComponentInChildren<TMP_Text>();

        uranusButton = GameObject.Find("UranusButton").GetComponent<Image>();
        uranusText = GameObject.Find("UranusButton").GetComponentInChildren<TMP_Text>();

        dialougeBox = GameObject.Find("DialougeBox");
        dialougeText = GameObject.Find("DialougeText").GetComponent<TMP_Text>();

        //Assigning the player
        player = GameObject.Find("Player").GetComponent<Movement>();
    }

    private void Update()
    {
        //Code for checking what scene the player is in. This is to make sure this doesn't go into forbidden scenes
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "TutorialScene")
        {
            Destroy(this.gameObject);
        }
        if (currentScene.name == "Death scene")
        {
            Destroy(this.gameObject);
        }

        //If the button menu is open, certain buttons will appear depending on what planets the player is currently holding
        if (buttonMenuOpen)
        {
            noneButton.enabled = true;
            noneText.enabled = true;

            if(hasSun)
            {
                sunButton.enabled = true;
                sunText.enabled = true;
            }
            if(hasMercury)
            {
                mercuryButton.enabled = true;
                mercuryText.enabled = true;
            }
            if(hasVenus)
            {
                venusButton.enabled = true;
                venusText.enabled = true;
            }
            if(hasEarth)
            {
                earthButton.enabled = true;
                earthText.enabled = true;
            }
            if(hasMars)
            {
                marsButton.enabled = true;
                marsText.enabled = true;
            }
            if(hasJupiter)
            {
                jupiterButton.enabled = true;
                jupiterText.enabled = true;
            }
            if(hasSaturn)
            {
                saturnButton.enabled = true;
                saturnText.enabled = true;
            }
            if(hasUranus)
            {
                uranusButton.enabled = true;
                uranusText.enabled = true;
            }
        }
        //If the button menu is not open, all buttons will disapear
        else
        {
            noneButton.enabled = false;
            noneText.enabled = false;

            sunButton.enabled = false;
            sunText.enabled = false;

            mercuryButton.enabled = false;
            mercuryText.enabled = false;

            venusButton.enabled = false;
            venusText.enabled = false;

            earthButton.enabled = false;
            earthText.enabled = false;

            marsButton.enabled = false;
            marsText.enabled = false;

            jupiterButton.enabled = false;
            jupiterText.enabled = false;

            saturnButton.enabled = false;
            saturnText.enabled = false;

            uranusButton.enabled = false;
            uranusText.enabled = false;
        }
    }

    //A function for placing nothing on the currently selected stand
    public void PlaceNone()
    {
        currentStand.GetComponent<PanetPuzzleScript>().inDialouge = false;
        buttonMenuOpen = false;
        dialougeBox.GetComponent<RawImage>().enabled = false;
        dialougeText.enabled = false;
        player.enabled = true;
    }

    //A function for placing the sun on the currently selected stand
    public void PlaceSun()
    {
        currentStand.GetComponent<PanetPuzzleScript>().planets[0].SetActive(true);
        currentStand.GetComponent<PanetPuzzleScript>().currentlyEnabledPlanet = currentStand.GetComponent<PanetPuzzleScript>().planets[0];
        hasSun = false;
        for (int i = 0; i < player.inventoryTexts.Length; i++)
        {
            if (player.inventoryTexts[i].text == "Sun")
            {
                player.inventoryTexts[i].text = "";
                break;
            }
        }
        CloseButtonMenu();
    }

    //A function for placing Mercury on the currently selected stand
    public void PlaceMercury()
    {
        currentStand.GetComponent<PanetPuzzleScript>().planets[1].SetActive(true);
        currentStand.GetComponent<PanetPuzzleScript>().currentlyEnabledPlanet = currentStand.GetComponent<PanetPuzzleScript>().planets[1];
        hasMercury = false;
        for (int i = 0; i < player.inventoryTexts.Length; i++)
        {
            if (player.inventoryTexts[i].text == "Mercury")
            {
                player.inventoryTexts[i].text = "";
                break;
            }
        }
        CloseButtonMenu();
    }

    //A function for placing Venus on the currently selected stand
    public void PlaceVenus()
    {
        currentStand.GetComponent<PanetPuzzleScript>().planets[2].SetActive(true);
        currentStand.GetComponent<PanetPuzzleScript>().currentlyEnabledPlanet = currentStand.GetComponent<PanetPuzzleScript>().planets[2];
        hasVenus = false;
        for (int i = 0; i < player.inventoryTexts.Length; i++)
        {
            if (player.inventoryTexts[i].text == "Venus")
            {
                player.inventoryTexts[i].text = "";
                break;
            }
        }
        CloseButtonMenu();
    }

    //A function for placing Earth on the currently selected stand
    public void PlaceEarth()
    {
        currentStand.GetComponent<PanetPuzzleScript>().planets[3].SetActive(true);
        currentStand.GetComponent<PanetPuzzleScript>().currentlyEnabledPlanet = currentStand.GetComponent<PanetPuzzleScript>().planets[3];
        hasEarth = false;
        for (int i = 0; i < player.inventoryTexts.Length; i++)
        {
            if (player.inventoryTexts[i].text == "Earth")
            {
                player.inventoryTexts[i].text = "";
                break;
            }
        }
        CloseButtonMenu();
    }

    //A function for placing Mars on the currently selected stand
    public void PlaceMars()
    {
        currentStand.GetComponent<PanetPuzzleScript>().planets[4].SetActive(true);
        currentStand.GetComponent<PanetPuzzleScript>().currentlyEnabledPlanet = currentStand.GetComponent<PanetPuzzleScript>().planets[4];
        hasMars = false;
        for (int i = 0; i < player.inventoryTexts.Length; i++)
        {
            if (player.inventoryTexts[i].text == "Mars")
            {
                player.inventoryTexts[i].text = "";
                break;
            }
        }
        CloseButtonMenu();
    }

    //A function for placing Jupiter on the currently selected stand
    public void PlaceJupiter()
    {
        currentStand.GetComponent<PanetPuzzleScript>().planets[5].SetActive(true);
        currentStand.GetComponent<PanetPuzzleScript>().currentlyEnabledPlanet = currentStand.GetComponent<PanetPuzzleScript>().planets[5];
        hasJupiter = false;
        for (int i = 0; i < player.inventoryTexts.Length; i++)
        {
            if (player.inventoryTexts[i].text == "Jupiter")
            {
                player.inventoryTexts[i].text = "";
                break;
            }
        }
        CloseButtonMenu();
    }

    //A function for placing Saturn on the currently selected stand
    public void PlaceSaturn()
    {
        currentStand.GetComponent<PanetPuzzleScript>().planets[6].SetActive(true);
        currentStand.GetComponent<PanetPuzzleScript>().currentlyEnabledPlanet = currentStand.GetComponent<PanetPuzzleScript>().planets[6];
        hasSaturn = false;
        for (int i = 0; i < player.inventoryTexts.Length; i++)
        {
            if (player.inventoryTexts[i].text == "Saturn")
            {
                player.inventoryTexts[i].text = "";
                break;
            }
        }
        CloseButtonMenu();
    }

    //A function for placing Uranus on the currently selected stand
    public void PlaceUranus()
    {
        currentStand.GetComponent<PanetPuzzleScript>().planets[7].SetActive(true);
        currentStand.GetComponent<PanetPuzzleScript>().currentlyEnabledPlanet = currentStand.GetComponent<PanetPuzzleScript>().planets[7];
        hasUranus = false;
        for (int i = 0; i < player.inventoryTexts.Length; i++)
        {
            if (player.inventoryTexts[i].text == "Uranus")
            {
                player.inventoryTexts[i].text = "";
                break;
            }
        }
        CloseButtonMenu();
    }

    //A function for closing the button menu
    private void CloseButtonMenu()
    {
        currentStand.GetComponent<PanetPuzzleScript>().inDialouge = false;
        buttonMenuOpen = false;
        dialougeBox.GetComponent<RawImage>().enabled = false;
        dialougeText.enabled = false;
        player.enabled = true;
        player.inventorySpace--;
    }
}
