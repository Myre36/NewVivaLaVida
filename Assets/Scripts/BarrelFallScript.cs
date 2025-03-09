using UnityEngine;

public class BarrelFallScript : MonoBehaviour
{
    //An array of all the barrles
    public GameObject[] barrels;

    //If its hit by a bullet, the barrles will all roll down
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            //Goes through all the barrels and turns on their gravity
            for(int i = 0;  i < barrels.Length; i++)
            {
                barrels[i].gameObject.GetComponent<Rigidbody>().useGravity = true;
            }
            Destroy(this.gameObject);
        }
    }
}
