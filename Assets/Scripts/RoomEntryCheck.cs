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
    public GameObject enemyFifteen;
    public GameObject enemySixteen;
    public GameObject enemySeventeen;

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
    public bool isEnemyFifteen;
    public bool isEnemySixteen;
    public bool isEnemySeventeen;

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
            Enemy currentEnemy = enemyOne.GetComponent<Enemy>();
            if (gameManager.enemyOneDead)
            {
                currentEnemy.DisableEverything();
            }
            else if(gameManager.enemyOneFakeDead)
            {
                if(gameManager.enemyOneTimer < gameManager.enemyRespawnTime)
                {
                    currentEnemy.DisableEverything();
                }
            }
        }
        if (isEnemyTwo)
        {
            Enemy currentEnemy = enemyTwo.GetComponent<Enemy>();
            if (gameManager.enemyTwoDead)
            {
                currentEnemy.DisableEverything();
            }
            else if (gameManager.enemyTwoFakeDead)
            {
                if (gameManager.enemyTwoTimer < gameManager.enemyRespawnTime)
                {
                    currentEnemy.DisableEverything();
                }
            }
        }
        if (isEnemyThree)
        {
            Enemy currentEnemy = enemyThree.GetComponent<Enemy>();
            if (gameManager.enemyThreeDead)
            {
                currentEnemy.DisableEverything();
            }
            else if (gameManager.enemyThreeFakeDead)
            {
                if (gameManager.enemyThreeTimer < gameManager.enemyRespawnTime)
                {
                    currentEnemy.DisableEverything();
                }
            }
        }
        if (isEnemyFour)
        {
            Enemy currentEnemy = enemyFour.GetComponent<Enemy>();
            if (gameManager.enemyFourDead)
            {
                currentEnemy.DisableEverything();
            }
            else if (gameManager.enemyFourFakeDead)
            {
                if (gameManager.enemyFourTimer < gameManager.enemyRespawnTime)
                {
                    currentEnemy.DisableEverything();
                }
            }
        }
        if (isEnemyFive)
        {
            Enemy currentEnemy = enemyFive.GetComponent<Enemy>();
            if (gameManager.enemyFiveDead)
            {
                currentEnemy.DisableEverything();
            }
            else if (gameManager.enemyFiveFakeDead)
            {
                if (gameManager.enemyFiveTimer < gameManager.enemyRespawnTime)
                {
                    currentEnemy.DisableEverything();
                }
            }
        }
        if (isEnemySix)
        {
            Enemy currentEnemy = enemySix.GetComponent<Enemy>();
            if (gameManager.enemySixDead)
            {
                currentEnemy.DisableEverything();
            }
            else if (gameManager.enemySixFakeDead)
            {
                if (gameManager.enemySixTimer < gameManager.enemyRespawnTime)
                {
                    currentEnemy.DisableEverything();
                }
            }
        }
        if (isEnemySeven)
        {
            Enemy currentEnemy = enemySeven.GetComponent<Enemy>();
            if (gameManager.enemySevenDead)
            {
                currentEnemy.DisableEverything();
            }
            else if (gameManager.enemySevenFakeDead)
            {
                if (gameManager.enemySevenTimer < gameManager.enemyRespawnTime)
                {
                    currentEnemy.DisableEverything();
                }
            }
        }
        if (isEnemyEight)
        {
            Enemy currentEnemy = enemyEight.GetComponent<Enemy>();
            if (gameManager.enemyEightDead)
            {
                currentEnemy.DisableEverything();
            }
            else if (gameManager.enemyEightFakeDead)
            {
                if (gameManager.enemyEightTimer < gameManager.enemyRespawnTime)
                {
                    currentEnemy.DisableEverything();
                }
            }
        }
        if (isEnemyNine)
        {
            Enemy currentEnemy = enemyNine.GetComponent<Enemy>();
            if (gameManager.enemyNineDead)
            {
                currentEnemy.DisableEverything();
            }
            else if (gameManager.enemyNineFakeDead)
            {
                if (gameManager.enemyNineTimer < gameManager.enemyRespawnTime)
                {
                    currentEnemy.DisableEverything();
                }
            }
        }
        if (isEnemyTen)
        {
            Enemy currentEnemy = enemyTen.GetComponent<Enemy>();
            if (gameManager.enemyTenDead)
            {
                currentEnemy.DisableEverything();
            }
            else if (gameManager.enemyTenFakeDead)
            {
                if (gameManager.enemyTenTimer < gameManager.enemyRespawnTime)
                {
                    currentEnemy.DisableEverything();
                }
            }
        }
        if (isEnemyEleven)
        {
            Enemy currentEnemy = enemyEleven.GetComponent<Enemy>();
            if (gameManager.enemyElevenDead)
            {
                currentEnemy.DisableEverything();
            }
            else if (gameManager.enemyElevenFakeDead)
            {
                if (gameManager.enemyElevenTimer < gameManager.enemyRespawnTime)
                {
                    currentEnemy.DisableEverything();
                }
            }
        }
        if (isEnemyTwelve)
        {
            Enemy currentEnemy = enemyTwelve.GetComponent<Enemy>();
            if (gameManager.enemyTwelveDead)
            {
                currentEnemy.DisableEverything();
            }
            else if (gameManager.enemyTwelveFakeDead)
            {
                if (gameManager.enemyTwelveTimer < gameManager.enemyRespawnTime)
                {
                    currentEnemy.DisableEverything();
                }
            }
        }
        if (isEnemyThirteen)
        {
            Enemy currentEnemy = enemyThirteen.GetComponent<Enemy>();
            if (gameManager.enemyThirteenDead)
            {
                currentEnemy.DisableEverything();
            }
            else if (gameManager.enemyThirteenFakeDead)
            {
                if (gameManager.enemyThirteenTimer < gameManager.enemyRespawnTime)
                {
                    currentEnemy.DisableEverything();
                }
            }
        }
        if (isEnemyFourteen)
        {
            Enemy currentEnemy = enemyFourteen.GetComponent<Enemy>();
            if (gameManager.enemyFourteenDead)
            {
                currentEnemy.DisableEverything();
            }
            else if (gameManager.enemyFourteenFakeDead)
            {
                if (gameManager.enemyFourteenTimer < gameManager.enemyRespawnTime)
                {
                    currentEnemy.DisableEverything();
                }
            }
        }
        if (isEnemyFifteen)
        {
            Enemy currentEnemy = enemyFifteen.GetComponent<Enemy>();
            if (gameManager.enemyFifteenDead)
            {
                currentEnemy.DisableEverything();
            }
            else if (gameManager.enemyFifteenFakeDead)
            {
                if (gameManager.enemyFifteenTimer < gameManager.enemyRespawnTime)
                {
                    currentEnemy.DisableEverything();
                }
            }
        }
        if (isEnemySixteen)
        {
            Enemy currentEnemy = enemySixteen.GetComponent<Enemy>();
            if (gameManager.enemySixteenDead)
            {
                currentEnemy.DisableEverything();
            }
            else if (gameManager.enemySixteenFakeDead)
            {
                if (gameManager.enemySixteenTimer < gameManager.enemyRespawnTime)
                {
                    currentEnemy.DisableEverything();
                }
            }
        }
        if (isEnemySeventeen)
        {
            Enemy currentEnemy = enemySeventeen.GetComponent<Enemy>();
            if (gameManager.enemySeventeenDead)
            {
                currentEnemy.DisableEverything();
            }
            else if (gameManager.enemySeventeenFakeDead)
            {
                if (gameManager.enemySeventeenTimer < gameManager.enemyRespawnTime)
                {
                    currentEnemy.DisableEverything();
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
