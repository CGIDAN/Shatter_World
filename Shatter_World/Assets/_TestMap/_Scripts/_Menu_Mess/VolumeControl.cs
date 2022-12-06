using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider; // reference to the UI slider

    void Start()
    {
        // initialize the volume to the current value
        volumeSlider.value = AudioListener.volume;

        // subscribe to the onValueChanged event of the slider
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    void OnVolumeChanged(float volume)
    {
        // set the volume to the new value
        AudioListener.volume = volume;
    }
}