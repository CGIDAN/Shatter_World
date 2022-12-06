using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shatter_Pieces : MonoBehaviour
{
    public string ballTag = "ball";

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(ballTag))
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
