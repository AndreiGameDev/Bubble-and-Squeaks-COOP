using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.SceneManagement;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerRefferenceMaster playerRefferenceMaster;
    private PlayerMovementManager playerMovementManagement;
    private PlayerSpellFireManager playerSpellFireManager;
    private PlayerInteractManager playerInteractManager;

    private InputSystemUIInputModule uiInput;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        playerInput = GetComponent<PlayerInput>();
        DialogueManager.Instance.playerInputList.Add(playerInput);

        LoadVariables();
        SceneManager.sceneLoaded += OnSceneLoaded;
        uiInput = FindAnyObjectByType<InputSystemUIInputModule>();
        playerInput.uiInputModule = uiInput;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        LoadVariables();
    }
    public void TakeControlOverInput() {
        uiInput.actionsAsset = playerInput.actions;
    }
    void LoadVariables() {
        var PlayerRefferenceMasters = FindObjectsOfType<PlayerRefferenceMaster>();
        var playerIndex = playerInput.playerIndex;
        playerRefferenceMaster = PlayerRefferenceMasters.FirstOrDefault(m => m.GetPlayerIndex() == playerIndex);
        playerMovementManagement = playerRefferenceMaster.movementManager;
        playerSpellFireManager = playerRefferenceMaster.spellFireManager;
        playerInteractManager = playerRefferenceMaster.interactManager;
    }
    private void OnDisable() {
        DialogueManager.Instance.playerInputList.Remove(playerInput);
    }
    public void OnMovementInput(CallbackContext context)
    {
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

}
