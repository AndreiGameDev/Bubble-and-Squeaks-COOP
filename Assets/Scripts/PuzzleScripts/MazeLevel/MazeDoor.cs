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
    AudioManager audioManager;
    [SerializeField] AudioClip SFX_OpenDoor;
    [SerializeField] AudioClip SFX_ActivationWindowOpen;
    [SerializeField] AudioClip SFX_ActivationWindowOver;
    private void Awake() {
        masterDoorManager = GetComponentInParent<MasterMazeDoorScript>();
    }
    private void Start() {
        audioManager = AudioManager.Instance;
    }
    public void Interact(PlayerRefferenceMaster player, DirFacing? direction = null) {
        // Checks for which type of door the player is interacting with
        if(requireBothAttributes && !masterDoorManager.hasAnyDoorOpened) { 
            ActivateDoorOpenWindow(player);
            ChecksIfCanOpenSpecialDoor();
        } else if(player.wizzardMagicType == type && masterDoorManager.hasAnyDoorOpened == false) {
            OpenDoor();
        }
    }

    private void OpenDoor() {
        masterDoorManager.hasAnyDoorOpened = true;
        // Master Boolean set to true so we can't open the other door once you've been through.
        gameObject.SetActive(false); // Here there should be an animation player which would open the door instead of this and disabling the collision
        audioManager.PlaySFX(SFX_OpenDoor);
    }

    private void ChecksIfCanOpenSpecialDoor() {
        if(lightActivated == true && darkActivated == true) {
            OpenDoor();
        }
    } 

    private void ActivateDoorOpenWindow(PlayerRefferenceMaster player) {
        if(player.wizzardMagicType == WizardType.Light && !lightActivated) {
            audioManager.PlaySFX(SFX_ActivationWindowOpen);
            lightActivated = true;
            StartCoroutine(ActivationWindow(WizardType.Light));
        } else if(player.wizzardMagicType == WizardType.Dark && !darkActivated) {
            audioManager.PlaySFX(SFX_ActivationWindowOpen);
            darkActivated = true;
            StartCoroutine(ActivationWindow(WizardType.Dark));
        }
    } // Activates Door Open Window

    IEnumerator ActivationWindow(WizardType typeToManage) { 
        combinedDoorActivationWindow.SetActive(true);
        combinedDoor.SetActive(false);
        yield return new WaitForSecondsRealtime(3);
        switch(typeToManage) {
            case WizardType.Light:
                combinedDoorActivationWindow.SetActive(false);
                combinedDoor.SetActive(true);
                lightActivated = false;
                audioManager.PlaySFX(SFX_ActivationWindowOver);
                break;
            case WizardType.Dark:
                combinedDoorActivationWindow.SetActive(false);
                combinedDoor.SetActive(true);
                darkActivated = false;
                audioManager.PlaySFX(SFX_ActivationWindowOver);
                break;
        }
    } // This door Requires both powerups to be activated so I'm using an enumerator to set timers for power activations
}
