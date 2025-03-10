using UnityEngine;

public class SmallZombie : Enemy
{
    
    private void Start() {
        base.Start();
        MaxHealth = 10;
        DamageDelt = -10;
        AttackRange = 1.5f;
        DetectionDistance = 15f;
    }

    private void OnCollisionEnter(Collision collision) {
         if (collision.collider.CompareTag("KillableEnviorment")) {
            KillEnemy();
         }
    }
}
