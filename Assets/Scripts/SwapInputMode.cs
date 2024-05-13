using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//Implemented by Andrei
public class SwapInputMode : MonoBehaviour {
    static SwapInputMode instance;
    public static SwapInputMode Instance {
        get {
            return instance;
        }
    }
    public List<PlayerInput> playerInputs;
    private void Awake() {
        if(instance != null && instance != this) {
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // When disabled set player input action maps to UI Mode
    private void OnDisable() {
        foreach(PlayerInput player in playerInputs) {
            player.SwitchCurrentActionMap("UI");
        }
    }
    // When Enabled set player input action maps to Player Mode
    private void OnEnable() {
        foreach(PlayerInput player in playerInputs) {
            player.SwitchCurrentActionMap("Player");
        }
    }
}
