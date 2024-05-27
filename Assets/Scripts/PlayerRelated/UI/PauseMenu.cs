using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
//Implemented by jack improved by Andrei
public class PauseMenu : MonoBehaviour {
    static PauseMenu instance;
    public static PauseMenu Instance {
        get { return instance; }
    }
    SwapInputMode swapInputMode;
    private void Awake() {
        if(instance != null && instance != this) {
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        swapInputMode = SwapInputMode.Instance;
        
    }
    private void Start() {
        gameObject.SetActive(false);
    }
    private void OnEnable() {
        swapInputMode.gameObject.SetActive(false);
        Time.timeScale = 0f;
        
    }
    public void OnDisable() {
        if(instance != this) {
            return;
        }
        if(swapInputMode.IsDestroyed() != true) {
            swapInputMode.gameObject.SetActive(true);
        }
        Time.timeScale = 1f;
    }
    public void MainMenuButton() {
        SceneManager.LoadScene("MainMenu");
        Destroy(gameObject);
    }

    public void Reset() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}