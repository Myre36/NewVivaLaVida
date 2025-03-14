using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MandatoryDialouge : MonoBehaviour
{
    private Movement player;

    private GameObject dialougeBox;
    private TMP_Text dialougeText;
    public string[] dialouge;
    private int lineNumber;

    private GameManager gameManager;

    public bool introDialouge;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("Player").GetComponent<Movement>();
        dialougeBox = GameObject.Find("DialougeBox");
        dialougeText = GameObject.Find("DialougeText").GetComponent<TMP_Text>();
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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton1))
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

    void NextLine()
    {
        dialougeBox.GetComponent<RawImage>().enabled = true;
        dialougeText.enabled = true;
        dialougeText.text = dialouge[lineNumber];
        lineNumber++;
    }

    IEnumerator DelayStart()
    {
        yield return new WaitForSeconds(0.2f);
        player.inMandatory = true;
        player.enabled = false;
        NextLine();
    }

    IEnumerator DelayEnd()
    {
        dialougeBox.GetComponent<RawImage>().enabled = false;
        dialougeText.enabled = false;
        lineNumber = 0;
        yield return new WaitForSeconds(0.2f);
        player.enabled = true;
        player.inMandatory = false;
        gameManager.introDialougeDone = true;
        Destroy(gameObject);
    }
}
