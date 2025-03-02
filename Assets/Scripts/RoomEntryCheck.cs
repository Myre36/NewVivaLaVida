using System.Collections;
using UnityEngine;

public class RoomEntryCheck : MonoBehaviour
{
    //An array of all the entry points the room has
    public Transform[] entryPoints;
    public Transform[] cameraStartPoints;

    //A refrence to the player
    public GameObject player;
    //A refrence to the game manager
    public GameObject gameManager;
    //A refrence to the player camera
    public GameObject playerCamera;

    public CanvasGroup fadeScreen;

    private bool fadeOut = true;

    public float timeToFade;


    //Objects
    public Transform objectOne;
    public Transform objectTwo;

    //Object bools
    public bool isObjectOne;
    public bool isObjectTwo;

    //Enemies
    public GameObject enemyOne;
    public GameObject enemyTwo;
    public GameObject enemyThree;
    public GameObject enemyFour;
    public GameObject enemyFive;
    public GameObject enemySix;
    public GameObject enemySeven;
    public GameObject enemyEight;
    public GameObject enemyNine;
    public GameObject enemyTen;
    public GameObject enemyEleven;
    public GameObject enemyTwelve;
    public GameObject enemyThirteen;
    public GameObject enemyFourteen;

    //Enemy bools
    public bool isEnemyOne;
    public bool isEnemyTwo;
    public bool isEnemyThree;
    public bool isEnemyFour;
    public bool isEnemyFive;
    public bool isEnemySix;
    public bool isEnemySeven;
    public bool isEnemyEight;
    public bool isEnemyNine;
    public bool isEnemyTen;
    public bool isEnemyEleven;
    public bool isEnemyTwelve;
    public bool isEnemyThirteen;
    public bool isEnemyFourteen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Assigns the player,game manager, and camera
        gameManager = GameObject.Find("GameManager");
        player = GameObject.Find("Player");
        playerCamera = GameObject.Find("Main Camera");
        fadeScreen = GameObject.Find("FadeScreen").GetComponent<CanvasGroup>();

        StartCoroutine(MovePlayer());

        //Sets the object positions
        if (isObjectOne)
        {
            objectOne.position = gameManager.GetComponent<GameManager>().objectOnePosition;
        }
        if(isObjectTwo)
        {
            objectTwo.position = gameManager.GetComponent<GameManager>().objectTwoPosition;
        }

        //Sets the status of the enemies
        if(isEnemyOne)
        {
            if(gameManager.GetComponent<GameManager>().enemyOneDead == true)
            {
                Destroy(enemyOne);
            }
        }
        if (isEnemyTwo)
        {
            if (gameManager.GetComponent<GameManager>().enemyTwoDead == true)
            {
                Destroy(enemyTwo);
            }
        }
        if (isEnemyThree)
        {
            if (gameManager.GetComponent<GameManager>().enemyThreeDead == true)
            {
                Destroy(enemyThree);
            }
        }
        if (isEnemyFour)
        {
            if (gameManager.GetComponent<GameManager>().enemyFourDead == true)
            {
                Destroy(enemyFour);
            }
        }
        if (isEnemyFive)
        {
            if (gameManager.GetComponent<GameManager>().enemyFiveDead == true)
            {
                Destroy(enemyFive);
            }
        }
        if (isEnemySix)
        {
            if (gameManager.GetComponent<GameManager>().enemySixDead == true)
            {
                Destroy(enemySix);
            }
        }
        if (isEnemySeven)
        {
            if (gameManager.GetComponent<GameManager>().enemySevenDead == true)
            {
                Destroy(enemySeven);
            }
        }
        if (isEnemyEight)
        {
            if (gameManager.GetComponent<GameManager>().enemyEightDead == true)
            {
                Destroy(enemyEight);
            }
        }
        if (isEnemyNine)
        {
            if (gameManager.GetComponent<GameManager>().enemyNineDead == true)
            {
                Destroy(enemyNine);
            }
        }
        if (isEnemyTen)
        {
            if (gameManager.GetComponent<GameManager>().enemyTenDead == true)
            {
                Destroy(enemyTen);
            }
        }
        if (isEnemyEleven)
        {
            if (gameManager.GetComponent<GameManager>().enemyElevenDead == true)
            {
                Destroy(enemyEleven);
            }
        }
        if (isEnemyTwelve)
        {
            if (gameManager.GetComponent<GameManager>().enemyTwelveDead == true)
            {
                Destroy(enemyTwelve);
            }
        }
        if (isEnemyThirteen)
        {
            if (gameManager.GetComponent<GameManager>().enemyThirteenDead == true)
            {
                Destroy(enemyThirteen);
            }
        }
        if (isEnemyFourteen)
        {
            if (gameManager.GetComponent<GameManager>().enemyFourteenDead == true)
            {
                Destroy(enemyFourteen);
            }
        }
    }

    private void Update()
    {
        if (fadeOut)
        {
            if (fadeScreen.alpha >= 0)
            {
                fadeScreen.alpha -= timeToFade * Time.deltaTime;
                if (fadeScreen.alpha == 0)
                {
                    fadeOut = false;
                }
            }
        }
    }

    public void SaveObjectPositions()
    {
        if(isObjectOne)
        {
            gameManager.GetComponent<GameManager>().objectOnePosition = objectOne.position;
        }
        if(isObjectTwo)
        {
            gameManager.GetComponent<GameManager>().objectTwoPosition = objectTwo.position;
        }
    }

    IEnumerator MovePlayer()
    {
        //Gets the entry number in the game manager (assigned from the door in the previous scene
        int entryNum = gameManager.GetComponent<GameManager>().entryNumber;

        Rigidbody rb = player.gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = true;

        //Sets the player's position to the entry point
        player.transform.position = entryPoints[entryNum].position;
        player.transform.rotation = entryPoints[entryNum].rotation;

        //Sets the camera position
        playerCamera.transform.position = cameraStartPoints[entryNum].position;

        yield return new WaitForSeconds(0.1f);

        player.GetComponent<Movement>().enabled = true;

        rb.isKinematic = false;
    }
}
