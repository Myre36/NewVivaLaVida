using UnityEngine;

public class BossIdleState : EnemyState
{
    private Vector3 _direction;
    private float fieldOfView = 90f;

    public BossIdleState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }

    public override void AnimationTriggerEvent()
    {
        base.AnimationTriggerEvent();
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.animator.SetBool("isIdle", true);
        enemy.animator.SetBool("isRunning", false);
        enemy.animator.SetBool("isAttacking", false);
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        var direction = enemy.PlayerTransform.transform.position - enemy.transform.position;
        var angleToPlayer = Vector3.Angle(enemy.transform.forward, direction);

        if (((enemy.PlayerTransform.position - enemy.transform.position).magnitude < enemy.DetectionDistance && angleToPlayer < fieldOfView / 2)
                || (enemy.PlayerTransform.position - enemy.transform.position).magnitude < 8f)
        {
            enemyStateMachine.ChangeState(enemy.ChasingState);
        }
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
