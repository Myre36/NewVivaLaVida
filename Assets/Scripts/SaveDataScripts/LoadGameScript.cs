using UnityEngine;
using System.Collections;

public class LoadGameScript : MonoBehaviour
{
    [SerializeField]
    private MenuLoadingData dataLoading;

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

    [SerializeField]
    private Transform loadedPosition;

    [SerializeField]
    private Transform loadedCameraPosition;

    [SerializeField]
    private GameObject playerCamera;

    private void Awake()
    {
        dataLoading = GameObject.Find("MenuLoader").GetComponent<MenuLoadingData>();

        if(dataLoading == null )
        {
            Destroy(gameObject);
        }
        else
        {
            if(dataLoading.isLoadingData)
            {
                PlayerData data = SaveSystem.LoadPlayer();

                player.currentHealth = data.playerHealth;
                gunScript.ammoCount = data.currentAmmo;
                player.healingCharges = data.healingCharges;

                gameManager.firstBullet = data.firstBullet;
                gameManager.firstPlant = data.firstPlant;

                gameManager.enemyOneFakeDead = data.enemyOneFakeDead;
                gameManager.enemyTwoFakeDead = data.enemyTwoFakeDead;
                gameManager.enemyThreeFakeDead = data.enemyThreeFakeDead;
                gameManager.enemyFourFakeDead = data.enemyFourFakeDead;
                gameManager.enemyFiveFakeDead = data.enemyFiveFakeDead;
                gameManager.enemySixFakeDead = data.enemySixFakeDead;
                gameManager.enemySevenFakeDead = data.enemySevenFakeDead;
                gameManager.enemyEightFakeDead = data.enemyEightFakeDead;
                gameManager.enemyNineFakeDead = data.enemyNineFakeDead;
                gameManager.enemyTenFakeDead = data.enemyTenFakeDead;
                gameManager.enemyElevenFakeDead = data.enemyElevenFakeDead;
                gameManager.enemyTwelveFakeDead = data.enemyTwelveFakeDead;
                gameManager.enemyThirteenFakeDead = data.enemyThirteenFakeDead;
                gameManager.enemyFourteenFakeDead = data.enemyFourteenFakeDead;
                gameManager.enemyFifteenFakeDead = data.enemyFifteenFakeDead;
                gameManager.enemySixteenFakeDead = data.enemySixteenFakeDead;
                gameManager.enemySeventeenFakeDead = data.enemySeventeenFakeDead;

                gameManager.enemyOneDead = data.enemyOneDead;
                gameManager.enemyTwoDead = data.enemyTwoDead;
                gameManager.enemyThreeDead = data.enemyThreeDead;
                gameManager.enemyFourDead = data.enemyFourDead;
                gameManager.enemyFiveDead = data.enemyFiveDead;
                gameManager.enemySixDead = data.enemySixDead;
                gameManager.enemySevenDead = data.enemySevenDead;
                gameManager.enemyEightDead = data.enemyEightDead;
                gameManager.enemyNineDead = data.enemyNineDead;
                gameManager.enemyTenDead = data.enemyTenDead;
                gameManager.enemyElevenDead = data.enemyElevenDead;
                gameManager.enemyTwelveDead = data.enemyTwelveDead;
                gameManager.enemyThirteenDead = data.enemyThirteenDead;
                gameManager.enemyFourteenDead = data.enemyFourteenDead;
                gameManager.enemyFifteenDead = data.enemyFifteenDead;
                gameManager.enemySixteenDead = data.enemySixteenDead;
                gameManager.enemySeventeenDead = data.enemySeventeenDead;

                gameManager.enemyOneTimer = data.enemyOneTimer;
                gameManager.enemyTwoTimer = data.enemyTwoTimer;
                gameManager.enemyThreeTimer = data.enemyThreeTimer;
                gameManager.enemyFourTimer = data.enemyFourTimer;
                gameManager.enemyFiveTimer = data.enemyFiveTimer;
                gameManager.enemySixTimer = data.enemySixTimer;
                gameManager.enemySevenTimer = data.enemySevenTimer;
                gameManager.enemyEightTimer = data.enemyEightTimer;
                gameManager.enemyNineTimer = data.enemyNineTimer;
                gameManager.enemyTenTimer = data.enemyTenTimer;
                gameManager.enemyElevenTimer = data.enemyElevenTimer;
                gameManager.enemyTwelveTimer = data.enemyTwelveTimer;
                gameManager.enemyThirteenTimer = data.enemyThirteenTimer;
                gameManager.enemyFourteenTimer = data.enemyFourteenTimer;
                gameManager.enemyFifteenTimer = data.enemyFifteenTimer;
                gameManager.enemySixteenTimer = data.enemySixteenTimer;
                gameManager.enemySeventeenTimer = data.enemySeventeenTimer;

                gameManager.coinOne = data.coinOne;
                gameManager.coinTwo = data.coinTwo;
                gameManager.coinThree = data.coinThree;

                gameManager.sword = data.sword;
                gameManager.clothPile = data.clothPile;
                gameManager.book = data.book;

                gameManager.toiletClogged = data.toiletClogged;
                gameManager.swordPlaced = data.swordPlaced;
                gameManager.bookPlaced = data.bookPlaced;

                gameManager.firstKey = data.firstKey;
                gameManager.hallwayKey = data.hallwayKey;
                gameManager.planetariumKey = data.planetariumKey;
                gameManager.meetingKey = data.meetingKey;
                gameManager.secondFloorKey = data.secondFloorKey;
                gameManager.servantsKey = data.servantsKey;
                gameManager.tunnelKey = data.tunnelKey;

                gameManager.basementKey = data.basementKey;
                gameManager.kingsKeyOne = data.kingsKeyOne;
                gameManager.kingsKeyTwo = data.kingsKeyTwo;

                gameManager.firstUnlocked = data.firstUnlocked;
                gameManager.hallwayUnlocked = data.hallwayUnlocked;
                gameManager.tunnelUnlocked = data.tunnelUnlocked;
                gameManager.servantsUnlocked = data.servantsUnlocked;
                gameManager.basementUnlocked = data.basementUnlocked;
                gameManager.secondFloorUnlocked = data.secondFloorUnlocked;
                gameManager.planetariumUnlocked = data.planetariumUnlocked;
                gameManager.meetingUnlocked = data.meetingUnlocked;
                gameManager.coinUnlocked = data.coinUnlocked;
                gameManager.kingsUnlocked = data.kingsUnlocked;

                gameManager.kitchenUnlocked = data.kitchenUnlocked;
                gameManager.statueRoomUnlocked = data.statueRoomUnlocked;
                gameManager.diningUnlocked = data.diningUnlocked;

                gameManager.planetSolved = data.planetSolved;
                gameManager.combinationSolved = data.combinationSolved;

                gameManager.bullet1 = data.bullet1;
                gameManager.bullet2 = data.bullet2;
                gameManager.bullet3 = data.bullet3;
                gameManager.bullet4 = data.bullet4;
                gameManager.bullet5 = data.bullet5;
                gameManager.bullet6 = data.bullet6;
                gameManager.bullet7 = data.bullet7;
                gameManager.bullet8 = data.bullet8;
                gameManager.bullet9 = data.bullet9;
                gameManager.bullet10 = data.bullet10;
                gameManager.bullet11 = data.bullet11;
                gameManager.bullet12 = data.bullet12;
                gameManager.bullet13 = data.bullet13;
                gameManager.bullet14 = data.bullet14;
                gameManager.bullet15 = data.bullet15;
                gameManager.bullet16 = data.bullet16;

                gameManager.introDialougeDone = data.introDialougeDone;
                gameManager.tutorialDialougeDone = data.tutorialDialougeDone;
                gameManager.afterEnemyDone = data.afterEnemyDone;
                gameManager.livingRoomDialougeDone = data.livingRoomDialougeDone;
                gameManager.eastHallwayDialougeDone = data.eastHallwayDialougeDone;
                gameManager.kitchenDialougeDone = data.kitchenDialougeDone;
                gameManager.afterKitchenDialougeDone = data.afterKitchenDialougeDone;
                gameManager.afterBasementDialougeDone = data.afterBasementDialougeDone;
                gameManager.bothKeysDialougeDone = data.bothKeysDialougeDone;
                gameManager.statueDialougeDone = data.statueDialougeDone;
                gameManager.secondFloorDialougeDone = data.secondFloorDialougeDone;
                gameManager.planetariumDialougeDone = data.planetariumDialougeDone;
                gameManager.libraryDialougeDone = data.libraryDialougeDone;
                gameManager.afterKingBedDialougeDone = data.afterKingBedDialougeDone;
                gameManager.balconyDialougeDone = data.balconyDialougeDone;

                gameManager.plantOne = data.plantOne;
                gameManager.plantTwo = data.plantTwo;
                gameManager.plantThree = data.plantThree;
                gameManager.plantFour = data.plantFour;
                gameManager.plantFive = data.plantFive;
                gameManager.plantSix = data.plantSix;
                gameManager.plantSeven = data.plantSeven;

                gameManager.chest1 = data.chest1;
                gameManager.chest2 = data.chest2;
                gameManager.chest3 = data.chest3;
                gameManager.chest4 = data.chest4;
                gameManager.chest5 = data.chest5;
                gameManager.chest6 = data.chest6;
                gameManager.chest7 = data.chest7;
                gameManager.chest8 = data.chest8;
                gameManager.chest9 = data.chest9;
                gameManager.chest10 = data.chest10;

                gameManager.heardLibrarySound = data.heardLibrarySound;

                gameManager.stands = data.stands;

                gameManager.candleStates = data.candleStates;

                planetPicker.hasSun = data.hasSun;
                planetPicker.hasMercury = data.hasMercury;
                planetPicker.hasVenus = data.hasVenus;
                planetPicker.hasEarth = data.hasEarth;
                planetPicker.hasMars = data.hasMars;
                planetPicker.hasJupiter = data.hasJupiter;
                planetPicker.hasSaturn = data.hasSaturn;
                planetPicker.hasUranus = data.hasUranus;

                mapManager.firstUnlocked = data.firstUnlocked;
                /*mapManager.hallwayUnlocked = data.hallwayUnlocked;
                mapManager.tunnelUnlocked = data.tunnelUnlocked;
                mapManager.servantsUnlocked = data.servantsUnlocked;
                mapManager.basementUnlocked = data.basementUnlocked;
                mapManager.secondFloorUnlocked = data.secondFloorUnlocked;
                mapManager.planetariumUnlocked = data.planetariumUnlocked;
                mapManager.meetingUnlocked = data.meetingUnlocked;
                mapManager.coinUnlocked = data.coinUnlocked;
                mapManager.kingsUnlocked = data.kingsUnlocked;*/
                mapManager.unlocked1_2 = data.unlocked1_2;
                mapManager.unlocked1_3 = data.unlocked1_3;
                mapManager.unlocked1_4 = data.unlocked1_4;
                mapManager.unlocked1_5 = data.unlocked1_5;
                mapManager.unlocked1_6 = data.unlocked1_6;
                mapManager.unlocked1_7 = data.unlocked1_7;
                mapManager.unlocked1_8 = data.unlocked1_8;
                mapManager.unlocked1_9 = data.unlocked1_9;
                mapManager.unlocked1_10 = data.unlocked1_10;
                mapManager.unlocked1_11 = data.unlocked1_11;
                mapManager.unlocked1_12 = data.unlocked1_12;
                mapManager.unlocked1_13 = data.unlocked1_13;
                mapManager.unlocked1_14 = data.unlocked1_14;
                mapManager.unlockedKingsRoom = data.unlockedKingsRoom;
                mapManager.unlocked2_1 = data.unlocked2_1;
                mapManager.unlocked2_2 = data.unlocked2_2;
                mapManager.unlocked2_3 = data.unlocked2_3;
                mapManager.unlocked2_4 = data.unlocked2_4;
                mapManager.unlocked2_5 = data.unlocked2_5;
                mapManager.unlocked2_6 = data.unlocked2_6;
                mapManager.unlocked2_7 = data.unlocked2_7;
                mapManager.unlocked2_8 = data.unlocked2_8;
                mapManager.unlocked2_9 = data.unlocked2_9;
                mapManager.unlocked2_10 = data.unlocked2_10;
                mapManager.unlocked2_12 = data.unlocked2_12;
                mapManager.unlocked2_13 = data.unlocked2_13;
                mapManager.unlocked2_14 = data.unlocked2_14;

                Debug.Log("Before doing map things");

                mapManager.LoadedMap();

                int limit = Mathf.Min(data.inventoryTexts.Length, player.inventoryTexts.Length);

                for(int i = 0; i < limit; i++)
                {
                    player.inventoryTexts[i].text = data.inventoryTexts[i];
                }

                Debug.Log("Starting to move player");

                StartCoroutine(MoveLoadingPlayer());

                Debug.Log("Player should be moved");

                Destroy(dataLoading.gameObject);

                Destroy(gameObject);
            }
            else
            {
                Destroy(dataLoading);
                Destroy(gameObject);
            }
        }
    }

    //A coroutine for moving the player to the correct spot
    IEnumerator MoveLoadingPlayer()
    {
        //Gets a refrence to the rigidbody
        Rigidbody rb = player.gameObject.GetComponent<Rigidbody>();
        //The only way for this to work is for the player's rigidbody to be kinematic. I don't know why, it bugs if it isn't
        rb.isKinematic = true;

        //Sets the player's position and rotation to the entry point
        player.transform.position = loadedPosition.position;

        //Sets the camera position
        playerCamera.transform.position = loadedCameraPosition.position;

        Debug.Log("Starting move");

        //Waits for a bit
        yield return new WaitForSeconds(0.1f);

        //Makes the player not kinematic
        rb.isKinematic = false;

        Debug.Log("Finished move");
    }
}
