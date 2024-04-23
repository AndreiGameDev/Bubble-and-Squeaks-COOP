using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour {
    [SerializeField] AudioMixer masterMixer;
    [SerializeField] Slider MasterVolumeSlider;
    [SerializeField] Slider MusicVolumeSlider;
    [SerializeField] Slider SFXVolumeSlider;

    private void Start() {
        switch(PlayerPrefs.HasKey("masterVolume")) {
            case true:
                LoadMasterVolume();
                break;
            case false:
                SetMasterVolume();
                break;
        }
        switch(PlayerPrefs.HasKey("musicVolume")) {
            case true:
                LoadMusicVolume();
                break;
            case false:
                SetMusicVolume();
                break;
        }
        switch(PlayerPrefs.HasKey("sfxVolume")) {
            case true:
                LoadSFXVolume();
                break;
            case false:
                SetSFXVolume();
                break;
        }
    }

    void LoadMasterVolume() {
        MasterVolumeSlider.value = PlayerPrefs.GetFloat("masterVolume");
        SetMasterVolume();
    }
    void LoadMusicVolume() {
        MusicVolumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SetMusicVolume();
    }
    void LoadSFXVolume() {
        SFXVolumeSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        SetSFXVolume();
    }
    public void SetMasterVolume() {
        float volume = MasterVolumeSlider.value;
        masterMixer.SetFloat("Volume_Master", Mathf.Log10(volume) *20);
        PlayerPrefs.SetFloat("masterVolume", volume);
    }

    public void SetMusicVolume() {
        float volume = MusicVolumeSlider.value;
        masterMixer.SetFloat("Volume_Music", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSFXVolume() {
        float volume = SFXVolumeSlider.value;
        masterMixer.SetFloat("Volume_SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }
}
