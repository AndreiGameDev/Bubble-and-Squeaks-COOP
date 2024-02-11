using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerLever : MonoBehaviour, IInteractable {
    [Header("States")]
    [SerializeField]
    private States correctState;
    public States _correctState {
        get { return correctState; }
    }
    [SerializeField]
    private States currentState;
    public States _currentState {
        get { return currentState; }
        private set { currentState = value; }
    }
    [Header("Sprites")]
    public Sprite bloomedSprite;
    public Sprite witheredSprite;
    public Sprite defaultSprite;
    public SpriteRenderer spriteRenderer;

    // Related to Door Puzzle script
    private DoorPuzzle doorObject;
    public DoorPuzzle doorPuzzle { get { return doorObject; } set { doorObject = value; } }
    
    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Interact(PlayerRefferenceMaster player) {
        // Check if the flower's state should change based on the player's type
        if(player.wizzardMagicType == WizardType.Light && currentState != States.Bloomed) {
            // Bloom the flower for a light wizard
            BloomFlower();
            Debug.Log("Blooming Flower");
            doorObject.DoorOpen();
        } else if(player.wizzardMagicType == WizardType.Dark && currentState != States.Withered) {
            // Unbloom the flower for a dark wizard
            UnbloomFlower();
            doorObject.DoorOpen();
        }
    }

    private void BloomFlower() {
        _currentState = States.Bloomed;
        spriteRenderer.sprite = bloomedSprite;
    }

    private void UnbloomFlower() {
        _currentState = States.Withered;
        spriteRenderer.sprite = witheredSprite;
    }
}

public enum States {
    Null,
    Bloomed,
    Withered
}