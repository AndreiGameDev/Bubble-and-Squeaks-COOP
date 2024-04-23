using System.Collections;
using UnityEngine;
//Implemented by Andrei
public class Boulder : MonoBehaviour, IInteractable {
    Rigidbody2D rb;
    
    [SerializeField] float speed = 4;
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    IEnumerator MoveBoulder(DirFacing direction, WizardType magicType, bool hasRunAlready) {
        if(gameObject.layer != LayerMask.NameToLayer("Obstacles")) {
            gameObject.layer = LayerMask.NameToLayer("Obstacles");
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        Vector3 lastPos = transform.position;
        float pushForce = speed;
        if(magicType == WizardType.Dark) {
            pushForce *= -1;
        }
        switch(direction) {
            case DirFacing.Left:
                rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
                rb.velocity = Vector2.left * pushForce;
                break;
            case DirFacing.Right:
                rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
                rb.velocity = Vector2.right * pushForce;
                break;
            case DirFacing.Up:
                rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
                rb.velocity = Vector2.up * pushForce;
                break;
            case DirFacing.Down:
                rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
                rb.velocity = Vector2.down * pushForce;
                break;
        }
        yield return new WaitForFixedUpdate();
        // Need to wait one update in order to make sure the boulder has at least one frame to move it's position otherwise it stops velocity imedietally.
        if(hasRunAlready) {
            if(Vector3.Distance(lastPos, transform.position) > 0) {
                StartCoroutine(MoveBoulder(direction, magicType, true));
            } else {
                rb.velocity = Vector2.zero;
                gameObject.layer = LayerMask.NameToLayer("Default");
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
            }
        } else {
            StartCoroutine(MoveBoulder(direction,magicType, true));
        }
    }
    public void Interact(PlayerRefferenceMaster player, DirFacing? direction = null) {
        if(!direction.HasValue) {
            Debug.LogError("Error, no direction input");
        } else {
            Debug.Log("Push");
            StartCoroutine(MoveBoulder(direction.Value, player.wizzardMagicType, false));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision != null) {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("PressurePoint")) {
            BoulderLevelManager.Instance.PressurePointUpdate(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag("PressurePoint")) {
            BoulderLevelManager.Instance.PressurePointUpdate(false);
        }
    }
}
