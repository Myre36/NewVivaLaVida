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

    public GameObject door;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Movement>();
        dialougeBox = GameObject.Find("DialougeBox");
        dialougeText = GameObject.Find("DialougeText").GetComponent<TMP_Text>();
        door.GetComponent<DialougeScript>().enabled = false;
        StartCoroutine(DelayStart());
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
                dialougeBox.GetComponent<RawImage>().enabled = false;
                dialougeText.enabled = false;
                lineNumber = 0;
                player.enabled = true;
                door.GetComponent<DialougeScript>().enabled = true;
                Destroy(gameObject);
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
        yield return new WaitForSeconds(0.5f);
        player.enabled = false;
        NextLine();
    }
}
