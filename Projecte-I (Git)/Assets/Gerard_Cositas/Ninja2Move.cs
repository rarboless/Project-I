using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja2Move : MonoBehaviour {
    [SerializeField] private float velocity;
    [SerializeField] private GameObject firePoint;
    [SerializeField] private GameObject bullet;

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

        if (Input.GetMouseButtonDown(0)) {
            Shoot();
        }
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

    void Shoot() {
        Vector3 v3;
        if (transform.localScale.x == 1.0f) {
            v3 = Vector3.right;
        }
        else {
            v3 = Vector3.left;
        }

        GameObject bala = Instantiate(bullet, transform.position + v3 * 0.2f, transform.rotation);
        Destroy(bala, 5f);
    }
}