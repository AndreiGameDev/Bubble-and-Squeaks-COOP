using UnityEngine;
using UnityEngine.InputSystem.UI;
//Implemented by Andrei
public class PlayerRefferenceMaster : MonoBehaviour {

    public WizardType wizzardMagicType;

    public DirFacing dirFacing;
    [HideInInspector] public PlayerMovementManager movementManager;
    [HideInInspector] public PlayerSpellFireManager spellFireManager;
    [HideInInspector] public PlayerInteractManager interactManager;
    [HideInInspector] public PlayerPause playerPause;
    [SerializeField] private int playerIndex = 0;
    public InputSystemUIInputModule inputSystemUIInputModule;

    public int GetPlayerIndex() {
        return playerIndex;
    }

    private void Awake() {
        movementManager = GetComponent<PlayerMovementManager>();
        spellFireManager = GetComponent<PlayerSpellFireManager>();
        interactManager = GetComponent<PlayerInteractManager>();
        playerPause = GetComponent<PlayerPause>();
    }
}
public enum DirFacing { Up, Down, Right, Left }
public enum WizardType { Light, Dark }