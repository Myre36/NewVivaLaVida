using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialougeScript : MonoBehaviour
{
    //A refrence to the dialouge box
    public RawImage dialougeBox;

    //A refrence to the dialouge text
    public TMP_Text dialougeText;

    //An array of all the dialouge that will be displayed
    public string[] dialouge;

    //A bool to check if the player is in range of the object
    public bool playerInRange = false;
    //A bool for if the object should have an outline or not
    public bool outlineEneabled = false;
    //A bool for if the object is a book or not
    public bool isBook;
    //A bool for if the player is in dialouge
    private bool inDialouge;

    //The current line in the dialouge
    public int lineNumber;

    private void Start()
    {
        //If the object is a book, the book sprite will be assigned as the dialouge box
        if(isBook)
        {
            dialougeBox = GameObject.Find("UIBook").GetComponent<RawImage>();
            dialougeText = GameObject.Find("UIBookText").GetComponent<TMP_Text>();
        }
        //If not, then the normal dialouge box is used
        else
        {
            dialougeBox = GameObject.Find("DialougeBox").GetComponent<RawImage>();
            dialougeText = GameObject.Find("DialougeText").GetComponent<TMP_Text>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //If the player is in range of the object and presses the interact key
        if(playerInRange)
        {
            if((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton1)))
            {
                //If the player has not reached the end of the dialouge, the next line will be displayed
                if(lineNumber < dialouge.Length)
                {
                    NextLine();
                }
                //If the player has reached the end of the dialouge, the dialouge will close
                else
                {
                    dialougeBox.enabled = false;
                    dialougeText.enabled = false;
                    inDialouge = false;
                    lineNumber = 0;
                }
            }
        }
    }

    //If the player enters the object's trigger, it will register that the player is in there and the outline will turn on if allowed
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if(outlineEneabled)
            {
                GetComponent<Outline>().enabled = true;
            }
        }
    }

    //If the player exits the object's trigger, it will register that the player is not there and the dialouge will turn off
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            dialougeBox.enabled = false;
            dialougeText.enabled = false;
            if(lineNumber > 0 && inDialouge)
            {
                lineNumber--;
                inDialouge = false;
            }
            if (outlineEneabled)
            {
                GetComponent<Outline>().enabled = false;
            }
        }
    }

    //A function for displaying the next dialouge line
    void NextLine()
    {
        inDialouge = true;
        dialougeBox.enabled = true;
        dialougeText.enabled = true;
        dialougeText.text = dialouge[lineNumber];
        lineNumber++;
    }
}
