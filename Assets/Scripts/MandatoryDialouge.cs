using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MandatoryDialouge : MonoBehaviour
{
    //A refrence to the player movement
    private Movement player;

    //A refrence to the player dialouge box
    private GameObject dialougeBox;

    //A refrence to the dialouge text
    private TMP_Text dialougeText;

    //A refrence to all the dialouge that will play
    public string[] dialouge;

    //A refrence to what line number you are on
    private int lineNumber;

    //A refrence to the game manager
    private GameManager gameManager;

    //Bools to check which dialouge this is
    public bool introDialouge;
    public bool tutorialDialouge;
    public bool afterEnemyDialouge;
    public bool livingRoomDialouge;
    public bool eastHallwayDialouge;
    public bool kitchenDialouge;
    public bool afterKitchenDialouge;
    public bool afterBasementDialouge;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Assigning all refrences
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("Player").GetComponent<Movement>();
        dialougeBox = GameObject.Find("DialougeBox");
        dialougeText = GameObject.Find("DialougeText").GetComponent<TMP_Text>();
        //This checks if the dialouge has already played, to prevent things from playing twice
        if (introDialouge)
        {
            if(!gameManager.introDialougeDone)
            {
                player.inMandatory = true;
                player.enabled = false;
                StartCoroutine(DelayStart());
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else if (tutorialDialouge)
        {
            if (!gameManager.tutorialDialougeDone)
            {
                player.inMandatory = true;
                player.enabled = false;
                StartCoroutine(DelayStart());
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else if (afterEnemyDialouge)
        {
            if (!gameManager.afterEnemyDone)
            {
                player.inMandatory = true;
                player.enabled = false;
                StartCoroutine(DelayStart());
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else if (livingRoomDialouge)
        {
            if (!gameManager.livingRoomDialougeDone)
            {
                player.inMandatory = true;
                player.enabled = false;
                StartCoroutine(DelayStart());
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else if (eastHallwayDialouge)
        {
            if (!gameManager.eastHallwayDialougeDone)
            {
                player.inMandatory = true;
                player.enabled = false;
                StartCoroutine(DelayStart());
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else if (kitchenDialouge)
        {
            if (!gameManager.kitchenDialougeDone)
            {
                player.inMandatory = true;
                player.enabled = false;
                StartCoroutine(DelayStart());
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else if (afterKitchenDialouge)
        {
            if (!gameManager.afterKitchenDialougeDone && gameManager.secondFloorKey)
            {
                player.inMandatory = true;
                player.enabled = false;
                StartCoroutine(DelayStart());
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else if (afterBasementDialouge)
        {
            if (!gameManager.afterBasementDialougeDone && gameManager.kingsKeyOne)
            {
                player.inMandatory = true;
                player.enabled = false;
                StartCoroutine(DelayStart());
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //If you press E, you either continue to the next line, or the dialouge ends
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (lineNumber < dialouge.Length)
            {
                NextLine();
            }
            else
            {
                StartCoroutine(DelayEnd());
            }
        }
    }

    //A function for playing the next line
    void NextLine()
    {
        dialougeBox.GetComponent<RawImage>().enabled = true;
        dialougeText.enabled = true;
        dialougeText.text = dialouge[lineNumber];
        lineNumber++;
    }

    //A function for a delayed start to prevent any conflicts with other scripts
    IEnumerator DelayStart()
    {
        yield return new WaitForSeconds(0.2f);
        player.inMandatory = true;
        player.enabled = false;
        NextLine();
    }

    //A function for closing down the dialouge
    IEnumerator DelayEnd()
    {
        dialougeBox.GetComponent<RawImage>().enabled = false;
        dialougeText.enabled = false;
        lineNumber = 0;
        yield return new WaitForSeconds(0.2f);
        player.enabled = true;
        player.inMandatory = false;
        if(introDialouge)
        {
            gameManager.introDialougeDone = true;
        }
        else if(tutorialDialouge)
        {
            gameManager.tutorialDialougeDone = true;
        }
        else if(afterEnemyDialouge)
        {
            gameManager.afterEnemyDone = true;
        }
        else if(livingRoomDialouge)
        {
            gameManager.livingRoomDialougeDone = true;
        }
        else if (eastHallwayDialouge)
        {
            gameManager.eastHallwayDialougeDone = true;
        }
        else if (kitchenDialouge)
        {
            gameManager.kitchenDialougeDone = true;
        }
        else if (afterKitchenDialouge)
        {
            gameManager.afterKitchenDialougeDone = true;
        }
        else if (afterBasementDialouge)
        {
            gameManager.afterBasementDialougeDone = true;
        }
        Destroy(gameObject);
    }
}
