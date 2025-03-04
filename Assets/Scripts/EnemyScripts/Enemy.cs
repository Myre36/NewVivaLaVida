using System;
using UnityEditor.MemoryProfiler;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamagable, IDistanceFinder
{
    public NavMeshAgent agent;

    public Transform PlayerTransform;

    protected GameManager gameManager;

    public int enemyNum;

    public float AttackRange;

    public float DetectionDistance = 50f;

    #region Health Variables
    public Action OnDamage { get; set; } = delegate { };

    public float MaxHealth { get; set; } = 100f;
    public float DamageDelt { get; set; } = -20f;
    public float currentHealth { get ; set; }

    #endregion

    #region StateMachine Variables

    public EnemyStateMachine StateMachine { get; set; }
    public IdleState IdleState { get; set; }
    public AttackingState AttackingState { get; set; }
    public ChasingState ChasingState { get; set; }
    public bool isAggroed { get; set; }
    public bool isWithinAttackDistance { get; set; }

    private void Awake() {
        agent = GetComponent<NavMeshAgent>();
        PlayerTransform = GameObject.Find("Player").GetComponent<Transform>();
        StateMachine = new EnemyStateMachine();

        IdleState = new IdleState(this, StateMachine);
        AttackingState = new AttackingState(this, StateMachine);
        ChasingState = new ChasingState(this, StateMachine);
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
            if (enemyNum == 0) {
                Die();
            } else {
                KillEnemy();
            }
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
            gameManager.GetComponent<GameManager>().enemyOneDead = true;
        }
        else if (enemyNum == 2)
        {
            gameManager.GetComponent<GameManager>().enemyTwoDead = true;
        }
        else if (enemyNum == 3)
        {
            gameManager.GetComponent<GameManager>().enemyThreeDead = true;
        }
        else if (enemyNum == 4)
        {
            gameManager.GetComponent<GameManager>().enemyFourDead = true;
        }
        else if (enemyNum == 5)
        {
            gameManager.GetComponent<GameManager>().enemyFiveDead = true;
        }
        else if (enemyNum == 6)
        {
            gameManager.GetComponent<GameManager>().enemySixDead = true;
        }
        else if (enemyNum == 7)
        {
            gameManager.GetComponent<GameManager>().enemySevenDead = true;
        }
        else if (enemyNum == 8)
        {
            gameManager.GetComponent<GameManager>().enemyEightDead = true;
        }
        else if (enemyNum == 9)
        {
            gameManager.GetComponent<GameManager>().enemyNineDead = true;
        }
        else if (enemyNum == 10)
        {
            gameManager.GetComponent<GameManager>().enemyTenDead = true;
        }
        else if (enemyNum == 11)
        {
            gameManager.GetComponent<GameManager>().enemyElevenDead = true;
        }
        else if (enemyNum == 12)
        {
            gameManager.GetComponent<GameManager>().enemyTwelveDead = true;
        }
        else if (enemyNum == 13)
        {
            gameManager.GetComponent<GameManager>().enemyThirteenDead = true;
        }
        else if (enemyNum == 14)
        {
            gameManager.GetComponent<GameManager>().enemyFourteenDead = true;
        }
        Destroy(gameObject);
    }

    #endregion
}
