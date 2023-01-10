using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Respawn_Player2 : MonoBehaviour
{
    public float maxX = 50;
    public float maxY = 50;
    public float maxZ = 50;
    public float minX = -50;
    public float minY = -50;
    public float minZ = -50;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > maxX
            || transform.position.x < minX
            || transform.position.z > maxZ
            || transform.position.z < minZ
            || transform.position.y > maxY
            || transform.position.y < minY)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
