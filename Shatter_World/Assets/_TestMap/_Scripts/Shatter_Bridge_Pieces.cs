using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shatter_Bridge_Pieces : MonoBehaviour
{
    public string playerTag = "Player";

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }

        /* Vector3 point = other.contacts[0].point;

          foreach (var contact in other.contacts)
          {
              GetComponent<Rigidbody>().isKinematic = false;
          }
        */
    }
}
