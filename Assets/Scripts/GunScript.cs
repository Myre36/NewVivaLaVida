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
    //The reload time of the bullet
    public float reloadTime;

    //A bool for if you can shoot
    private bool canShoot;
    //A bool for if you are currently reloading
    private bool reloading;
    //A bool for if there is a bullet in the chamber of the gun
    private bool ammoInChamber;
    private bool firstShot;

    //Refrence to the bullet spawn point
    public Transform bulletSpawn;
    //Refrence to the point that the bullet fires towards
    public Transform shootPoint;

    //The amount of bullets you have
    public int ammoCount;

    //The text for the reloading
    public TMP_Text reloadingText;

    //The images used for showing if you can shoot
    public RawImage ammoInImage;
    public RawImage noAmmoInInImage;

    // Sound effects
    public AudioSource gunShootSound;
    public AudioSource reloadSound;
    public AudioSource cantShootSound;

    //Refrence to the dialouge box
    public GameObject dialougeBox;

    //Refrence to the dialouge text
    public TMP_Text dialougeText;

    public Animator animator;
    private void Awake()
    {
        canShoot = true;
        //Add four bullets to your gun
        ammoCount = 4;
        //Make it so that you have a bullet in your chamber
        ammoInChamber = true;

        dialougeBox = GameObject.Find("SmallDialougeBox");
        dialougeText = GameObject.Find("SmallDialougeText").GetComponent<TMP_Text>();
    }

    private void Update()
    {
        //Calling the input method
        MyInput();

        //For making the gun image display correctly
        if(ammoInChamber)
        {
            ammoInImage.enabled = true;
            noAmmoInInImage.enabled = false;
        }
        else
        {
            noAmmoInInImage.enabled = true;
            ammoInImage.enabled = false;
        }

        //Make the reload text display correctly depending on what the player is doing
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
        if(Input.GetMouseButtonDown(0))
        {
            if(player.GetComponent<Movement>().aiming)
            {
                if (canShoot)
                {
                    Shoot();
                }
                else
                {
                    cantShootSound.Play();
                }
            }
        }

        //If you press R and have enough ammo, the reloading coroutine is activated
        if (Input.GetKeyDown(KeyCode.R) && ammoCount > 0 && !ammoInChamber && !reloading)
        {
            StartCoroutine(ReloadGun());
        }
    }

    //A method that handles shooting
    private void Shoot()
    {
        if(!firstShot)
        {
            StartCoroutine(ReloadReminder());
        }

        animator.SetTrigger("Shoot");

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

        gunShootSound.Play();
    }

    //A coroutine that reloads your gun
    IEnumerator ReloadGun()
    {
        Debug.Log("Start reload");
        reloading = true;
        reloadSound.Play();
        yield return new WaitForSeconds(reloadTime);
        ammoCount--;
        reloading = false;
        canShoot = true;
        ammoInChamber = true;
        Debug.Log("End reload");
    }

    IEnumerator ReloadReminder()
    {
        dialougeBox.GetComponent<RawImage>().enabled = true;
        dialougeText.enabled = true;
        dialougeText.text = "Press R to reload";
        firstShot = true;
        yield return new WaitForSeconds(3);
        dialougeText.text = "You are not supposed to see this";
        dialougeBox.GetComponent<RawImage>().enabled = false;
        dialougeText.enabled = false;
    }
}
