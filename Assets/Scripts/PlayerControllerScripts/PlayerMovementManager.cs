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
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
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
            AnimationManager();
            rb.velocity = inputVector * MoveSpeed;
        } else {
            rb.velocity = Vector2.zero;
        }

        
    }

    private void AnimationManager() {
        if(inputVector.y > 0.5) {
            // Play animation Up
            playerRefMaster.dirFacing = DirFacing.Up;
        } else if(inputVector.y < -.5) {
            // Play Animation Down
            playerRefMaster.dirFacing = DirFacing.Down;
        } else if(inputVector.x < -.5) {
            // PlayAnimation Left
            playerRefMaster.dirFacing = DirFacing.Left;
        } else if(inputVector.x > 0.5) {
            // Play Animation Right
            playerRefMaster.dirFacing = DirFacing.Right;
        }
    }

    void Update() {
        Move();
    }
    

}
