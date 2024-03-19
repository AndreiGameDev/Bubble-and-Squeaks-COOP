using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementManager : MonoBehaviour
{
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
        if(inputVector != Vector2.zero ) {
            anim.SetBool("IsIdle", false);
            DirectionSetter();
            AnimationProperties();
            if(Vector3.Distance(transform.position, targetDistanceGO.transform.position) <= 4) {
                rb.velocity = inputVector * MoveSpeed;
            } else {
                rb.AddForceAtPosition(-inputVector * MoveSpeed / 2, transform.position, ForceMode2D.Impulse);
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
