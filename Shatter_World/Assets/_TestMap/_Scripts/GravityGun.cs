using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GravityGun : MonoBehaviour
{

    [SerializeField] Camera cam;
    [SerializeField] float maxGrabDistance = 10f, throwForce = 20f, lerpSpeed = 10f;
    [SerializeField] Transform objectHolder;

    Rigidbody grabbedRB;
    void Start()
    {
        // Create a layer mask that includes the "Obstacle" layer
        LayerMask obstacleMask = LayerMask.GetMask("Obstacle");
    }
    void Update()
    {
        if (grabbedRB)
        {
            grabbedRB.MovePosition(Vector3.Lerp(grabbedRB.position, objectHolder.transform.position, Time.deltaTime * lerpSpeed));

            if (Input.GetKeyDown(KeyCode.JoystickButton2))
            {
                grabbedRB.isKinematic = false;
                grabbedRB.AddForce(cam.transform.forward * throwForce, ForceMode.VelocityChange);
                grabbedRB = null;
            }
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            if (grabbedRB)
            {
                grabbedRB.isKinematic = false;
                grabbedRB = null;
            }
            else
            {
                RaycastHit hit;
                Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
                if (Physics.Raycast(ray, out hit, maxGrabDistance))
                {
                    grabbedRB = hit.collider.gameObject.GetComponent<Rigidbody>();
                    if (grabbedRB)
                    {
                        // Check for objects in the path between the player and the grabbed object
                        RaycastHit obstacleHit;
                        if (Physics.Raycast(cam.transform.position, grabbedRB.transform.position - cam.transform.position, out obstacleHit, maxGrabDistance))
                        {
                            // If an object is in the way, position the grabbed object just outside the other object's collider
                            grabbedRB.transform.position = obstacleHit.point + obstacleHit.normal * grabbedRB.GetComponent<Collider>().bounds.extents.magnitude;
                        }
                        grabbedRB.isKinematic = false;
                    }
                }
            }
        }

        if (grabbedRB)
        {
            // Use Physics.OverlapSphere or Physics.OverlapBox to detect when the held object is intersecting with the other object's collider
            Collider[] overlappingColliders = Physics.OverlapSphere(grabbedRB.transform.position, grabbedRB.GetComponent<Collider>().bounds.extents.magnitude, LayerMask.GetMask("Obstacle"));

            if (overlappingColliders.Length > 0)
            {
                // Check for intersections between the held object's mesh and the other object's mesh
                RaycastHit meshHit;
                if (grabbedRB.GetComponent<MeshCollider>().Raycast(new Ray(grabbedRB.transform.position, overlappingColliders[0].transform.position - grabbedRB.transform.position), out meshHit, grabbedRB.GetComponent<Collider>().bounds.extents.magnitude))
                {
                    // Move the held object away from the intersection point
                    grabbedRB.transform.position = meshHit.point + meshHit.normal * grabbedRB.GetComponent<Collider>().bounds.extents.magnitude;
                }
            }

            // Use the object's Rigidbody to move it towards the objectHolder transform
            grabbedRB.AddForce((objectHolder.transform.position - grabbedRB.transform.position) * lerpSpeed);
        }
    }
}