using UnityEngine;

public class ChasingState : EnemyState
{
    
    public ChasingState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine) {
        
    }

    public override void AnimationTriggerEvent() {
        base.AnimationTriggerEvent();
    }

    public override void EnterState() {
        base.EnterState();
        enemy.animator.SetBool("isRunning", true);
        enemy.animator.SetBool("isAttacking", false);
        enemy.animator.SetBool("isIdle", false);
    }

    public override void ExitState() {
        base.ExitState();
    }

    public override void FrameUpdate() {
        base.FrameUpdate();
        enemy.MoveEnemy(enemy.PlayerTransform.position);
        
        if ((enemy.PlayerTransform.position - enemy.transform.position).magnitude < enemy.AttackRange) {
            enemy.AttackDistance(true);
        }
        if (enemy.isWithinAttackDistance) {
            enemyStateMachine.ChangeState(enemy.AttackingState);
        }
    }

    public override void PhysicsUpdate() {
        base.PhysicsUpdate();
    }
}
