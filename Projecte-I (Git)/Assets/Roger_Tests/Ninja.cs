using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : MonoBehaviour
{
    [SerializeField] private float velocity;
    private Rigidbody2D rb;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        MovementProcess();
    }

    void MovementProcess() {
        Vector3 movement = Vector3.zero;
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(inputHorizontal * velocity, inputVertical * velocity);

        if (inputHorizontal > 0) {
            //movement += Vector3.right;
            animator.SetBool("isRunningRight", true);
        }
        else if (inputHorizontal < 0) {
            //movement += Vector3.left;
            animator.SetBool("isRunningLeft", true);
        }
        else if (inputVertical > 0) {
            //movement += Vector3.up;
            animator.SetBool("isRunningUp", true);
        }
        else if (inputVertical < 0) {
            //movement += Vector3.down;
            animator.SetBool("isRunningDown", true);
        }
        else {
            animator.SetBool("isRunningDown", false);
            animator.SetBool("isRunningUp", false);
            animator.SetBool("isRunningLeft", false);
            animator.SetBool("isRunningRight", false);
        }
        rb.velocity = new Vector2(inputHorizontal * velocity, inputVertical * velocity);


        movement.Normalize();

        //Orientation();
        //rb.velocity.Normalize();
    }

    void Orientation() {
        if(Input.GetAxis("Horizontal") > 0) {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if(Input.GetAxis("Horizontal") < 0) {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetAxis("Vertical") > 0) {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetAxis("Vertical") < 0) {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
