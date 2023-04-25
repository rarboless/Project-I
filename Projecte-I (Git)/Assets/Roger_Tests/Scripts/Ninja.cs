using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Ninja : MonoBehaviour
{
    [SerializeField] private float velocity;
    private Vector3 movement;
    private Rigidbody2D rigidBody;
    private Animator animator;

    [SerializeField] private float shakeIntensity;
    [SerializeField] private float shakeFrequency;
    [SerializeField] private float shakeTime;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovementProcess();
    }

    private void Update() {

    }

    void MovementProcess() {
        movement = Vector3.zero;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(movement != Vector3.zero) {
            rigidBody.MovePosition(transform.position + movement * velocity * Time.deltaTime);

            animator.SetFloat("moveX", movement.x);
            animator.SetFloat("moveY", movement.y);
            animator.SetBool("isWalking", true);
        }
        else {
            animator.SetBool("isWalking", false);
        }

        if (Input.GetMouseButtonDown(0)) {
            CineMachineShake.Instance.ShakeCamera(shakeIntensity, shakeFrequency, shakeTime);
        }
    }
}
