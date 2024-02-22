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
    public void Interact(PlayerRefferenceMaster player) {
        switch(requireBothAttributes) {
            case true:
                if(masterDoorManager.hasAnyDoorOpened == false) {
                    switch(player.wizzardMagicType) {
                        case WizardType.Light:
                            if(lightActivated == false) {
                                lightActivated = true;
                                StartCoroutine(ActivationWindow(WizardType.Light));
                            }
                            break;
                        case WizardType.Dark:
                            if(darkActivated == false) {
                                darkActivated = true;
                                StartCoroutine(ActivationWindow(WizardType.Dark));
                            }
                            break;
                    }
                    if(lightActivated == true && darkActivated == true) {
                        masterDoorManager.hasAnyDoorOpened = true;
                        // Master Boolean set to true so we can't open the other door once you've been through.
                        gameObject.SetActive(false); // Here there should be an animation player which would open the door instead of this and disabling the collision
                    }
                }
                break;
            case false:
                if(player.wizzardMagicType == type && masterDoorManager.hasAnyDoorOpened == false) {
                    masterDoorManager.hasAnyDoorOpened = true;
                    // Master Boolean set to true so we can't open the other door once you've been through.
                    gameObject.SetActive(false); // Here there should be an animation player which would open the door instead of this and disabling the collision
                }
                break;
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
