using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteraction : MonoBehaviour, IInteractable
{
    public Dialogue dialogue;
    
    public void Interact(PlayerRefferenceMaster player, DirFacing? direction = null) {
        DialogueManager.Instance.StartDialogue(dialogue);
    }
}
