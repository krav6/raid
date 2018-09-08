using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float walkSpeed;
    public float turnSpeed;
    public float crawlSpeed;
    public float runSpeed;

    private Animator animator;

    private class StateManager
    {
        public Dictionary<string, bool> states;

        public StateManager(Animator animator)
        {
            states = new Dictionary<string, bool>();
            initializeAndSetAnimatorStates(animator);
        }

        private void initializeAndSetAnimatorStates(Animator animator)
        {
            initializeStates();
            setAnimatorStates(animator);
        }

        private void initializeStates()
        {
            states.Add("isCrouching", Input.GetKey(KeyCode.Q));
            states.Add("isMovingForward", Input.GetAxis("Vertical") > 0.0f);
            states.Add("isMovingBackward", Input.GetAxis("Vertical") < 0.0f);
            states.Add("isTurningRight", Input.GetAxis("Horizontal") > 0.0f);
            states.Add("isTurningLeft", Input.GetAxis("Horizontal") < 0.0f);
            states.Add("isRunning", !states["isCrouching"] && states["isMovingForward"] && Input.GetKey(KeyCode.LeftShift));
        }

        private void setAnimatorStates(Animator animator)
        {
            foreach (KeyValuePair<string, bool> state in states)
            {
                animator.SetBool(state.Key, state.Value);
            }
        }
    }

    private StateManager stateManager;

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

    void handleJumping(AnimatorStateInfo animatorInfo)
    {
        bool isJumping = this.isJumping(animatorInfo);
        if(isJumping)
        {
            animator.ResetTrigger("Jump");
            return;
        }

        if (!isJumping && !stateManager.states["isCrouching"] && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
        }
    }

    void handleVerticalMovement(AnimatorStateInfo animatorInfo)
    {
        if (isJumpingInPlace(animatorInfo))
        {
            return;
        }

        float movementSpeed = walkSpeed;
        if(stateManager.states["isCrouching"])
        {
            movementSpeed = crawlSpeed;
        }
        else if(stateManager.states["isRunning"])
        {
            movementSpeed = runSpeed;
        }

        var z = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;
        transform.Translate(0, 0, z);
    }

    void handleHorizontalMovement()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed;

        transform.Rotate(0, x, 0);
    }

    void FixedUpdate()
    {
        stateManager = new StateManager(animator);
        var animatorInfo = animator.GetCurrentAnimatorStateInfo(0);

        handleJumping(animatorInfo);
        handleVerticalMovement(animatorInfo);
        handleHorizontalMovement();
    }
}
