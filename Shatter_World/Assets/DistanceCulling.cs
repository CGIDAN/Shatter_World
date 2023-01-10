using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCulling : MonoBehaviour
{
    // Array of objects to be culled
    public GameObject[] objectsToCull;

    // Distance at which objects should be culled
    public float cullDistance = 50.0f;

    void Update()
    {
        // Loop through the objects to cull
        for (int i = 0; i < objectsToCull.Length; i++)
        {
            // Calculate the distance between the camera and the object
            float distance = Vector3.Distance(transform.position, objectsToCull[i].transform.position);

            // Calculate the object's current distance from the cull distance
            float distanceFromCull = Mathf.Abs(distance - cullDistance);

            // If the distance is greater than the cull distance, deactivate the object
            if (distance > cullDistance)
            {
                objectsToCull[i].SetActive(false);
            }

            // If the distance is less than the cull distance, activate the object
            else
            {
                objectsToCull[i].SetActive(true);
            }
        }
    }
}