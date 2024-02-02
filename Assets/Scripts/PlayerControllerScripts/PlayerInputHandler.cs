using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerRefferenceMaster playerRefferenceMaster;
    private PlayerMovementManager playerMovementManagement;
    private PlayerSpellFireManager playerSpellFireManager;
    private PlayerInteractManager playerInteractManager;
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        var PlayerRefferenceMasters = FindObjectsOfType<PlayerRefferenceMaster>();
        var playerIndex = playerInput.playerIndex;
        playerRefferenceMaster = PlayerRefferenceMasters.FirstOrDefault(m => m.GetPlayerIndex() == playerIndex);
        playerMovementManagement = playerRefferenceMaster.movementManager;
        playerSpellFireManager = playerRefferenceMaster.spellFireManager;
        playerInteractManager = playerRefferenceMaster.interactManager;
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
