using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
//Implemented by Andrei
public class ControllerCalibration : MonoBehaviour {
    static ControllerCalibration instance;
    public static ControllerCalibration Instance {
        get {
            return instance;
        }
    }
    PlayerInputManager playerInputManager;
    [SerializeField] GameObject controllerCalibrationScreen;
    [SerializeField] TextMeshProUGUI player1Status;
    [SerializeField] TextMeshProUGUI player2Status;
    [SerializeField] bool isTesting = false;
    private void Awake() {
        if(instance != null && instance != this) {
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        playerInputManager = GetComponent<PlayerInputManager>();
        if(playerInputManager.playerCount == 0) {
            ControllerRecalibration();
        }
        SceneManager.activeSceneChanged += OnSceneChanged;
    }
    private void OnDestroy() {
        SceneManager.activeSceneChanged -= OnSceneChanged;
    }
    private void OnSceneChanged(Scene arg0, Scene arg1) {
        playerInputManager.enabled = true;
        if(playerInputManager.playerCount == 0) {
            ControllerRecalibration();
        }
    }

    public void ControllerRecalibration() {
        Time.timeScale = 0;
        controllerCalibrationScreen.SetActive(true);
        StatusChange();
        playerInputManager.EnableJoining();
    }

    public void ControllerJoined() {
        if(instance != this) {
            return;
        }
        if(playerInputManager.playerCount == 2|| isTesting) {
            playerInputManager.enabled = false;
            controllerCalibrationScreen.SetActive(false);
            Time.timeScale = 1;
        } else {
            StatusChange();
            Debug.Log("Player " + playerInputManager.playerCount + " has entered the game");
        }
    }

    // UI Related
    public void StatusChange() {
        switch(playerInputManager.playerCount) {
            case 0:
                player1Status.text = "Not Ready";
                player1Status.color = Color.red;
                player2Status.text = "Not Ready";
                player2Status.color = Color.red;
                break;
            case 1:
                player1Status.text = "Ready";
                player1Status.color = Color.green;
                break;
            case 2:
                player2Status.text = "Ready";
                player2Status.color = Color.green;
                break;
        }
    }
}
