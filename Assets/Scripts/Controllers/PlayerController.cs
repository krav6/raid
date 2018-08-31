using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

    public float speed;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
        bool isWalking = z > 0.0f;
        bool isWalkingBackwards = z < 0.0f;

        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isWalkingBackwards", isWalkingBackwards);

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }
}
