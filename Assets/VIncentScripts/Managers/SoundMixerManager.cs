using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private Slider soundFXSlider;
    [SerializeField] private Slider musicVolumeSlider;

    private void Start()
    {
        /*
        audioMixer.GetFloat("masterVolume", out float masterVolume);
        masterVolumeSlider.value = masterVolume;

        audioMixer.GetFloat("soundFXVolume", out float soundFXVolume);
        soundFXSlider.value = soundFXVolume;

        audioMixer.GetFloat("musicVolume", out float musicVolume);
        musicVolumeSlider.value = musicVolume;
        */
    }

    public void SetMasterVolume(float level)
    {
        audioMixer.SetFloat("masterVolume", Mathf.Log10(level) * 20f);
    }

    public void SetSoundFXVolume(float level)
    {
        audioMixer.SetFloat("soundFXVolume", Mathf.Log10(level) * 20f);
    }

    public void SetMusicVolume(float level)
    {
        audioMixer.SetFloat("musicVolume", Mathf.Log10(level) * 20f);
    }
}
