using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CombinationLockScript : MonoBehaviour
{
    //The input field the player will write in
    public TMP_InputField playerInput;

    //Bool for when the player is in range of the door
    private bool playerInRange = false;
    //Bool for when the player is in dialouge. This is to make sure certain things don't happen while they are in dialouge
    private bool inDialouge = false;
    //A bool for when the puzzle is solved. This is to make sure certain things don't happen after the puzzle is solved
    private bool puzzleSolved = false;

    //A refrence to the player's movement script
    private Movement player;

    //A refrence to the camera script
    private CameraScript cam;

    //A string which will have the correct combination in it
    public string correctCombination;

    //A refrence to the game manager
    public GameManager gameManager;

    private void Awake()
    {
        //Assigns the game manager
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        //If the puzzle has already been solved, then the door will be opened and this script will turn off
        if (gameManager.combinationSolved)
        {
            GetComponent<DoorScript>().enabled = true;
            GetComponent<DoorScript>().playerInDoor = true;
            this.enabled = false;
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Getting a bunch of refrences
        playerInput = GameObject.Find("PlayerInput").GetComponent<TMP_InputField>();
        player = GameObject.Find("Player").GetComponent<Movement>();
        cam = Camera.main.GetComponent<CameraScript>();
        playerInput.gameObject.GetComponent<Image>().enabled = true;
        //The below code makes sure the input field is not visible
        playerInput.enabled = true;
        foreach(Transform child in playerInput.gameObject.transform)
        {
            child.gameObject.SetActive(true);
        }
        playerInput.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //If the player is in range of the door and presses E
        if(playerInRange)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                //If they are already in the dialouge, the input field will turn itself off and the player can move again
                if(inDialouge)
                {
                    inDialouge = false;
                    player.enabled = true;
                    cam.enabled = true;
                    playerInput.gameObject.GetComponent<Image>().enabled = false;
                    playerInput.enabled = false;
                    foreach (Transform child in playerInput.gameObject.transform)
                    {
                        child.gameObject.SetActive(false);
                    }
                    playerInput.gameObject.SetActive(true);
                }
                //If the player is not already in dialouge, the input field will be turned on
                else
                {
                    inDialouge = true;
                    player.enabled = false;
                    cam.enabled = false;
                    playerInput.gameObject.GetComponent<Image>().enabled = true;
                    playerInput.enabled = true;
                    foreach (Transform child in playerInput.gameObject.transform)
                    {
                        child.gameObject.SetActive(true);
                    }
                    playerInput.gameObject.SetActive(true);
                }
            }
        }
        //If the player presses Enter while in dialouge, it will check if the combination is correct
        if(inDialouge)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                //If they put in the correct combination, the door will open and the input field dissapear
                if(playerInput.text == correctCombination)
                {
                    Debug.Log("Correct combination");
                    gameManager.combinationSolved = true;
                    inDialouge = false;
                    player.enabled = true;
                    playerInRange = false;
                    puzzleSolved = true;
                    cam.enabled = true;
                    playerInput.gameObject.SetActive(false);
                    GetComponent<DoorScript>().enabled = true;
                    GetComponent<DoorScript>().playerInDoor = true;
                    this.enabled = false;
                }
                //If they input the incorrect combination, the input string will become empty
                else
                {
                    Debug.Log("Incorrect combination");
                    playerInput.text = "";
                }
            }
        }
    }

    //If the player enters the door's trigger, it will know that the player is in range of the door
    private void OnTriggerEnter(Collider other)
    {
        if(!puzzleSolved)
        {
            if (other.CompareTag("Player"))
            {
                playerInRange = true;
            }
        }
    }

    //If the player exits the door's trigger, it will know that they are no longer in range of the door
    private void OnTriggerExit(Collider other)
    {
        if (!puzzleSolved)
        {
            if (other.CompareTag("Player"))
            {
                playerInRange = false;
            }
        }
    }
}
