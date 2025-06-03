using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamagable, IDistanceFinder
{
    public GameObject aliveBody;
    public GameObject deadBody;
    private AudioSource enemySound;
    private Collider enemyCollider;
    public Animator animator;

    public NavMeshAgent agent;

    public Transform PlayerTransform;

    protected GameManager gameManager;

    public int enemyNum;

    public float AttackRange;

    public float DetectionDistance = 50f;

    #region Health Variables
    public Action OnDamage { get; set; } = delegate { };

    public float MaxHealth { get; set; } = 100f;
    public float DamageDelt { get; set; } = 0.2f;
    public float currentHealth { get ; set; }

    #endregion

    #region StateMachine Variables

    public EnemyStateMachine StateMachine { get; set; }
    public IdleState IdleState { get; set; } 
    public AttackingState AttackingState { get; set; }
    public ChasingState ChasingState { get; set; }
    public BossIdleState BossIdleState { get; set; }
    public bool isAggroed { get; set; }
    public bool isWithinAttackDistance { get; set; }

    private void Awake() {
        agent = GetComponent<NavMeshAgent>();
        PlayerTransform = GameObject.Find("Player").GetComponent<Transform>();
        StateMachine = new EnemyStateMachine();

        IdleState = new IdleState(this, StateMachine);
        AttackingState = new AttackingState(this, StateMachine);
        ChasingState = new ChasingState(this, StateMachine);
        enemySound = GetComponent<AudioSource>();
        enemyCollider = GetComponent<Collider>();

        BossIdleState = new BossIdleState(this, StateMachine);
    }

    #endregion

    #region Idle Variables

    public float RandomMoveRange = 5f;

    #endregion

    public virtual void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        currentHealth = MaxHealth;

        StateMachine.Initialize(IdleState);
    }

    private void Update() {
        StateMachine.CurrentEnemyState.FrameUpdate();    
    }

    private void FixedUpdate() {
        StateMachine?.CurrentEnemyState.PhysicsUpdate();
    }



    #region HealthControll

    public void Damage(float DamageAmount) {
        currentHealth -= DamageAmount;
        OnDamage?.Invoke();
        if (currentHealth <= 0 ) {
            KillEnemy();
        }
    }

    public void Die() {
        Destroy(gameObject);
    }

    
    #endregion

    #region StatusController

    public void SetAggroStatus(bool IsAggroed) {
        isAggroed = isAggroed;
    }

    public void AttackDistance(bool isWithingAttackDistance) {
       isWithinAttackDistance = isWithingAttackDistance;
    }

    #endregion

    #region Movement

    public void MoveEnemy(Vector3 Velocity) {
        agent.SetDestination(Velocity);
    }

    #endregion

    #region DeathController

    public void KillEnemy()
    {
        if (enemyNum == 1)
        {
            if(gameManager.enemyOneFakeDead)
            {
                gameManager.enemyOneDead = true;
                gameManager.enemyOneFakeDead = false;
            }
            else
            {
                gameManager.enemyOneFakeDead = true;
            }
        }
        else if (enemyNum == 2)
        {
            if (gameManager.enemyTwoFakeDead)
            {
                gameManager.enemyTwoDead = true;
                gameManager.enemyTwoFakeDead = false;
            }
            else
            {
                gameManager.enemyTwoFakeDead = true;
            }
        }
        else if (enemyNum == 3)
        {
            if (gameManager.enemyThreeFakeDead)
            {
                gameManager.enemyThreeDead = true;
                gameManager.enemyThreeFakeDead = false;
            }
            else
            {
                gameManager.enemyThreeFakeDead = true;
            }
        }
        else if (enemyNum == 4)
        {
            if (gameManager.enemyFourFakeDead)
            {
                gameManager.enemyFourDead = true;
                gameManager.enemyFourFakeDead = false;
            }
            else
            {
                gameManager.enemyFourFakeDead = true;
            }
        }
        else if (enemyNum == 5)
        {
            if (gameManager.enemyFiveFakeDead)
            {
                gameManager.enemyFiveDead = true;
                gameManager.enemyFiveFakeDead = false;
            }
            else
            {
                gameManager.enemyFiveFakeDead = true;
            }
        }
        else if (enemyNum == 6)
        {
            if (gameManager.enemySixFakeDead)
            {
                gameManager.enemySixDead = true;
                gameManager.enemySixFakeDead = false;
            }
            else
            {
                gameManager.enemySixFakeDead = true;
            }
        }
        else if (enemyNum == 7)
        {
            if (gameManager.enemySevenFakeDead)
            {
                gameManager.enemySevenDead = true;
                gameManager.enemySevenFakeDead = false;
            }
            else
            {
                gameManager.enemySevenFakeDead = true;
            }
        }
        else if (enemyNum == 8)
        {
            if (gameManager.enemyEightFakeDead)
            {
                gameManager.enemyEightDead = true;
                gameManager.enemyEightFakeDead = false;
            }
            else
            {
                gameManager.enemyEightFakeDead = true;
            }
        }
        else if (enemyNum == 9)
        {
            if (gameManager.enemyNineFakeDead)
            {
                gameManager.enemyNineDead = true;
                gameManager.enemyNineFakeDead = false;
            }
            else
            {
                gameManager.enemyNineFakeDead = true;
            }
        }
        else if (enemyNum == 10)
        {
            if (gameManager.enemyTenFakeDead)
            {
                gameManager.enemyTenDead = true;
                gameManager.enemyTenFakeDead = false;
            }
            else
            {
                gameManager.enemyTenFakeDead = true;
            }
        }
        else if (enemyNum == 11)
        {
            if (gameManager.enemyElevenFakeDead)
            {
                gameManager.enemyElevenDead = true;
                gameManager.enemyElevenFakeDead = false;
            }
            else
            {
                gameManager.enemyElevenFakeDead = true;
            }
        }
        else if (enemyNum == 12)
        {
            if (gameManager.enemyTwelveFakeDead)
            {
                gameManager.enemyTwelveDead = true;
                gameManager.enemyTwelveFakeDead = false;
            }
            else
            {
                gameManager.enemyTwelveFakeDead = true;
            }
        }
        else if (enemyNum == 13)
        {
            if (gameManager.enemyThirteenFakeDead)
            {
                gameManager.enemyThirteenDead = true;
                gameManager.enemyThirteenFakeDead = false;
            }
            else
            {
                gameManager.enemyThirteenFakeDead = true;
            }
        }
        else if (enemyNum == 14)
        {
            if (gameManager.enemyFourteenFakeDead)
            {
                gameManager.enemyFourteenDead = true;
                gameManager.enemyFourteenFakeDead = false;
            }
            else
            {
                gameManager.enemyFourteenFakeDead = true;
            }
        }
        else if (enemyNum == 15)
        {
            if (gameManager.enemyFifteenFakeDead)
            {
                gameManager.enemyFifteenDead = true;
                gameManager.enemyFifteenFakeDead = false;
            }
            else
            {
                gameManager.enemyFifteenFakeDead = true;
            }
        }
        else if (enemyNum == 16)
        {
            if (gameManager.enemySixteenFakeDead)
            {
                gameManager.enemySixteenDead = true;
                gameManager.enemySixteenFakeDead = false;
            }
            else
            {
                gameManager.enemySixteenFakeDead = true;
            }
        }
        else if (enemyNum == 17)
        {
            if (gameManager.enemySeventeenFakeDead)
            {
                gameManager.enemySeventeenDead = true;
                gameManager.enemySeventeenFakeDead = false;
            }
            else
            {
                gameManager.enemySeventeenFakeDead = true;
            }
        }
        DisableEverything();
    }

    public void DisableEverything()
    {
        aliveBody.SetActive(false);
        deadBody.SetActive(true);
        enemySound.enabled = false;
        agent.enabled = false;
        enemyCollider.enabled = false;
        this.enabled = false;
    }

    #endregion
}
