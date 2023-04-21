using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja2Move : MonoBehaviour {
    [SerializeField] private float velocity;

    private Rigidbody2D ninjaRigidBody;
    private Animator animator;

    // Start is called before the first frame update
    void Start() {
        ninjaRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        MovementProcess();
    }

    void MovementProcess() {
        Vector3 movement;

        movement = Vector3.zero;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement != Vector3.zero) {
            ninjaRigidBody.MovePosition(transform.position + movement * velocity * Time.deltaTime);
            animator.SetFloat("moveX", movement.x);
            animator.SetFloat("moveY", movement.y);
            animator.SetBool("isWalking", true);
        }
        else {
            animator.SetBool("isWalking", false);
        }
    }
}