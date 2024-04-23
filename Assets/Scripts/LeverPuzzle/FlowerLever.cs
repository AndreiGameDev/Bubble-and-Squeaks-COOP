using UnityEngine;
//Implemented by Andrei
public class FlowerLever : MonoBehaviour, IInteractable {
    [Header("States")]
    [SerializeField]
    private LeverStates correctState;
    public LeverStates _correctState {
        get { return correctState; }
    }
    [SerializeField]
    private LeverStates currentState;
    public LeverStates _currentState {
        get { return currentState; }
        private set { currentState = value; }
    }
    [Header("Sprites")]
    [SerializeField] GameObject bloomedGO;
    [SerializeField] GameObject witheredGO;
    [SerializeField] GameObject defaultGO;

    // Related to Door Puzzle script
    private DoorPuzzle doorObject;
    public DoorPuzzle doorPuzzle { get { return doorObject; } set { doorObject = value; } }

    public void Interact(PlayerRefferenceMaster player, DirFacing? direction = null) {
        // Check if the flower's state should change based on the player's type
        if(player.wizzardMagicType == WizardType.Light && currentState != LeverStates.Illuminated) {
            // Bloom the flower for a light wizard
            BloomFlower();
            Debug.Log("Blooming Flower");
            doorObject.DoorOpen();
        } else if(player.wizzardMagicType == WizardType.Dark && currentState != LeverStates.Withered) {
            // Unbloom the flower for a dark wizard
            UnbloomFlower();
            doorObject.DoorOpen();
        }
    }

    private void BloomFlower() {
        _currentState = LeverStates.Illuminated;
        ChangeModelBloom();
    }

    private void UnbloomFlower() {
        _currentState = LeverStates.Withered;
        ChangeModelUnbloom();
    }

    public void ChangeModelBloom() {
        defaultGO.SetActive(false);
        bloomedGO.SetActive(true);
        witheredGO.SetActive(false);
    }

    public void ChangeModelUnbloom() {
        defaultGO.SetActive(false);
        bloomedGO.SetActive(false);
        witheredGO.SetActive(true);
    }

    public void ChangeModelDefault() {
        defaultGO.SetActive(true);
        bloomedGO.SetActive(false);
        witheredGO.SetActive(false);
    }
}

public enum LeverStates {
    Null,
    Illuminated,
    Withered
}