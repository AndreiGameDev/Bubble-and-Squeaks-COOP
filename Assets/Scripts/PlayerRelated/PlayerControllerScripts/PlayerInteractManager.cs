using UnityEngine;
//Implemented by Andrei
public class PlayerInteractManager : MonoBehaviour
{
    PlayerRefferenceMaster playerRefs;
    public bool hasInteracted;
    private void Awake() {
        playerRefs = GetComponent<PlayerRefferenceMaster>();
    }
    Vector2 DirectionVector() {
        switch(playerRefs.dirFacing) {
            case DirFacing.Up:
                return Vector2.up;
            case DirFacing.Down:
                return Vector2.down;
            case DirFacing.Left:
                return Vector2.left;
            case DirFacing.Right:
                return Vector2.right;
            default:
                return Vector2.zero;
        }
    }
    void OnInteract() {
        if(hasInteracted) {
            //Debug.DrawRay(transform.position, DirectionVector(), Color.red);
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, DirectionVector(), .1f);
            if(hits.Length > 0) {
                foreach(RaycastHit2D hit in hits) {
                    IInteractable interactable = hit.transform.gameObject.GetComponent<IInteractable>();
                    if(interactable != null) {
                        interactable.Interact(playerRefs);
                    }
                }
            }
        }
    }
    private void Update() {
        OnInteract();
    }
}
