using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    int isIdleJumpHash;
    //int isJumpHash;

    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isIdleJumpHash = Animator.StringToHash("isIdleJump");
        //isJumpHash = Animator.StringToHash("isJump");
    }


    void FixedUpdate()
    {
        bool isWaliking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        bool isIdleJump = animator.GetBool(isIdleJumpHash);
        //bool isJump = animator.GetBool(isJumpHash);

        bool forwardPressed = Input.GetKey("w");
        bool backPressed = Input.GetKey("s");
        bool leftPressed = Input.GetKey("a");
        bool rightPressed = Input.GetKey("d");
        bool movingPressed = (forwardPressed || backPressed || leftPressed || rightPressed);
        bool runPressed = Input.GetKey("left shift");
        //bool jumpPressed = Input.GetKey("space");

        if (!isWaliking && movingPressed)
        {
            animator.SetBool(isWalkingHash, true);
        }
        if (isWaliking && !movingPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }

        if (!isRunning && (runPressed && movingPressed)) {
            animator.SetBool(isRunningHash, true);
        }
        if (isRunning && (!runPressed || !movingPressed))
        {
            animator.SetBool(isRunningHash, false);
        }
    }
}