using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRefferenceMaster : MonoBehaviour
{
    public enum WizardType { Light, Dark }
    public WizardType wizzardMagicType;
    
    public DirFacing dirFacing;
    public PlayerMovementManager movementManager;
    public PlayerSpellFireManager spellFireManager;
    public PlayerInteractManager interactManager;
    [SerializeField] private int playerIndex = 0;
    
    public int GetPlayerIndex() {
        return playerIndex;
    }

    private void Awake() {
        movementManager = GetComponent<PlayerMovementManager>();
        spellFireManager = GetComponent<PlayerSpellFireManager>();
        interactManager = GetComponent<PlayerInteractManager>();
    }
}
public enum DirFacing { Up, Down, Right, Left }