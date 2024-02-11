using UnityEngine;

public class MazeDoor : MonoBehaviour, IInteractable {
    public bool isDoorOpen { get; private set; } = false;
    MasterMazeDoorScript masterDoorManager;
    [SerializeField] WizardType type;
    private void Awake() {
        masterDoorManager = GetComponentInParent<MasterMazeDoorScript>();
    }
    public void Interact(PlayerRefferenceMaster player) {
        if(player.wizzardMagicType == type && !isDoorOpen && !checkOtherDoorState()) {
            isDoorOpen = true;
            // Master Boolean set to true so we can't open the other door once you've been through.
            gameObject.SetActive(false); // Here there should be an animation player which would open the door instead of this and disabling the collision
        }
    }

    bool checkOtherDoorState() {
        switch(type) {
            case WizardType.Light:
                return masterDoorManager.isDarkDoorOpen();
            case WizardType.Dark:
                return masterDoorManager.isLightDoorOpen();
            default:
                Debug.Log("Error");
                return false;
        }
    }
}
