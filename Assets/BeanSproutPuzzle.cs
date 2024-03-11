using UnityEngine;

public class BeanSproutPuzzle : MonoBehaviour , IInteractable
{
    Animator animator;

    public bool canInteract = true;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    public void Interact(PlayerRefferenceMaster player) {
        if(player.wizzardMagicType == WizardType.Light && canInteract) {
            Grow();
        } else if (player.wizzardMagicType == WizardType.Dark && canInteract) {
            Wither();
        }
    }

    public void Grow() {
        animator.SetTrigger("Grow");
    }

    public void Wither() {
        animator.SetTrigger("Wither");
    }
}
