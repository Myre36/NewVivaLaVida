using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveGameScript : MonoBehaviour
{
    [SerializeField]
    private Movement player;

    [SerializeField]
    private GunScript gunScript;

    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private PlanetPickerScript planetPicker;

    [SerializeField]
    private MapManager mapManager;

    //Refrence to the dialouge box
    private RawImage dialougeBox;

    //Refrence to the dialouge text
    private TMP_Text dialougeText;

    //A bool that checks if the player is in range
    private bool playerInRange;

    //A bool for if the player is in dialouge
    private bool inDialouge;

    [SerializeField]
    private Image saveButton;
    [SerializeField]
    private TMP_Text saveText;

    [SerializeField]
    private Image closeButton;
    [SerializeField]
    private TMP_Text closeText;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Movement>();
        gunScript = player.gun.GetComponent<GunScript>();

        gameManager = player.gameManager;
        planetPicker = GameObject.Find("PlanetPicker").GetComponent<PlanetPickerScript>();
        mapManager = gameManager.mapManager;

        //Assigning all refrences
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        dialougeBox = GameObject.Find("DialougeBox").GetComponent<RawImage>();
        dialougeText = GameObject.Find("DialougeText").GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if(playerInRange)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if (player.inventoryIsOpen || gameManager.GetComponent<MapManager>().mapIsOpen)
                {
                    return;
                }

                player.inDialouge = true;
                player.ResetAnimations();
                player.enabled = false;

                if(inDialouge)
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;

                    saveButton.enabled = true;
                    saveText.enabled = true;

                    closeButton.enabled = true;
                    closeText.enabled = true;
                }
                else
                {
                    inDialouge = true;
                    dialougeBox.enabled = true;
                    dialougeText.enabled = true;
                    dialougeText.text = "Do you wish to save your progress?";
                }
            }
        }
    }

    public void SaveGame()
    {
        CloseDialouge();
        SaveSystem.SavePlayerData(player, gunScript, gameManager, planetPicker, mapManager);
        Debug.Log("Game Saved");
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

    public void CloseDialouge()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        saveButton.enabled = false;
        saveText.enabled = false;

        closeButton.enabled = false;
        closeText.enabled = false;

        inDialouge = false;
        dialougeBox.enabled = false;
        dialougeText.enabled = false;

        player.inDialouge = false;

        player.enabled = true;
    }
}
