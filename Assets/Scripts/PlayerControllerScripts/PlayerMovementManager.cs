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
            DirectionSetter();
            AnimationProperties();
            rb.velocity = inputVector * MoveSpeed;
        } else {
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
