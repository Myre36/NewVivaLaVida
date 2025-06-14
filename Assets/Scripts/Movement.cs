using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class Movement : MonoBehaviour
{
    private static Movement instance;

    public Animator animator;

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
    public int rotationSpeed;

    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;
    //A value which will be used to apply drag to the player, to stop them from sliding across the floor
    public float groundDrag;

    //A refrence to the gun
    public GameObject gun;
    //A refrence to the inventory screen
    public GameObject inventoryScreen;
    //Pause screen
    public GameObject pauseScreen;

    //A bool which will be used to check if the player is aiming
    public bool aiming;

    public TMP_Text[] inventoryTexts;

    private Camera mainCamera;

    private Vector3 pointToLook;

    public bool inMandatory;

    private Volume volume;

    private Vignette vignette;

    public Slider brightnessSlide;

    public AudioSource heartbeatSound;

    public AudioSource EstherDeathSound;

    public AudioSource EstherGrunt1Sound;

    public AudioSource EstherGrunt2Sound;

    

    public int healingCharges = 0;

    public TMP_Text healingChargeText;

    public MovementState state;

    //This defines the health changed events and handler delagating
    public delegate void HealthChangedHandler(object source, float oldHealth, float newHealth);
    public event HealthChangedHandler OnHealthChanged;

    [SerializeField]
    float currentHealth;
    float maxHealth = 0f;
    float damage = 0.2f;
    float healing = 0.2f;

    private float InverseValue(float value)
    {
        return (1f - value);
    }

    public float CurrentHealth => currentHealth;

    public void ChangeHealth(float amount)
    {
        if(!gameManager.godModeActivated)
        {
            float oldHealth = currentHealth;
            currentHealth += amount;
            Debug.Log(amount);
            currentHealth = Mathf.Clamp(currentHealth, maxHealth, 1);
            OnHealthChanged?.Invoke(this, oldHealth, currentHealth);

            EstherGrunt1Sound.Play();


            // Checks if health has reached zero
            if (currentHealth >= 1)
            {
                SceneManager.LoadScene("Death scene");
            }

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
        if(!gameManager.godModeActivated)
        {
            if (currentHealth < 1)
            {
                currentHealth += damage;

                EstherGrunt1Sound.Play();

                // Checks if health is zero and changes scene
                if (currentHealth >= 1)
                {
                    SceneManager.LoadScene("Death scene");
                }
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

        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
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
        if (Input.GetMouseButton(1))
        {
            aiming = true;

            animator.SetBool("Aiming", true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            //gun.GetComponent<Renderer>().enabled = true;
        }
        //If the player is not holding down the RMB, the gun is not visible
        else
        {
            aiming = false;
            animator.SetBool("Aiming", false);

            //gun.GetComponent<Renderer>().enabled = false;
        }
        if(Input.GetMouseButtonUp(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        //Pressing the Tab key either opens the inventory screen, or closes it, depending on what its status is
        if(Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Tab))
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

        if(Input.GetKeyDown(KeyCode.F) && healingCharges > 0 && currentHealth != 0)
        {
            if (currentHealth < 0.2f)
            {
                currentHealth = 0;
            }
            else
            {
                currentHealth -= 0.2f;
            }

            healingCharges--;
        }
        /*
        if(Input.GetKeyDown(KeyCode.P))
        {
            gameManager.ActivateGodMode();
            gun.GetComponent<GunScript>().ammoCount = 1000;
        }

        if(Input.GetKey(KeyCode.C))
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
            animator.SetBool("Aiming", true);
        }
        */
        if (volume == null)
        {
            volume = GameObject.Find("Global Volume").GetComponent<Volume>();
            volume.profile.TryGet<Vignette>(out vignette);
        }

        vignette.intensity.value = currentHealth;

        if (currentHealth >= 0.6f)
        {
            heartbeatSound.mute = false;
        }
        else
        {
            heartbeatSound.mute = true;
        }

        healingChargeText.text = " " + healingCharges;

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale == 0)
            {
                pauseScreen.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1;
            }
            else
            {
                pauseScreen.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
            }
        }

        volume.weight = InverseValue(brightnessSlide.value);
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
        if(Input.GetKey(KeyCode.LeftShift))
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

        Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
        if (!aiming)
        {
            if (moveDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

                if (state == MovementState.sprinting)
                {
                    animator.SetBool("isWalking", false);
                    animator.SetBool("isRunning", true);
                }
                else
                {
                    animator.SetBool("isRunning", false);
                    animator.SetBool("isWalking", true);
                }
            }
            else
            {
                animator.SetBool("isRunning", false);
                animator.SetBool("isWalking", false);
            }

            //Moves the player in the calculated direction at an increased movement speed
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
            //transform.rotation = Quaternion.LookRotation(moveDirection.normalized);
        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
            animator.SetBool("Aiming", true);

            var cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);

            Plane ground = new Plane(Vector3.up, Vector3.zero);

            if (ground.Raycast(cameraRay, out var rayLength))
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

    public void ExecuteEnd()
    {
        StartCoroutine(EndGame());
    }

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Ending");
    }












}
