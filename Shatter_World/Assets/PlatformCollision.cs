using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformCollision : MonoBehaviour
{
       // This function is called when the player collides with a platform
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is a platform
        if (collision.gameObject.tag == "Platform")
        {
            // Make the platform the parent of the player character
            transform.SetParent(collision.transform);
        }
    }

    // This function is called when the player stops colliding with a platform
    void OnCollisionExit(Collision collision)
    {
        // Check if the collided object is a platform
        if (collision.gameObject.tag == "Platform")
        {
            // Remove the platform as the parent of the player character
            transform.SetParent(null);
        }
    }
}
