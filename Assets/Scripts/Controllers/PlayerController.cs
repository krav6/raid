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

    void FixedUpdate()
    {
        bool isCrouching = Input.GetKey(KeyCode.Q);
        //TODO: Consider falling
        bool isStanding = !isCrouching;

        float movementSpeed = isCrouching ? crawlSpeed : walkSpeed;
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;

        bool isMovingForward = z > 0.0f;
        bool isMovingBackward = z < 0.0f;
        bool isTurningLeft = x < 0.0f;
        bool isTurningRight = x > 0.0f;

        animator.SetBool("isMovingForward", isMovingForward);
        animator.SetBool("isMovingBackward", isMovingBackward);
        animator.SetBool("isTurningLeft", isTurningLeft);
        animator.SetBool("isTurningRight", isTurningRight);
        animator.SetBool("isCrouching", isCrouching);
        animator.SetBool("isStanding", isStanding);

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }
}
