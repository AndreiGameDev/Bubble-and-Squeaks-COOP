using UnityEngine;
using UnityEngine.SceneManagement;
//Implemented by Andrei
public class AudioManager : MonoBehaviour {
    private static AudioManager _instance;
    public static AudioManager Instance {
        get {
            return _instance;
        }
    }
    [Header("Audio Source")]
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource sfx;

    [Header("Music")]
    [SerializeField] AudioClip M_MainMenu;
    [SerializeField] AudioClip M_Game;


    private void Awake() {
        if(_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    //private void Start() {
    //    SceneManager.activeSceneChanged += OnSceneChange;
    //}
    public void PlaySFX(AudioClip clip) {
        sfx.PlayOneShot(clip);
    }
    //void OnSceneChange(Scene currentScene, Scene nextScene) {
    //    foreach(int i in PlayerLevelScenes.instance.GetPlayerLevelScenes()) {
    //        if(nextScene.buildIndex == i) {
    //            music.clip = M_Game;
    //            music.Play();
    //        } else {
    //            music.clip = M_MainMenu;
    //            music.Play();
    //        }
    //    }
    //}
}
