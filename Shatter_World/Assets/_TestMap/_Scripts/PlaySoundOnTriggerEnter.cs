using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnTriggerEnter : MonoBehaviour
{
    // Assign a sound in the inspector
    public AudioClip soundToPlay;

    [SerializeField]
    public Projectile_Shoot projectileShoot;

    // A boolean to keep track of whether the sound has been played
    private bool soundPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is the player and the sound has not been played yet
        if (other.gameObject.tag == "Player" && !soundPlayed)
        {
            // Get the AudioSource component on the player game object
            AudioSource playerAudioSource = other.gameObject.GetComponent<AudioSource>();

            // Set the clip of the player's AudioSource to be the soundToPlay clip
            playerAudioSource.clip = soundToPlay;

            // Set the priority of the player's AudioSource to be higher than the default value (128)
            playerAudioSource.priority = 256;

            // Play the sound using the player's AudioSource
            playerAudioSource.PlayOneShot(soundToPlay);

            // Set the soundPlayed variable to true
            soundPlayed = true;

            // Disable shooting for 3 seconds
            projectileShoot.canShoot = false;
            Invoke("EnableShooting", 3.0f);
         }
    }
    private void EnableShooting()
    {
        projectileShoot.canShoot = true;
    }

}