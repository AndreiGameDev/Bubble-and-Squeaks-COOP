using UnityEngine;
//Implemented by Andrei
public class DialogueInteraction : MonoBehaviour, IInteractable
{
    public Dialogue dialogue;
    AudioManager audioManager;
    [SerializeField] AudioClip SFX_OpenDialogue;
    private void Start() {
        audioManager = AudioManager.Instance;   
    }
    public void Interact(PlayerRefferenceMaster player, DirFacing? direction = null) {
        DialogueManager.Instance.StartDialogue(dialogue);
        audioManager.PlaySFX(SFX_OpenDialogue);
    }
}
