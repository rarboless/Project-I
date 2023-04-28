using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja2Move : MonoBehaviour {
    [SerializeField] private float velocity;
    /*[SerializeField] private GameObject firePoint;
    [SerializeField] private GameObject bullet;*/

    [SerializeField] private InputScript inputScript;

    private Vector3 movement;

    private Rigidbody2D rigidBody;

    private Animator animator;

    [SerializeField] private float shakeIntensity;
    [SerializeField] private float shakeFrequency;
    [SerializeField] private float shakeTime;

    // Start is called before the first frame update
    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update() {
        
    }


    void FixedUpdate() {
        MovementProcess();

        if (Input.GetMouseButtonDown(0)) {
            //Shoot();
        }
    }

    void MovementProcess() {
        movement = inputScript.InputDetect();

        if (movement != Vector3.zero) {
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

    /*void Shoot() {
        Vector3 v3;
        if (transform.localScale.x == 1.0f) {
            v3 = Vector3.right;
        }
        else {
            v3 = Vector3.left;
        }

        GameObject bala = Instantiate(bullet, transform.position + v3 * 0.2f, transform.rotation);
        Destroy(bala, 5f);
    }*/
}