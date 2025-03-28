using System.Collections;
using UnityEngine;

public class RoomEntryCheck : MonoBehaviour
{
    //An array of all the entry points the room has
    public Transform[] entryPoints;
    //An array of all the camera points this room has
    public Transform[] cameraStartPoints;

    //A refrence to the game manager
    public GameManager gameManager;

    //A refrence to the player
    public GameObject player;
    //A refrence to the player camera
    public GameObject playerCamera;
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

    //A refrence to the black fade screen
    public CanvasGroup fadeScreen;

    //A bool to check if this should fade or not
    private bool fadeOut = true;
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

    //The time it takes to fade in
    public float timeToFade;

    private void Awake()
    {
        //Assigns all the refrences
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("Player");
        playerCamera = GameObject.Find("Main Camera");
        fadeScreen = GameObject.Find("FadeScreen").GetComponent<CanvasGroup>();

        //Starts the coroutine to move the player to the correct position
        StartCoroutine(MovePlayer());
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Enemies are destroyed depending at which state they are in
        if(isEnemyOne)
        {
            if(gameManager.enemyOneDead)
            {
                Destroy(enemyOne);
            }
            else if(gameManager.enemyOneFakeDead)
            {
                if(gameManager.enemyOneTimer < gameManager.enemyRespawnTime)
                {
                    Destroy(enemyOne);
                }
            }
        }
        if (isEnemyTwo)
        {
            if (gameManager.enemyTwoDead)
            {
                Destroy(enemyTwo);
            }
            else if (gameManager.enemyTwoFakeDead)
            {
                if (gameManager.enemyTwoTimer < gameManager.enemyRespawnTime)
                {
                    Destroy(enemyTwo);
                }
            }
        }
        if (isEnemyThree)
        {
            if (gameManager.enemyThreeDead)
            {
                Destroy(enemyThree);
            }
            else if (gameManager.enemyThreeFakeDead)
            {
                if (gameManager.enemyThreeTimer < gameManager.enemyRespawnTime)
                {
                    Destroy(enemyThree);
                }
            }
        }
        if (isEnemyFour)
        {
            if (gameManager.enemyFourDead)
            {
                Destroy(enemyFour);
            }
            else if (gameManager.enemyFourFakeDead)
            {
                if (gameManager.enemyFourTimer < gameManager.enemyRespawnTime)
                {
                    Destroy(enemyFour);
                }
            }
        }
        if (isEnemyFive)
        {
            if (gameManager.enemyFiveDead)
            {
                Destroy(enemyFive);
            }
            else if (gameManager.enemyFiveFakeDead)
            {
                if (gameManager.enemyFiveTimer < gameManager.enemyRespawnTime)
                {
                    Destroy(enemyFive);
                }
            }
        }
        if (isEnemySix)
        {
            if (gameManager.enemySixDead)
            {
                Destroy(enemySix);
            }
            else if (gameManager.enemySixFakeDead)
            {
                if (gameManager.enemySixTimer < gameManager.enemyRespawnTime)
                {
                    Destroy(enemySix);
                }
            }
        }
        if (isEnemySeven)
        {
            if (gameManager.enemySevenDead)
            {
                Destroy(enemySeven);
            }
            else if (gameManager.enemySevenFakeDead)
            {
                if (gameManager.enemySevenTimer < gameManager.enemyRespawnTime)
                {
                    Destroy(enemySeven);
                }
            }
        }
        if (isEnemyEight)
        {
            if (gameManager.enemyEightDead)
            {
                Destroy(enemyEight);
            }
            else if (gameManager.enemyEightFakeDead)
            {
                if (gameManager.enemyEightTimer < gameManager.enemyRespawnTime)
                {
                    Destroy(enemyEight);
                }
            }
        }
        if (isEnemyNine)
        {
            if (gameManager.enemyNineDead)
            {
                Destroy(enemyNine);
            }
            else if (gameManager.enemyNineFakeDead)
            {
                if (gameManager.enemyNineTimer < gameManager.enemyRespawnTime)
                {
                    Destroy(enemyNine);
                }
            }
        }
        if (isEnemyTen)
        {
            if (gameManager.enemyTenDead)
            {
                Destroy(enemyTen);
            }
            else if (gameManager.enemyTenFakeDead)
            {
                if (gameManager.enemyTenTimer < gameManager.enemyRespawnTime)
                {
                    Destroy(enemyTen);
                }
            }
        }
        if (isEnemyEleven)
        {
            if (gameManager.enemyElevenDead)
            {
                Destroy(enemyEleven);
            }
            else if (gameManager.enemyElevenFakeDead)
            {
                if (gameManager.enemyElevenTimer < gameManager.enemyRespawnTime)
                {
                    Destroy(enemyEleven);
                }
            }
        }
        if (isEnemyTwelve)
        {
            if (gameManager.enemyTwelveDead)
            {
                Destroy(enemyTwelve);
            }
            else if (gameManager.enemyTwelveFakeDead)
            {
                if (gameManager.enemyTwelveTimer < gameManager.enemyRespawnTime)
                {
                    Destroy(enemyTwelve);
                }
            }
        }
        if (isEnemyThirteen)
        {
            if (gameManager.enemyThirteenDead)
            {
                Destroy(enemyThirteen);
            }
            else if (gameManager.enemyThirteenFakeDead)
            {
                if (gameManager.enemyThirteenTimer < gameManager.enemyRespawnTime)
                {
                    Destroy(enemyThirteen);
                }
            }
        }
        if (isEnemyFourteen)
        {
            if (gameManager.enemyFourteenDead)
            {
                Destroy(enemyFourteen);
            }
            else if (gameManager.enemyFourteenFakeDead)
            {
                if (gameManager.enemyFourteenTimer < gameManager.enemyRespawnTime)
                {
                    Destroy(enemyFourteen);
                }
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

    //A coroutine for moving the player to the correct spot
    IEnumerator MovePlayer()
    {
        //Gets the entry number in the game manager (assigned from the door in the previous scene)
        int entryNum = gameManager.entryNumber;

        //Gets a refrence to the rigidbody
        Rigidbody rb = player.gameObject.GetComponent<Rigidbody>();
        //The only way for this to work is for the player's rigidbody to be kinematic. I don't know why, it bugs if it isn't
        rb.isKinematic = true;

        //Sets the player's position and rotation to the entry point
        player.transform.position = entryPoints[entryNum].position;
        player.transform.rotation = entryPoints[entryNum].rotation;

        //Sets the camera position
        playerCamera.transform.position = cameraStartPoints[entryNum].position;

        //Waits for a bit
        yield return new WaitForSeconds(0.1f);

        //Enables the player movement
        player.GetComponent<Movement>().enabled = true;

        //Makes the player not kinematic
        rb.isKinematic = false;
    }
}
