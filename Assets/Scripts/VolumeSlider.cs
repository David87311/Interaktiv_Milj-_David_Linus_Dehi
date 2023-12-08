using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource1;
    public AudioSource audioSource2;

    void Start()
    {
       
        volumeSlider.value = (audioSource1.volume + audioSource2.volume) / 2f;
    }

    public void OnVolumeChanged()
    {
        
        float newVolume = volumeSlider.value;

       
        audioSource1.volume = newVolume;
        audioSource2.volume = newVolume;
    }
}
