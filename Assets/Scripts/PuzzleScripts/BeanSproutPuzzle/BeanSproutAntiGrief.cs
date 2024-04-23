using UnityEngine;
//Implemented by Andrei
public class BeanSproutAntiGrief : MonoBehaviour
{
    BeanSproutPuzzle masterScript;
    private void Awake() {
        masterScript = GetComponentInParent<BeanSproutPuzzle>();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        masterScript.canInteract = false;
    }
    private void OnTriggerExit2D(Collider2D collision) {
        masterScript.canInteract = true;
    }
}
