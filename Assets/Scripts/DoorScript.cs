using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    //The number of the door. Used to determine where the player will spawn in the next scene
    public int doorNumber;

    //A string used to load the correct scene when the door is opened
    public string sceneName;

    //A refrence to the game manager
    public GameManager gameManager;

    //A bool to help check if the player is by the door
    public bool playerInDoor = false;
    //A bool to tell if it should fade out now
    private bool fadeIn = false;

    //Refrence to the player's movement
    public Movement player;

    //A refrence to the black screen that fades in
    public CanvasGroup fadeScreen;

    //The anount of time it takes for the screen to fade
    public float timeToFade;

    public bool isPlanetDoor;


    private void Start()
    {
        //Assigning refrences
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        fadeScreen = GameObject.Find("FadeScreen").GetComponent<CanvasGroup>();
        player = GameObject.Find("Player").GetComponent<Movement>();
    }

    private void Update()
    {
        //If the player is by the door and press the interact key
        if(playerInDoor)
        {
            if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton1)) && !player.inMandatory)
            {
                //The door accesses the game manager and assigns its entry number as the same as the door number
                gameManager.entryNumber = doorNumber;

                if(isPlanetDoor)
                {
                    PlanetCheckScript planetChecker = GameObject.Find("PlanetChecker").GetComponent<PlanetCheckScript>();

                    for(int i = 0; i < planetChecker.stands.Length; i++)
                    {
                        var currentStand = planetChecker.stands[i].GetComponent<PanetPuzzleScript>();

                        if (currentStand.currentlyEnabledPlanet == null)
                        {
                            gameManager.stands[i] = "None";
                        }
                        else
                        {
                            gameManager.stands[i] = currentStand.currentlyEnabledPlanet.name;
                        }
                    }
                }
                //Then, it calls the function that loads the next scene
                StartCoroutine(OpenDoor());
            }
        }
        //If the fade in is activated, the black screen will slowly fade in
        if (fadeIn)
        {
            if (fadeScreen.alpha < 1)
            {
                fadeScreen.alpha += timeToFade * Time.deltaTime;
                if (fadeScreen.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }
    }

    //Code to check when the player enters the door trigger, it will register it
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInDoor = true;
        }
    }

    //Code to check when the player exits the door trigger, it will register that
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInDoor = false;
        }
    }

    //A function that loads the next scene
    public IEnumerator OpenDoor()
    {
        Debug.Log("Loading next scene");
        player.enabled = false;
        fadeIn = true; 
        player.enabled = false;
        yield return new WaitForSeconds(timeToFade + 0.2f);
        SceneManager.LoadScene(sceneName);
    }
}
