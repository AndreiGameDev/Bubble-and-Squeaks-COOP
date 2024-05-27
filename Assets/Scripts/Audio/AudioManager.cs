using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
//Implemented by Andrei
public class AudioManager : MonoBehaviour {
    private static AudioManager instance;
    public static AudioManager Instance {
        get {
            return instance;
        }
    }
    [Header("Audio Source")]
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource sfx;

    [Header("Music")]
    [SerializeField] AudioClip M_MainMenu;


    private void Awake() {
        if(instance != null && instance != this) {
            Destroy(this.gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start() {
        SceneManager.activeSceneChanged += OnSceneChange;
    }
    public void PlaySFX(AudioClip clip) {
        sfx.PlayOneShot(clip);
    }
    void OnSceneChange(Scene currentScene, Scene nextScene) {
        foreach(int i in PlayerLevelScenes.Instance.GetPlayerLevelScenes()) {
            if(nextScene.buildIndex == i) {
                music.Stop();
            } else if(nextScene.buildIndex == 0) {
                music.clip = M_MainMenu;
                music.Play();
            }
        }
    }
}
