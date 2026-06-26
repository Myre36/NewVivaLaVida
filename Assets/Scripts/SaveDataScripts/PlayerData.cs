using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float playerHealth;
    public int currentAmmo;
    public int healingCharges;

    public bool firstBullet;
    public bool firstPlant;

    //Bools for if all the enemies are dead
    public bool enemyOneFakeDead;
    public bool enemyTwoFakeDead;
    public bool enemyThreeFakeDead;
    public bool enemyFourFakeDead;
    public bool enemyFiveFakeDead;
    public bool enemySixFakeDead;
    public bool enemySevenFakeDead;
    public bool enemyEightFakeDead;
    public bool enemyNineFakeDead;
    public bool enemyTenFakeDead;
    public bool enemyElevenFakeDead;
    public bool enemyTwelveFakeDead;
    public bool enemyThirteenFakeDead;
    public bool enemyFourteenFakeDead;
    public bool enemyFifteenFakeDead;
    public bool enemySixteenFakeDead;
    public bool enemySeventeenFakeDead;

    public bool enemyOneDead;
    public bool enemyTwoDead;
    public bool enemyThreeDead;
    public bool enemyFourDead;
    public bool enemyFiveDead;
    public bool enemySixDead;
    public bool enemySevenDead;
    public bool enemyEightDead;
    public bool enemyNineDead;
    public bool enemyTenDead;
    public bool enemyElevenDead;
    public bool enemyTwelveDead;
    public bool enemyThirteenDead;
    public bool enemyFourteenDead;
    public bool enemyFifteenDead;
    public bool enemySixteenDead;
    public bool enemySeventeenDead;

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
    public float enemySeventeenTimer;

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

    public bool[] candleStates;

    public PlayerData (Movement movement, GunScript gunScript, GameManager gameManager)
    {
        playerHealth = movement.CurrentHealth;
        currentAmmo = gunScript.ammoCount;
        healingCharges = movement.healingCharges;

        firstBullet = gameManager.firstBullet;
        firstPlant = gameManager.firstPlant;

        enemyOneFakeDead = gameManager.enemyOneFakeDead;
        enemyTwoFakeDead = gameManager.enemyTwoFakeDead;
        enemyThreeFakeDead = gameManager.enemyThreeFakeDead;
        enemyFourFakeDead = gameManager.enemyFourFakeDead;
        enemyFiveFakeDead = gameManager.enemyFiveFakeDead;
        enemySixFakeDead = gameManager.enemySixFakeDead;
        enemySevenFakeDead = gameManager.enemySevenFakeDead;
        enemyEightFakeDead = gameManager.enemyEightFakeDead;
        enemyNineFakeDead = gameManager.enemyNineFakeDead;
        enemyTenFakeDead = gameManager.enemyTenFakeDead;
        enemyElevenFakeDead = gameManager.enemyElevenFakeDead;
        enemyTwelveFakeDead = gameManager.enemyTwelveFakeDead;
        enemyThirteenFakeDead = gameManager.enemyThirteenFakeDead;
        enemyFourteenFakeDead = gameManager.enemyFourteenFakeDead;
        enemyFifteenFakeDead = gameManager.enemyFifteenFakeDead;
        enemySixteenFakeDead = gameManager.enemySixteenFakeDead;
        enemySeventeenFakeDead = gameManager.enemySeventeenFakeDead;

        enemyOneDead = gameManager.enemyOneDead;
        enemyTwoDead = gameManager.enemyTwoDead;
        enemyThreeDead = gameManager.enemyThreeDead;
        enemyFourDead = gameManager.enemyFourDead;
        enemyFiveDead = gameManager.enemyFiveDead;
        enemySixDead = gameManager.enemySixDead;
        enemySevenDead = gameManager.enemySevenDead;
        enemyEightDead = gameManager.enemyEightDead;
        enemyNineDead = gameManager.enemyNineDead;
        enemyTenDead = gameManager.enemyTenDead;
        enemyElevenDead = gameManager.enemyElevenDead;
        enemyTwelveDead = gameManager.enemyTwelveDead;
        enemyThirteenDead = gameManager.enemyThirteenDead;
        enemyFourteenDead = gameManager.enemyFourteenDead;
        enemyFifteenDead = gameManager.enemyFifteenDead;
        enemySixteenDead = gameManager.enemySixteenDead;
        enemySeventeenDead = gameManager.enemySeventeenDead;

        enemyOneTimer = gameManager.enemyOneTimer;
        enemyTwoTimer = gameManager.enemyTwoTimer;
        enemyThreeTimer = gameManager.enemyThreeTimer;
        enemyFourTimer = gameManager.enemyFourTimer;
        enemyFiveTimer = gameManager.enemyFiveTimer;
        enemySixTimer = gameManager.enemySixTimer;
        enemySevenTimer = gameManager.enemySevenTimer;
        enemyEightTimer = gameManager.enemyEightTimer;
        enemyNineTimer = gameManager.enemyNineTimer;
        enemyTenTimer = gameManager.enemyTenTimer;
        enemyElevenTimer = gameManager.enemyElevenTimer;
        enemyTwelveTimer = gameManager.enemyTwelveTimer;
        enemyThirteenTimer = gameManager.enemyThirteenTimer;
        enemyFourteenTimer = gameManager.enemyFourteenTimer;
        enemyFifteenTimer = gameManager.enemyFifteenTimer;
        enemySixteenTimer = gameManager.enemySixteenTimer;
        enemySeventeenTimer = gameManager.enemySeventeenTimer;

        coinOne = gameManager.coinOne;
        coinTwo = gameManager.coinTwo;
        coinThree = gameManager.coinThree;

        sword = gameManager.sword;
        clothPile = gameManager.clothPile;
        book = gameManager.book;

        toiletClogged = gameManager.toiletClogged;
        swordPlaced = gameManager.swordPlaced;
        bookPlaced = gameManager.bookPlaced;

        firstKey = gameManager.firstKey;
        hallwayKey = gameManager.hallwayKey;
        planetariumKey = gameManager.planetariumKey;
        meetingKey = gameManager.meetingKey;
        secondFloorKey = gameManager.secondFloorKey;
        servantsKey = gameManager.servantsKey;
        tunnelKey = gameManager.tunnelKey;

        basementKey = gameManager.basementKey;
        kingsKeyOne = gameManager.kingsKeyOne;
        kingsKeyTwo = gameManager.kingsKeyTwo;

        firstUnlocked = gameManager.firstUnlocked;
        hallwayUnlocked = gameManager.hallwayUnlocked;
        tunnelUnlocked = gameManager.tunnelUnlocked;
        servantsUnlocked = gameManager.servantsUnlocked;
        basementUnlocked = gameManager.basementUnlocked;
        secondFloorUnlocked = gameManager.secondFloorUnlocked;
        planetariumUnlocked = gameManager.planetariumUnlocked;
        meetingUnlocked = gameManager.meetingUnlocked;
        coinUnlocked = gameManager.coinUnlocked;
        kingsUnlocked = gameManager.kingsUnlocked;

        kitchenUnlocked = gameManager.kitchenUnlocked;
        statueRoomUnlocked = gameManager.statueRoomUnlocked;
        diningUnlocked = gameManager.diningUnlocked;

        planetSolved = gameManager.planetSolved;
        combinationSolved = gameManager.combinationSolved;

        bullet1 = gameManager.bullet1;
        bullet2 = gameManager.bullet2;
        bullet3 = gameManager.bullet3;
        bullet4 = gameManager.bullet4;
        bullet5 = gameManager.bullet5;
        bullet6 = gameManager.bullet6;
        bullet7 = gameManager.bullet7;
        bullet8 = gameManager.bullet8;
        bullet9 = gameManager.bullet9;
        bullet10 = gameManager.bullet10;
        bullet11 = gameManager.bullet11;
        bullet12 = gameManager.bullet12;
        bullet13 = gameManager.bullet13;
        bullet14 = gameManager.bullet14;
        bullet15 = gameManager.bullet15;
        bullet16 = gameManager.bullet16;

        introDialougeDone = gameManager.introDialougeDone;
        tutorialDialougeDone = gameManager.tutorialDialougeDone;
        afterEnemyDone = gameManager.afterEnemyDone;
        livingRoomDialougeDone = gameManager.livingRoomDialougeDone;
        eastHallwayDialougeDone = gameManager.eastHallwayDialougeDone;
        kitchenDialougeDone = gameManager.kitchenDialougeDone;
        afterKitchenDialougeDone = gameManager.afterKitchenDialougeDone;
        afterBasementDialougeDone = gameManager.afterBasementDialougeDone;
        bothKeysDialougeDone = gameManager.bothKeysDialougeDone;
        statueDialougeDone = gameManager.statueDialougeDone;
        secondFloorDialougeDone = gameManager.secondFloorDialougeDone;
        planetariumDialougeDone = gameManager.planetariumDialougeDone;
        libraryDialougeDone = gameManager.libraryDialougeDone;
        afterKingBedDialougeDone = gameManager.afterKingBedDialougeDone;
        balconyDialougeDone = gameManager.balconyDialougeDone;

        plantOne = gameManager.plantOne;
        plantTwo = gameManager.plantTwo;
        plantThree = gameManager.plantThree;
        plantFour = gameManager.plantFour;
        plantFive = gameManager.plantFive;
        plantSix = gameManager.plantSix;
        plantSeven = gameManager.plantSeven;

        chest1 = gameManager.chest1;
        chest2 = gameManager.chest2;
        chest3 = gameManager.chest3;
        chest4 = gameManager.chest4;
        chest5 = gameManager.chest5;
        chest6 = gameManager.chest6;
        chest7 = gameManager.chest7;
        chest8 = gameManager.chest8;
        chest9 = gameManager.chest9;
        chest10 = gameManager.chest10;

        heardLibrarySound = gameManager.heardLibrarySound;

        stands = gameManager.stands;

        candleStates = gameManager.candleStates;
    }
}
