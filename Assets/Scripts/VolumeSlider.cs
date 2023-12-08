using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource1;
    public AudioSource audioSource2;

    void Start()
    {
        // Set the initial value of the slider to the average volume of the two audio sources
        volumeSlider.value = (audioSource1.volume + audioSource2.volume) / 2f;
    }

    public void OnVolumeChanged()
    {
        // Called when the volume slider value changes
        float newVolume = volumeSlider.value;

        // Update the volume of both audio sources
        audioSource1.volume = newVolume;
        audioSource2.volume = newVolume;
    }
}
