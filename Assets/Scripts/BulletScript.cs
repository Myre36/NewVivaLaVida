using UnityEngine;

public class BulletScript : MonoBehaviour
{
    //If the bullet hits something, it will be destroyed. Other things can happen depending on what you hit
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<SmallZombie>().KillEnemy();
        }
        Destroy(gameObject);
    }
}
