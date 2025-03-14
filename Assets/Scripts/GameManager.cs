using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //This is something used to make sure there is never more than one game manager
    private static GameManager instance;

    //The number used to spawn the player in the correct location when entering a room
    public int entryNumber;

    //Bools for if all the enemies are dead
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

    public bool usingController;

    public bool introDialougeDone;

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
        //The below code is to make sure that the game manager destroys itself if it enters certain scenes
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "Tutorial Scene")
        {
            Destroy(gameObject);
        }

        if (currentScene.name == "Death scene")
        {
            Destroy(gameObject);
        }
    }
}
