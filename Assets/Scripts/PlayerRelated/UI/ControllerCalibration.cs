using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
//Implemented by Andrei
public class ControllerCalibration : MonoBehaviour {
    ControllerCalibration instance;
    public ControllerCalibration Instance {
        get {
            return instance;
        }
    }
    PlayerInputManager inputManager;
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
        inputManager = GetComponent<PlayerInputManager>();
        if(inputManager.playerCount == 0) {
            ControllerRecalibration();
        }
    }

    public void ControllerRecalibration() {
        Time.timeScale = 0;
        controllerCalibrationScreen.SetActive(true);
        StatusChange();
        inputManager.EnableJoining();
    }

    public void ControllerJoined() {
        if(inputManager.playerCount == 2 || isTesting) {
            inputManager.enabled = false;
            controllerCalibrationScreen.SetActive(false);
            Time.timeScale = 1;
        } else {
            StatusChange();
            Debug.Log("Player " + inputManager.playerCount + " has entered the game");
        }
    }

    // UI Related
    public void StatusChange() {
        switch(inputManager.playerCount) {
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
