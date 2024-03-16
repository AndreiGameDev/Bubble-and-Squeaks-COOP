using System.Collections;
using UnityEngine;

public class Boulder : MonoBehaviour, IInteractable {
    Rigidbody2D rb;
    Collider2D col;
    [SerializeField] float speed = 4;
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    IEnumerator MoveBoulder(DirFacing direction, WizardType magicType) {
        Vector3 lastPos = transform.position;
        float pushForce = speed;
        if(magicType == WizardType.Dark) {
            pushForce *= -1;
        }
        switch(direction) {
            case DirFacing.Left:
                rb.velocity = Vector2.left * pushForce;
                break;
            case DirFacing.Right:
                rb.velocity = Vector2.right * pushForce;
                break;
            case DirFacing.Up:
                rb.velocity = Vector2.up * pushForce;
                break;
            case DirFacing.Down:
                rb.velocity = Vector2.down * pushForce;
                break;
        }
        yield return new WaitForFixedUpdate();
        if(Vector3.Distance(lastPos, transform.position) >= 0) {
            StartCoroutine(MoveBoulder(direction, magicType));
        } else {
            rb.velocity = Vector2.zero;
        }

    }
    public void Interact(PlayerRefferenceMaster player, DirFacing? direction = null) {
        if(!direction.HasValue) {
            Debug.LogError("Error, no direction input");
        } else {
            Debug.Log("Push");
            StartCoroutine(MoveBoulder(direction.Value, player.wizzardMagicType));
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
