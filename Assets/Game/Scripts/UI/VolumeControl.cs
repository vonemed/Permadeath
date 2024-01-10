using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{
    public AudioMixer audioMixer; // Assign your AudioMixer in the inspector
    public Slider volumeSlider;   // Assign your volume slider in the inspector

    void Start()
    {
        // Initialize slider's value to current volume setting
        float currentVolume;
        if (audioMixer.GetFloat("MasterVolume", out currentVolume))
        {
            volumeSlider.value = Mathf.Pow(10f, currentVolume / 20f);
        }
        // Add a listener to call SetVolume whenever the slider value changes
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float sliderValue)
    {
        // Convert linear slider value (0 to 1) to decibels (-80 to 0)
        float volumeDb = sliderValue > 0.0001f ? Mathf.Log10(sliderValue) * 20 : -80f;
        audioMixer.SetFloat("MasterVolume", volumeDb);
    }
}