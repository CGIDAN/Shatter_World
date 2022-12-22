using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicOff : MonoBehaviour
{

        private void OnCollisionEnter(UnityEngine.Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
            GetComponent<Rigidbody>().isKinematic = false;
            }

        }
 }
