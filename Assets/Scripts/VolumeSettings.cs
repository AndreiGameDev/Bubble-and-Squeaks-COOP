using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;
//Implemented by Andrei
public static class VolumePlayerPrefsStrings {
    public static string masterVolumePrefs = "MasterVolume";
    public static string musicVolumePrefs = "MusicVolume" ;
    public static string sfxVolumePrefs = "SFXVolume";
}
public class VolumeSettings : MonoBehaviour {
    [SerializeField] AudioMixer masterMixer;
    [SerializeField] Slider MasterVolumeSlider;
    [SerializeField] Slider MusicVolumeSlider;
    [SerializeField] Slider SFXVolumeSlider;
    private void Awake() {
        switch(PlayerPrefs.HasKey(VolumePlayerPrefsStrings.masterVolumePrefs)) {
            case true:
                LoadMasterVolume();
                break;
            case false:
                SetMasterVolume();
                break;
        }
        switch(PlayerPrefs.HasKey(VolumePlayerPrefsStrings.musicVolumePrefs)) {
            case true:
                LoadMusicVolume();
                break;
            case false:
                SetMusicVolume();
                break;
        }
        switch(PlayerPrefs.HasKey(VolumePlayerPrefsStrings.sfxVolumePrefs)) {
            case true:
                LoadSFXVolume();
                break;
            case false:
                SetSFXVolume();
                break;
        }
        gameObject.SetActive(false);
    }
    private void LoadSavedVolumes() {
        
    }
    void LoadMasterVolume() {
        MasterVolumeSlider.value = PlayerPrefs.GetFloat(VolumePlayerPrefsStrings.masterVolumePrefs);
        SetMasterVolume();
    }
    void LoadMusicVolume() {
        MusicVolumeSlider.value = PlayerPrefs.GetFloat(VolumePlayerPrefsStrings.musicVolumePrefs);
        SetMusicVolume();
    }
    void LoadSFXVolume() {
        SFXVolumeSlider.value = PlayerPrefs.GetFloat(VolumePlayerPrefsStrings.sfxVolumePrefs);
        SetSFXVolume();
    }
    public void SetMasterVolume() {
        float volume = MasterVolumeSlider.value;
        masterMixer.SetFloat("Volume_Master", Mathf.Log10(volume) *20);
        PlayerPrefs.SetFloat(VolumePlayerPrefsStrings.masterVolumePrefs, volume);
    }

    public void SetMusicVolume() {
        float volume = MusicVolumeSlider.value;
        masterMixer.SetFloat("Volume_Music", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat(VolumePlayerPrefsStrings.musicVolumePrefs, volume);
    }

    public void SetSFXVolume() {
        float volume = SFXVolumeSlider.value;
        masterMixer.SetFloat("Volume_SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(VolumePlayerPrefsStrings.sfxVolumePrefs, volume);
    }
}
