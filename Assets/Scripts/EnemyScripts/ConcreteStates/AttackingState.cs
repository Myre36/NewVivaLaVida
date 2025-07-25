using System.Threading;
using UnityEngine;

public class AttackingState : EnemyState
    {
    private float timer;

    private float exitTimer;
    private float timeTilExit;

    private Movement movementScript;
    public AttackingState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine) {
       movementScript = enemy.PlayerTransform.GetComponent<Movement>();
    }

    public override void AnimationTriggerEvent() {
        base.AnimationTriggerEvent();
    }

    public override void EnterState() {
        base.EnterState();
        enemy.animator.SetBool("isAttacking", true);
        enemy.animator.SetBool("isIdle", false);
        enemy.animator.SetBool("isRunning", false);
    }

    public override void ExitState() {
        base.ExitState();
    }

    public override void FrameUpdate() {
        base.FrameUpdate();

        enemy.MoveEnemy(enemy.transform.position);

        if (timer > enemy.timeBetweenAttacks) {

            timer = 0f;

            movementScript.ChangeHealth(enemy.DamageDelt);
            Debug.Log(enemy.DamageDelt);


        }

        if (Vector3.Distance(enemy.PlayerTransform.position, enemy.transform.position) > enemy.AttackRange) {
            exitTimer += Time.deltaTime;

            if (exitTimer > timeTilExit) {
                timer = 0f;
                enemy.AttackDistance(false);
                enemyStateMachine.ChangeState(enemy.ChasingState);
            }
        }
        else {
            exitTimer = 0f;
        }

        timer += Time.deltaTime;
    }

    public override void PhysicsUpdate() {
        base.PhysicsUpdate();
    }
}
