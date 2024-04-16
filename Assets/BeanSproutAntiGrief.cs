using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanSproutAntiGrief : MonoBehaviour
{
    BeanSproutPuzzle masterScript;
    private void Awake() {
        masterScript = GetComponentInParent<BeanSproutPuzzle>();
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        masterScript.canInteract = false;
    }

    private void OnCollisionExit2D(Collision2D collision) {
        masterScript.canInteract = true;
    }
}
