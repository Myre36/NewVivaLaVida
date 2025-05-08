using UnityEngine;

public class GameManager : MonoBehaviour
{
    //This is something used to make sure there is never more than one game manager
    private static GameManager instance;

    //The number used to spawn the player in the correct location when entering a room
    public int entryNumber;

    public int enemyRespawnTime;

    public bool firstBullet;
    public bool firstPlant;

    //Bools for if all the enemies are dead
    public bool enemyOneFakeDead = false;
    public bool enemyTwoFakeDead = false;
    public bool enemyThreeFakeDead = false;
    public bool enemyFourFakeDead = false;
    public bool enemyFiveFakeDead = false;
    public bool enemySixFakeDead = false;
    public bool enemySevenFakeDead = false;
    public bool enemyEightFakeDead = false;
    public bool enemyNineFakeDead = false;
    public bool enemyTenFakeDead = false;
    public bool enemyElevenFakeDead = false;
    public bool enemyTwelveFakeDead = false;
    public bool enemyThirteenFakeDead = false;
    public bool enemyFourteenFakeDead = false;
    public bool enemyFifteenFakeDead = false;
    public bool enemySixteenFakeDead = false;

    public bool enemyOneDead = false;
    public bool enemyTwoDead = false;
    public bool enemyThreeDead = false;
    public bool enemyFourDead = false;
    public bool enemyFiveDead = false;
    public bool enemySixDead = false;
    public bool enemySevenDead = false;
    public bool enemyEightDead = false;
    public bool enemyNineDead = false;
    public bool enemyTenDead = false;
    public bool enemyElevenDead = false;
    public bool enemyTwelveDead = false;
    public bool enemyThirteenDead = false;
    public bool enemyFourteenDead = false;
    public bool enemyFifteenDead = false;
    public bool enemySixteenDead = false;

    public float enemyOneTimer;
    public float enemyTwoTimer;
    public float enemyThreeTimer;
    public float enemyFourTimer;
    public float enemyFiveTimer;
    public float enemySixTimer;
    public float enemySevenTimer;
    public float enemyEightTimer;
    public float enemyNineTimer;
    public float enemyTenTimer;
    public float enemyElevenTimer;
    public float enemyTwelveTimer;
    public float enemyThirteenTimer;
    public float enemyFourteenTimer;
    public float enemyFifteenTimer;
    public float enemySixteenTimer;

    //Bools for if the player has all the coins
    public bool coinOne;
    public bool coinTwo;
    public bool coinThree;

    //Bools for non-key objects
    public bool sword;
    public bool clothPile;
    public bool book;

    //Bools for if the player has solved certain puzzles
    public bool toiletClogged;
    public bool swordPlaced;
    public bool bookPlaced;

    //Bools for if teh player has certain keys
    public bool firstKey;
    public bool hallwayKey;
    public bool planetariumKey;
    public bool meetingKey;
    public bool secondFloorKey;
    public bool servantsKey;
    public bool tunnelKey;

    //Bools for if the player has the endgame keys
    public bool basementKey;
    public bool kingsKeyOne;
    public bool kingsKeyTwo;

    //Bools for if the player has unlocked certain doors
    public bool firstUnlocked;
    public bool hallwayUnlocked;
    public bool tunnelUnlocked;
    public bool servantsUnlocked;
    public bool basementUnlocked;
    public bool secondFloorUnlocked;
    public bool planetariumUnlocked;
    public bool meetingUnlocked;
    public bool coinUnlocked;
    public bool kingsUnlocked;

    public bool kitchenUnlocked;
    public bool statueRoomUnlocked;
    public bool diningUnlocked;

    //Bools for if the player has solved certain puzzles
    public bool planetSolved;
    public bool combinationSolved;

    //Bools for all the bullets in the game
    public bool bullet1;
    public bool bullet2;
    public bool bullet3;
    public bool bullet4;
    public bool bullet5;
    public bool bullet6;
    public bool bullet7;
    public bool bullet8;
    public bool bullet9;
    public bool bullet10;
    public bool bullet11;
    public bool bullet12;
    public bool bullet13;
    public bool bullet14;
    public bool bullet15;
    public bool bullet16;

    public bool introDialougeDone;
    public bool tutorialDialougeDone;
    public bool afterEnemyDone;
    public bool livingRoomDialougeDone;
    public bool eastHallwayDialougeDone;
    public bool kitchenDialougeDone;
    public bool afterKitchenDialougeDone;
    public bool afterBasementDialougeDone;
    public bool bothKeysDialougeDone;
    public bool statueDialougeDone;
    public bool secondFloorDialougeDone;
    public bool planetariumDialougeDone;
    public bool libraryDialougeDone;
    public bool afterKingBedDialougeDone;
    public bool balconyDialougeDone;

    public bool plantOne;
    public bool plantTwo;
    public bool plantThree;
    public bool plantFour;
    public bool plantFive;
    public bool plantSix;
    public bool plantSeven;

    public bool chest1;
    public bool chest2;
    public bool chest3;
    public bool chest4;
    public bool chest5;
    public bool chest6;
    public bool chest7;
    public bool chest8;
    public bool chest9;
    public bool chest10;

    public bool heardLibrarySound;

    public string[] stands;

    public bool godModeActivated;

    private void Awake()
    {
        //This code is used to make sure there are never more than one game manager
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        //The below code is for the timers of the enemy. Once the timer reaches a certtain point, the enemy will be able to respawn
        if(enemyOneFakeDead)
        {
            enemyOneTimer += Time.deltaTime;
        }
        if(enemyTwoFakeDead)
        {
            enemyTwoTimer += Time.deltaTime;
        }
        if(enemyThreeFakeDead)
        {
            enemyThreeTimer += Time.deltaTime;
        }
        if (enemyFourFakeDead)
        {
            enemyFourTimer += Time.deltaTime;
        }
        if (enemyFiveFakeDead)
        {
            enemyFiveTimer += Time.deltaTime;
        }
        if (enemySixFakeDead)
        {
            enemySixTimer += Time.deltaTime;
        }
        if (enemySevenFakeDead)
        {
            enemySevenTimer += Time.deltaTime;
        }
        if (enemyEightFakeDead)
        {
            enemyEightTimer += Time.deltaTime;
        }
        if (enemyNineFakeDead)
        {
            enemyNineTimer += Time.deltaTime;
        }
        if (enemyTenFakeDead)
        {
            enemyTenTimer += Time.deltaTime;
        }
        if (enemyElevenFakeDead)
        {
            enemyElevenTimer += Time.deltaTime;
        }
        if (enemyTwelveFakeDead)
        {
            enemyTwelveTimer += Time.deltaTime;
        }
        if (enemyThirteenFakeDead)
        {
            enemyThirteenTimer += Time.deltaTime;
        }
        if (enemyFourteenFakeDead)
        {
            enemyFourteenTimer += Time.deltaTime;
        }
        if (enemyFifteenFakeDead)
        {
            enemyFifteenTimer += Time.deltaTime;
        }
        if (enemySixteenFakeDead)
        {
            enemySixteenTimer += Time.deltaTime;
        }
    }

    //A way to activate god mode
    public void ActivateGodMode()
    {
        coinOne = true;
        coinTwo = true;
        coinThree = true;

        sword = true;
        clothPile = true;
        book = true;

        firstKey = true;
        hallwayKey = true;
        planetariumKey = true;
        meetingKey = true;
        secondFloorKey = true;
        servantsKey = true;
        tunnelKey = true;

        basementKey = true;
        kingsKeyOne = true;
        kingsKeyTwo = true;

        godModeActivated = true;
    }
}
