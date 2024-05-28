using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.SceneManagement;
using static UnityEngine.InputSystem.InputAction;
//Implemented by Andrei
public class PlayerInputHandler : MonoBehaviour {
    private static PlayerInputHandler instance;
    public static PlayerInputHandler Instance {
        get {
            return instance;
        }
    }
    private PlayerInput playerInput;
    private PlayerRefferenceMaster playerRefferenceMaster;
    private PlayerMovementManager playerMovementManagement;
    private PlayerSpellFireManager playerSpellFireManager;
    private PlayerInteractManager playerInteractManager;
    private PlayerPause playerPause;
    private InputSystemUIInputModule uiInput;
    private void Awake() {
        DontDestroyOnLoad(this);
        playerInput = GetComponent<PlayerInput>();
        // Since this script spawns with each player input I can add it to SwapInputMode gameObject and it will always be able to toggle my InputMap
        SwapInputMode.Instance.playerInputs.Add(playerInput);
        // I want to load variables on different scene entries but also on awake so I'm storing it in a variable
        LoadVariables();
        // Shouldn't need to set the uiInput again as it's in PlayerManager prefab
        uiInput = FindAnyObjectByType<InputSystemUIInputModule>();
        playerInput.uiInputModule = uiInput;
        SceneManager.sceneLoaded += OnSceneLoaded;

    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        LoadVariables();
    }
    // Small Script to ensure that both players can use the dialogue system simultaneously
    public void TakeControlOverInput() {
        if(uiInput != null) {
            uiInput.actionsAsset = playerInput.actions;
        }
    }
    // Finds every player reference script and matches it with the corresponding index then loads in variables.
    void LoadVariables() {
        var PlayerRefferenceMasters = FindObjectsOfType<PlayerRefferenceMaster>();
        var playerIndex = playerInput.playerIndex;
        playerRefferenceMaster = PlayerRefferenceMasters.FirstOrDefault(m => m.GetPlayerIndex() == playerIndex);
        playerMovementManagement = playerRefferenceMaster.movementManager;
        playerSpellFireManager = playerRefferenceMaster.spellFireManager;
        playerInteractManager = playerRefferenceMaster.interactManager;
        playerPause = playerRefferenceMaster.playerPause;
    }

    //Removes playerinput from swap input mode since it means this player input no longer exists
    private void OnDisable() {
        SwapInputMode.Instance.playerInputs.Remove(playerInput);
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void OnMovementInput(CallbackContext context) {
        if(playerMovementManagement != null) {
            playerMovementManagement.SetMovementDir(context.ReadValue<Vector2>());
        }
    }

    public void OnFireInput(CallbackContext context) {
        if(playerSpellFireManager != null) {
            playerSpellFireManager.hasFired = context.ReadValueAsButton();
        }
    }

    public void OnInteractInput(CallbackContext context) {
        if(playerInteractManager != null) {
            playerInteractManager.hasInteracted = context.ReadValueAsButton();
        }
    }

    public void OnPauseInput(CallbackContext context) {
        if(playerPause != null) {
            playerPause.hasPressedPause = context.ReadValueAsButton();
        }
    }

}
