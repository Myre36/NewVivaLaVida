using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private int damage = 10;

    //If the bullet hits something, it will be destroyed. Other things can happen depending on what you hit
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<SmallZombie>().KillEnemy();
        }
        else if(collision.gameObject.CompareTag("Boss"))
        {
            collision.gameObject.GetComponent<Zombie>().Damage(damage);
            Debug.Log("Did damage to boss");
        }
        Destroy(gameObject);
    }
}
