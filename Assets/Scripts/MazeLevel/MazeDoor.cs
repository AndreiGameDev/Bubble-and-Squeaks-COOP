using System.Collections;
using UnityEngine;
//Implemented by Andrei
public class MazeDoor : MonoBehaviour, IInteractable {
    MasterMazeDoorScript masterDoorManager;
    [SerializeField] WizardType type;
    [SerializeField] bool requireBothAttributes;
    [SerializeField] bool lightActivated;
    [SerializeField] bool darkActivated;

    [SerializeField] GameObject combinedDoor;
    [SerializeField] GameObject combinedDoorActivationWindow;
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
        combinedDoorActivationWindow.SetActive(true);
        combinedDoor.SetActive(false);
        yield return new WaitForSecondsRealtime(3);
        switch(typeToManage) {
            case WizardType.Light:
                combinedDoorActivationWindow.SetActive(false);
                combinedDoor.SetActive(true);
                lightActivated = false;
                break;
            case WizardType.Dark:
                combinedDoorActivationWindow.SetActive(false);
                combinedDoor.SetActive(true);
                darkActivated = false;
                break;
        }
    }
}
