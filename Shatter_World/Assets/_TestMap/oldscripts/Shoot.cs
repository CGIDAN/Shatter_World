using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projectile;
    public Transform point;
    public int speed;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bul = (GameObject)Instantiate(projectile, point.transform.position, Quaternion.identity);
            bul.gameObject.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * speed;
        }
    }
}
