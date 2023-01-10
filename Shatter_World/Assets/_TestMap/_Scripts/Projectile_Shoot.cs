using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using Random = UnityEngine.Random;

public class Projectile_Shoot : MonoBehaviour
{
    //audio
    public AudioSource audioSource;
    public AudioClip sound1;
    public AudioClip sound2;

    public bool canShoot = true;

    //bullet
    public GameObject bullet;

    //bullet force
    public float shootForce, upwardForce;

    //pause menu
    public puse_menu pauseMenu;

    //Gun stats
    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;

    int bulletsLeft, bulletsShot;

    //bools
    bool shooting, readyToShoot, reloading;

    //Reference
    public Camera fpsCam;
    public Transform attackPoint;

    public bool allowInvoke = true;

    private void Awake()
    {//make sure magazine is full
        bulletsLeft = magazineSize;
        readyToShoot = true;
        audioSource = GetComponent<AudioSource>();

    }

    private void Start()
    {
        audioSource.Stop();

    }
    private void Update()
    {
        MyInput();
    }

    private void MyInput()
    {
        //check if allowed to hold down button 
        if (allowButtonHold) shooting = Input.GetKeyDown(KeyCode.JoystickButton0);
        else shooting = Input.GetKey(KeyCode.Mouse0);

        // check if A button is pressed on Xbox controller
        shooting |= Input.GetButton("Fire1");

        //reloading
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();
        // reload automatically when trying to shoot without ammo
        if (readyToShoot && shooting && !reloading && bulletsLeft <=0) Reload();

        //shooting
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0 && canShoot)
        {
            //set bullets shot to 0
            bulletsShot = 0;

            Shoot();
        }    
    }

    private void Shoot()
    {
        AudioClip[] sounds = { sound1, sound2 };


        readyToShoot = false;

        //find the hit position using raycast
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        //check for hit
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);

        //calculate direction from attackpoint to target
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        //calculate spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //calculate direction with spread
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);


        //Instantiate bullet/projectile
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        //rotate bullet to shoot direction
        currentBullet.transform.forward = directionWithSpread.normalized;

        // add forces to bullet
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);

        // Check if the pause menu is active
        if (puse_menu.isGamePaused)
        {
            audioSource.Pause();
        }
        else
        {
            // Play the shooting sound
            int randomIndex = Random.Range(0, sounds.Length);
            audioSource.clip = sounds[randomIndex];
            audioSource.Play();
        }


        bulletsLeft--;
        bulletsShot++;

        //invoke resetShot
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke=false;
        }

        //if more than one bullets per tap
        if (bulletsShot < bulletsPerTap && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);

    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }

}
