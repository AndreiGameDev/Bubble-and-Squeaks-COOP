using System.Collections;
using UnityEngine;

public class MazeDoor : MonoBehaviour, IInteractable {
    MasterMazeDoorScript masterDoorManager;
    [SerializeField] WizardType type;
    [SerializeField] bool requireBothAttributes;
    [SerializeField] bool lightActivated;
    [SerializeField] bool darkActivated;
    private void Awake() {
        masterDoorManager = GetComponentInParent<MasterMazeDoorScript>();
    }
    public void Interact(PlayerRefferenceMaster player, DirFacing? direction = null) {
        if(requireBothAttributes && !masterDoorManager.hasAnyDoorOpened) {
            if(player.wizzardMagicType == WizardType.Light && !lightActivated) {
                lightActivated = true;
                StartCoroutine(ActivationWindow(WizardType.Light));
            } else if(player.wizzardMagicType == WizardType.Dark && !darkActivated) {
                darkActivated = true;
                StartCoroutine(ActivationWindow(WizardType.Dark));
            }
            if(lightActivated == true && darkActivated == true) {
                masterDoorManager.hasAnyDoorOpened = true;
                // Master Boolean set to true so we can't open the other door once you've been through.
                gameObject.SetActive(false); // Here there should be an animation player which would open the door instead of this and disabling the collision
            }
        } else if(player.wizzardMagicType == type && masterDoorManager.hasAnyDoorOpened == false) {
            masterDoorManager.hasAnyDoorOpened = true;
            // Master Boolean set to true so we can't open the other door once you've been through.
            gameObject.SetActive(false); // Here there should be an animation player which would open the door instead of this and disabling the collision
        }
    }

    IEnumerator ActivationWindow(WizardType typeToManage) {
        yield return new WaitForSecondsRealtime(3);
        switch(typeToManage) {
            case WizardType.Light:
                lightActivated = false;
                break;
            case WizardType.Dark:
                darkActivated = false;
                break;
        }
    }
}
