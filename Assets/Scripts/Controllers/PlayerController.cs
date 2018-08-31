using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

    public float walkSpeed;
    public float turnSpeed;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * walkSpeed;
        bool isWalking = z > 0.0f;
        bool isWalkingBackwards = z < 0.0f;

        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isWalkingBackwards", isWalkingBackwards);

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }
}
