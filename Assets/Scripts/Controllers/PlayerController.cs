using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

    public float walkSpeed;
    public float turnSpeed;
    public float crawlSpeed;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    bool isJumpingInPlace(AnimatorStateInfo animatorInfo)
    {
        return Animator.StringToHash("Base Layer.Jump.Jumping in place") == animatorInfo.fullPathHash;
    }

    bool isJumpingForward(AnimatorStateInfo animatorInfo)
    {
        return Animator.StringToHash("Base Layer.Jump.Forward Jump") == animatorInfo.fullPathHash;
    }

    bool isJumpingBackward(AnimatorStateInfo animatorInfo)
    {
        return Animator.StringToHash("Base Layer.Jump.Backward Jump") == animatorInfo.fullPathHash;
    }

    bool isJumping(AnimatorStateInfo animatorInfo)
    {
        return isJumpingInPlace(animatorInfo) || isJumpingForward(animatorInfo) || isJumpingBackward(animatorInfo);
    }

    void handleJumping(bool isCrouching, AnimatorStateInfo animatorInfo)
    {
        bool isJumping = this.isJumping(animatorInfo);
        if(isJumping)
        {
            animator.ResetTrigger("Jump");
            return;
        }

        if (!isJumping && !isCrouching && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
        }
    }

    void handleVerticalMovement(bool isCrouching, AnimatorStateInfo animatorInfo)
    {
        if(isJumpingInPlace(animatorInfo))
        {
            return;
        }

        float movementSpeed = isCrouching ? crawlSpeed : walkSpeed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;

        animator.SetBool("isMovingForward", z > 0.0f);
        animator.SetBool("isMovingBackward", z < 0.0f);
        transform.Translate(0, 0, z);
    }

    void handleHorizontalMovement()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed;

        animator.SetBool("isTurningLeft", x < 0.0f);
        animator.SetBool("isTurningRight", x > 0.0f);

        transform.Rotate(0, x, 0);
    }

    void FixedUpdate()
    {
        var animatorInfo = animator.GetCurrentAnimatorStateInfo(0);

        bool isCrouching = Input.GetKey(KeyCode.Q);
        animator.SetBool("isCrouching", isCrouching);

        handleJumping(isCrouching, animatorInfo);
        handleVerticalMovement(isCrouching, animatorInfo);
        handleHorizontalMovement();

        bool isStanding = !isCrouching && !isJumping(animatorInfo);
        animator.SetBool("isStanding", isStanding);
    }
}
