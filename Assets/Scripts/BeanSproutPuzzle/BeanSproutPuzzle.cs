using UnityEngine;

public class BeanSproutPuzzle : MonoBehaviour , IInteractable
{
    Animator animator;
    public bool canInteract = true;
    [SerializeField] GameObject colliderHolder;
    private void Awake() {
        animator = GetComponentInChildren<Animator>();
    }

    public void Interact(PlayerRefferenceMaster player, DirFacing? direction = null) {
        if(player.wizzardMagicType == WizardType.Light && canInteract) {
            Grow();
        } else if (player.wizzardMagicType == WizardType.Dark && canInteract) {
            Wither();
        }
    }

    public void Grow() {
        animator.SetTrigger("Grow");
        EnableCollider(false);
    }

    public void Wither() {
        animator.SetTrigger("Wither");
        EnableCollider(true);
    }

    public void EnableCollider(bool status) {
        colliderHolder.SetActive(status);   
    }
}
