using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    private static Movement instance;

    //A refrence to the player Rigidbody
    public Rigidbody rb;

    //A Vector3 which will be used to calculate the direction the player moves
    private Vector3 moveDirection;

    //Input values
    private float verticalInput;
    private float horizontalInput;
    //Movement speeds
    private float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed;
    //The maximum speed that the player can reach
    public float maxSpeed;
    //The speed at which the player rotates
    private int rotationSpeed;

    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;
    //A value which will be used to apply drag to the player, to stop them from sliding across the floor
    public float groundDrag;

    //A refrence to the gun
    public GameObject gun;
    //A refrence to the inventory screen
    public GameObject inventoryScreen;

    //A bool which will be used to check if the player is aiming
    public bool aiming;

    public int inventorySpace;

    public TMP_Text[] inventoryTexts;

    private Camera mainCamera;

    private Vector3 pointToLook;

    public RawImage healthImage;

    public bool inMandatory;

    public MovementState state;

    //This defines the health changed events and handler delagating
    public delegate void HealthChangedHandler(object source, float oldHealth, float newHealth);
    public event HealthChangedHandler OnHealthChanged;

    [SerializeField]
    float currentHealth;
    float maxHealth = 50f;
    float damage = 10f;
    float healing = 10f;

    public float CurrentHealth => currentHealth;

    public void ChangeHealth(float amount)
    {
        float oldHealth = currentHealth;
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        OnHealthChanged?.Invoke(this, oldHealth, currentHealth);

        // Checks if health has reached zero
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("Death scene");
        }
    }

    // This one will be used with items/consumables
    void ApplyHealing()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth = Mathf.Min(currentHealth + healing, maxHealth);
        }
    }

    public void DamageHealth()
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;

            // Checks if health is zero and changes scene
            if (currentHealth <= 0)
            {
                SceneManager.LoadScene("Death scene");
            }
        }
    }

    public enum MovementState
    {
        walking,
        sprinting
    }

    //A refrence to the game manager
    public GameManager gameManager;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Awake()
    {
        // This code is used to make sure there are never more than one player
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        //If the game manager is set to null, the script will find it and assign it
        if (gameManager == null)
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }
        inventorySpace++;

        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "TutorialScene")
        {
            Destroy(this.gameObject);
        }
        if (currentScene.name == "Death scene")
        {
            Destroy(this.gameObject);
        }

        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        //Calling the input function
        MyInput();
        //Calling the state function
        StateHandler();
        //Calling the function that limits the player's movement speed, so the player doesn't accelerate infinetly
        SpeedControl();

        if(grounded)
        {
            rb.linearDamping = groundDrag;
        }
        else
        {
            rb.linearDamping = 0;
        }

        //When the player holds down the RMB, the gun appears and the player starts aiming
        if (Input.GetMouseButton(1) || Input.GetKey(KeyCode.JoystickButton6))
        {
            aiming = true;
            rotationSpeed = 200;
            gun.GetComponent<Renderer>().enabled = true;
        }
        //If the player is not holding down the RMB, the gun is not visible
        else
        {
            aiming = false;
            rotationSpeed = 500;
            gun.GetComponent<Renderer>().enabled = false;
        }
        //Pressing the Tab key either opens the inventory screen, or closes it, depending on what its status is
        if(Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.JoystickButton13) || Input.GetKeyDown(KeyCode.Tab))
        {
            if(inventoryScreen.activeSelf == false)
            {
                inventoryScreen.SetActive(true);
            }
            else
            {
                inventoryScreen.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            DamageHealth();
        }

        float healthFraction = currentHealth / maxHealth;
        if(healthFraction >= 0.67f)
        {
            healthImage.color = Color.green;
        }
        else if(healthFraction < 0.67f &&  healthFraction >= 0.33f)
        {
            healthImage.color = Color.yellow;
        }
        else
        {
            healthImage.color = Color.red;
        }
    }

    private void FixedUpdate()
    {
        //Calling the movement function
        MovePlayer();
    }

    //This is a function that handles what state the player is in, aka how fast they are moving
    private void StateHandler()
    {
        //Holding down left shift means the player is sprinting, meaning they move faster
        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.JoystickButton4))
        {
            state = MovementState.sprinting;
            moveSpeed = sprintSpeed;
        }
        //Otherwise, the player moves at normal speed
        else
        {
            state = MovementState.walking;
            moveSpeed = walkSpeed;
        }
    }

    //A function that takes care of the inputs
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        /*if(aiming)
        {
            //This rotates the player if they hold down the horizontal inputs
            transform.Rotate(0, (horizontalInput * rotationSpeed * Time.deltaTime), 0);
        }*/
}

    //A function that takes care of movement
    private void MovePlayer()
    {
        //moveDirection = (cam.transform.forward * verticalInput) + (cam.transform.right * horizontalInput);

        //Calculate the movement direction
        moveDirection = (Vector3.forward * verticalInput) + (Vector3.right * horizontalInput);

        if (gameManager.usingController)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);

            if (moveDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }
        else
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            if (!aiming)
            {
                if(moveDirection != Vector3.zero)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
                }
            }
            else
            {
                var cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);

                Plane ground = new Plane(Vector3.up, Vector3.zero);

                if(ground.Raycast(cameraRay, out var rayLength))
                {
                    pointToLook = cameraRay.GetPoint(rayLength);
                    //transform.LookAt(pointToLook);
                    Quaternion lookPosition = Quaternion.LookRotation(pointToLook - transform.position);
                    Quaternion tempRotation = Quaternion.RotateTowards(transform.rotation, lookPosition, rotationSpeed * Time.deltaTime);
                    tempRotation.x = 0f;
                    tempRotation.z = 0f;
                    transform.rotation = tempRotation;
                }

                /*if (moveDirection != Vector3.zero)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
                }*/

                /*LayerMask ignore = LayerMask.GetMask("Default", "Ground", "StatuePoints");
                Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
                Plane ground = new Plane(Vector3.forward, Vector3.zero);
                float rayLength;

                if(ground.Raycast(cameraRay, out rayLength))
                {
                    Vector3 pointToLook = cameraRay.GetPoint(rayLength);
                    Debug.DrawLine(cameraRay.origin, pointToLook, Color.yellow);
                    Quaternion lookRotation = Quaternion.LookRotation(pointToLook - transform.position, Vector3.up);
                    Quaternion clampedRotation = new Quaternion(Mathf.Clamp(lookRotation.x, 0f, 0f), lookRotation.y, Mathf.Clamp(lookRotation.z, 0f, 0f), 1);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, clampedRotation, rotationSpeed * Time.deltaTime);
                }*/
            }
        }

        //Player can only move if they are not aiming their gun
        if (!aiming)
        {
            //Moves the player in the calculated direction at an increased movement speed
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
            //transform.rotation = Quaternion.LookRotation(moveDirection.normalized);
        }
    }

    //A function that prvents the player from going too fast
    private void SpeedControl()
    {
        //Calculates the X and Z velocity that the player is moving in
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        //Limit the velocity if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVelocity = flatVel.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitedVelocity.x, rb.linearVelocity.y, limitedVelocity.z);
        }
    }
}
