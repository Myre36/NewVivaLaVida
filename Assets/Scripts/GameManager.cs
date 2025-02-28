using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //This is something used to make sure there is never more than one game manager
    private static GameManager instance;

    //Object refrences
    public GameObject player;
    public GameObject canvas;
    public GameObject playerCamera;

    //The number used to spawn the player in the correct location when entering a room
    public int entryNumber;

    //Objects in the rooms
    public Vector3 objectOnePosition;
    public Vector3 objectTwoPosition;

    //Enemies in the room
    public bool enemyOneDead = false;
    public bool enemyTwoDead = false;
    public bool enemyThreeDead = false;

    public bool coinOne;
    public bool coinTwo;
    public bool coinThree;

    public bool sword;
    public bool clothPile;
    public bool book;

    public bool toiletClogged;
    public bool swordPlaced;
    public bool bookPlaced;

    public bool hallwayKey;
    public bool planetariumKey;
    public bool meetingKey;
    public bool secondFloorKey;
    public bool servantsKey;
    public bool tunnelKey;

    public bool basementKey;
    public bool kingsKeyOne;
    public bool kingsKeyTwo;

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

    public bool planetSolved;
    public bool combinationSolved;

    public enum InputMode
    {
        Keyboard, Controller
    }
    public InputMode currentInputMode;

    private void Awake()
    {
        currentInputMode = InputMode.Keyboard;

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
        currentInputMode = ProcessInputMode();

        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "TutorialScene")
        {
            Destroy(this.gameObject);
        }
        if (currentScene.name == "Death scene")
        {
            Destroy(this.gameObject);
        }
    }

    private InputMode ProcessInputMode()
    {
        if(Input.GetJoystickNames().Length == 0)
        {
            //If there are no controllers plugged in, it automatically sets it to keyboard
            return InputMode.Keyboard;
        }

        if(Input.anyKeyDown)
        {
            if(Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                return InputMode.Controller;
            }
            else if (Input.GetKeyDown(KeyCode.JoystickButton1))
            {
                return InputMode.Controller;
            }
            else if (Input.GetKeyDown(KeyCode.JoystickButton2))
            {
                return InputMode.Controller;
            }
            else if (Input.GetKeyDown(KeyCode.JoystickButton3))
            {
                return InputMode.Controller;
            }
            else if (Input.GetKey(KeyCode.JoystickButton4))
            {
                return InputMode.Controller;
            }
            else if (Input.GetKey(KeyCode.JoystickButton5))
            {
                return InputMode.Controller;
            }
            else if (Input.GetKey(KeyCode.JoystickButton6))
            {
                return InputMode.Controller;
            }
            else if (Input.GetKey(KeyCode.JoystickButton7))
            {
                return InputMode.Controller;
            }
            else if (Input.GetKeyDown(KeyCode.JoystickButton8))
            {
                return InputMode.Controller;
            }
            else if (Input.GetKeyDown(KeyCode.JoystickButton9))
            {
                return InputMode.Controller;
            }
            else if (Input.GetKeyDown(KeyCode.JoystickButton10))
            {
                return InputMode.Controller;
            }
            else if (Input.GetKeyDown(KeyCode.JoystickButton11))
            {
                return InputMode.Controller;
            }
            else if (Input.GetKeyDown(KeyCode.JoystickButton12))
            {
                return InputMode.Controller;
            }
            else if (Input.GetKeyDown(KeyCode.JoystickButton13))
            {
                return InputMode.Controller;
            }
            else if (Input.GetKeyDown(KeyCode.JoystickButton14))
            {
                return InputMode.Controller;
            }
            else if (Input.GetKeyDown(KeyCode.JoystickButton15))
            {
                return InputMode.Controller;
            }
            else if (Input.GetKeyDown(KeyCode.JoystickButton16))
            {
                return InputMode.Controller;
            }
            else if (Input.GetKeyDown(KeyCode.JoystickButton17))
            {
                return InputMode.Controller;
            }
            else if (Input.GetKeyDown(KeyCode.JoystickButton18))
            {
                return InputMode.Controller;
            }
            else if (Input.GetKeyDown(KeyCode.JoystickButton19))
            {
                return InputMode.Controller;
            }
            else
            {
                return InputMode.Keyboard;
            }
        }

        if(Input.anyKey)
        {
            //Unity will only recognise Input.anyKey for keyboard presses
            if(Input.GetAxisRaw("Horizontal") != 0)
            {
                return InputMode.Keyboard;
            }
            if (Input.GetAxisRaw("Vertical") != 0)
            {
                return InputMode.Keyboard;
            }
        }

        //If the horizontals are not keyboard keys, it will return the controller
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            return InputMode.Controller;
        }
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            return InputMode.Controller;
        }

        if (Input.GetAxisRaw("Horizontal2") != 0)
        {
            return InputMode.Controller;
        }
        if (Input.GetAxisRaw("Vertical2") != 0)
        {
            return InputMode.Controller;
        }

        if (Input.GetAxisRaw("HorizontalD") != 0)
        {
            return InputMode.Controller;
        }
        if (Input.GetAxisRaw("VerticalD") != 0)
        {
            return InputMode.Controller;
        }

        return currentInputMode; 
    }
}
