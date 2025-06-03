using UnityEngine;

public class Zombie : Enemy
{
    private void Start() {
        base.Start();
        AttackRange = 4f;
        StateMachine.ChangeState(BossIdleState);
    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("KillableEnviorment")) {
            Damage(10f);
        }
    }
}
