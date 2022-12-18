using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs_Destructible : MonoBehaviour
{

    public GameObject destroyedVersion;

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
