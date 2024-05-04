using UnityEngine;
using UnityEngine.Events;
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

    [Header("Audio")]
    AudioManager audioManager;
    [SerializeField]AudioClip SFX_Wither;
    [SerializeField]AudioClip SFX_Bloom;

    public UnityEvent ChangeFlowerBloom;
    public UnityEvent ChangeFlowerWither;
    // Related to Door Puzzle script
    private DoorPuzzle doorObject;
    public DoorPuzzle doorPuzzle { get { return doorObject; } set { doorObject = value; } }
    private void Start() {
        audioManager = AudioManager.Instance;
    }
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
        audioManager.PlaySFX(SFX_Bloom);
        _currentState = LeverStates.Illuminated;
        ChangeFlowerBloom.Invoke();
    }

    private void UnbloomFlower() {
        audioManager.PlaySFX(SFX_Wither);
        _currentState = LeverStates.Withered;
        ChangeFlowerWither.Invoke();
    }
}

public enum LeverStates {
    Null,
    Illuminated,
    Withered
}