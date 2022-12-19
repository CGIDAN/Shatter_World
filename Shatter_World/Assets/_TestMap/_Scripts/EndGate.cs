using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGate : MonoBehaviour
{
    public GameObject winScreen;  // Drag and drop the win screen canvas in the inspector
    public Text timeText;  // Drag and drop the text element for the time in the inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            // Set the time text to the time it took to complete the level
            timeText.text = "Time: " + Time.timeSinceLevelLoad.ToString("F2");

            // Enable the win screen canvas
            winScreen.SetActive(true);

        }
    }


    // Call this method when the "Try Again" button is clicked
    public void TryAgain()
    {
        // Load the current scene again
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Call this method when the "Next Level" button is clicked
    public void NextLevel()
    {
        // Load the next scene in the build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}