using UnityEngine;
//Implemented by Andrei
public class PlayerMovementManager : MonoBehaviour {
    [SerializeField]
    private float MoveSpeed = 1f;

    private Rigidbody2D rb;
    private Vector2 inputVector = Vector2.zero;
    PlayerRefferenceMaster playerRefMaster;
    Animator anim;

    [SerializeField] GameObject targetDistanceGO;
    [SerializeField] Vector2 maxDistanceApart;
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }
    private void Start() {
        playerRefMaster = GetComponent<PlayerRefferenceMaster>();
    }

    public void SetMovementDir(Vector2 direction) {
        inputVector = direction;
        inputVector.Normalize();
    }

    void Move() {
        if(inputVector != Vector2.zero) {
            anim.SetBool("IsIdle", false);
            DirectionSetter();
            AnimationProperties();

            // Calculate the distance between the future position and the target distance game object
            float distanceToTarget = Vector3.Distance(transform.position, targetDistanceGO.transform.position);

            // Check if the player will be within the threshold distance of 4 units after two steps
            if(distanceToTarget <= 5) {
                // If the future position is within the threshold distance, allow the player to move towards it
                rb.velocity = inputVector * MoveSpeed;
            } else {
                // If the future position would exceed the threshold distance, calculate a new movement vector towards the target
                Vector3 directionToTarget = (targetDistanceGO.transform.position - transform.position).normalized;
                rb.velocity = directionToTarget * (MoveSpeed * 4);
            }

        } else {
            anim.SetBool("IsIdle", true);
            rb.velocity = Vector2.zero;
        }
    }

    private void DirectionSetter() {
        if(inputVector.y > 0.5) {
            playerRefMaster.dirFacing = DirFacing.Up;
        } else if(inputVector.y < -.5) {
            playerRefMaster.dirFacing = DirFacing.Down;
        } else if(inputVector.x < -.5) {
            playerRefMaster.dirFacing = DirFacing.Left;
        } else if(inputVector.x > 0.5) {
            playerRefMaster.dirFacing = DirFacing.Right;
        }
    }

    void AnimationProperties() {
        anim.SetFloat("MoveX", inputVector.x);
        anim.SetFloat("MoveY", inputVector.y);
    }

    void Update() {
        Move();
    }
}
