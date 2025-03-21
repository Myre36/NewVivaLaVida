using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

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
    private bool reloading;

    public float reloadTime;

    public int ammoCount;
    private bool ammoInChamber;

    public TMP_Text ammoText;
    public TMP_Text reloadingText;

    public RawImage ammoInImage;
    public RawImage noAmmoInInImage;

    private void Awake()
    {
        //Make sure that the player is able to shoot
        readyToShoot = true;
        canShoot = true;
        ammoCount = 4;
        ammoInChamber = true;
    }

    private void Update()
    {
        //Calling the input method
        MyInput();

        ammoText.text = ammoCount.ToString();

        /*if(ammoInChamber)
        {
            ammoInImage.enabled = true;
            noAmmoInInImage.enabled = false;
        }
        else
        {
            noAmmoInInImage.enabled = true;
            ammoInImage.enabled = false;
        }*/

        if(reloading)
        {
            reloadingText.text = "Reloading...";
        }
        else
        {
            if(ammoInChamber)
            {
                reloadingText.text = "1/" + ammoCount.ToString();
            }
            else
            {
                reloadingText.text = "0/" + ammoCount.ToString();
            }
        }
    }

    //A method for shooting. If the player has ammo, presses the LMB, and they are currently aiming, the Shoot method is called
    private void MyInput()
    {
        shooting = Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.JoystickButton7);

        if (readyToShoot && shooting && player.GetComponent<Movement>().aiming && canShoot)
        {
            Shoot();
        }

        if((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.JoystickButton7)) && ammoCount > 0 && !ammoInChamber)
        {
            StartCoroutine(ReloadGun());
        }
    }

    //A method that handles shooting
    private void Shoot()
    {
        canShoot = false;

        ammoInChamber = false;

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
        Debug.Log("Start reload");
        reloading = true;
        yield return new WaitForSeconds(reloadTime);
        ammoCount--;
        reloading = false;
        canShoot = true;
        ammoInChamber = true;
        Debug.Log("End reload");
    }
}
