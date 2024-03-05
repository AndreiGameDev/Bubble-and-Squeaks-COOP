using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileComponent : MonoBehaviour
{
    public DirFacing dirFacing;
    [SerializeField] private float projectileSpeed = 1f;
    Rigidbody2D rb;
    public PlayerRefferenceMaster player;
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
    Vector2 DirectionVector() {
        switch(dirFacing) {
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
    private void FixedUpdate() {
        rb.velocity = DirectionVector() * projectileSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        IInteractable spellInteraction = collision.GetComponent<IInteractable>();
        if(spellInteraction != null) {
            Destroy(gameObject);
            Debug.Log("Colliding");
            spellInteraction.Interact(player);
        } else {
            Destroy(gameObject);
        }
    }

}
