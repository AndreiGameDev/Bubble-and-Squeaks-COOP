using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerLever : MonoBehaviour, IInteractable {
    public Sprite bloomedSprite;
    public Sprite unbloomedSprite;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private bool isBloomed;
    [SerializeField] private bool correctFlower;
    private DoorPuzzle doorObject;
    public DoorPuzzle doorPuzzle { get { return doorObject; } set { doorObject = value; } }
    public bool isCorrectFlower {
        get { return correctFlower; }
    }
    public bool isFlowerBloomed {
        get { return isBloomed; }
    }

    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Interact(PlayerRefferenceMaster player) {
        // Check if the flower's state should change based on the player's type
        if(player.wizzardMagicType == WizardType.Light && !isBloomed) {
            // Bloom the flower for a light wizard
            BloomFlower();
            Debug.Log("Blooming Flower");
            doorObject.DoorOpen();
        } else if(player.wizzardMagicType == WizardType.Dark && isBloomed) {
            // Unbloom the flower for a dark wizard
            UnbloomFlower();
            doorObject.DoorOpen();
        }
        // If none apply, do nothing
    }

    private void BloomFlower() {
        isBloomed = true;
        spriteRenderer.sprite = bloomedSprite;
    }

    private void UnbloomFlower() {
        isBloomed = false;
        spriteRenderer.sprite = unbloomedSprite;
    }
}
