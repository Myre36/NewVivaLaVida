using UnityEngine;
using System.Collections;

public class GunScript : MonoBehaviour
{
    //Refrence to the bullet prefab
    public GameObject bullet;

    //Refrence to the player
    public GameObject player;

    //The speed at which the bullet fires
    public float shootForce;

    //Bools for shooting
    private bool shooting;
    public bool readyToShoot;

    //Refrence to the bullet spawn point
    public Transform bulletSpawn;
    //Refrence to the point that the bullet fires towards
    public Transform shootPoint;

    private bool canShoot;

    public float reloadTime;

    private void Awake()
    {
        //Make sure that the player is able to shoot
        readyToShoot = true;
        canShoot = true;
    }

    private void Update()
    {
        //Calling the input method
        MyInput();
    }

    //A method for shooting. If the player has ammo, presses the LMB, and they are currently aiming, the Shoot method is called
    private void MyInput()
    {
        shooting = Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.JoystickButton7);

        if (readyToShoot == true && shooting == true && player.GetComponent<Movement>().aiming == true && canShoot == true)
        {
            Shoot();
        }

        if(Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            StartCoroutine(ReloadGun());
        }
    }

    //A method that handles shooting
    private void Shoot()
    {
        canShoot = false;

        //Calculate direction the bullet flies towards
        Vector3 direction = shootPoint.position - bulletSpawn.position;

        //Instantiate bullet
        GameObject currentBullet = Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
        //Rotate bullet to shoot direction
        currentBullet.transform.forward = direction.normalized;

        //Add forces to bullet
        currentBullet.GetComponent<Rigidbody>().AddForce(direction.normalized * shootForce, ForceMode.Impulse);
    }

    IEnumerator ReloadGun()
    {
        yield return new WaitForSeconds(reloadTime);
        canShoot = true;
    }
}
