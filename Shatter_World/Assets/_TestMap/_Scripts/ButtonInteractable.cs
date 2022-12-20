using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonInteractable : MonoBehaviour
{
    public Button button;
    public string sceneName;
    private bool wasSceneLoaded;

    void Start()
    {
        // Initialize the wasSceneLoaded flag to false
        wasSceneLoaded = false;
    }

    void Update()
    {
        // Check if the scene with the specified name has been loaded
        bool sceneLoaded = SceneManager.GetSceneByName(sceneName).isLoaded;

        // If the scene has been loaded and was not previously loaded, set the wasSceneLoaded flag to true
        if (sceneLoaded && !wasSceneLoaded)
        {
            wasSceneLoaded = true;
        }

        // If the scene has been unloaded and was previously loaded, set the wasSceneLoaded flag to false
        if (!sceneLoaded && wasSceneLoaded)
        {
            wasSceneLoaded = false;
        }

        // Set the interactable property of the button based on the value of the wasSceneLoaded flag
        button.interactable = wasSceneLoaded;
    }
}
