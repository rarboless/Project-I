using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Ninja : MonoBehaviour
{
    [SerializeField] private float velocity;
    private Vector3 movement;
    private Rigidbody2D ninjaRigidBody;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        ninjaRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementProcess();
    }

    void MovementProcess() {
        movement = Vector3.zero;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(movement != Vector3.zero) {
            ninjaRigidBody.MovePosition(transform.position + movement * velocity * Time.deltaTime);
            animator.SetFloat("moveX", movement.x);
            animator.SetFloat("moveY", movement.y);
            animator.SetBool("isWalking", true);
        }
        else {
            animator.SetBool("isWalking", false);
        }

        /*CODI ANTERIOR
        //ninjaRigidBody.velocity = new Vector2(movement.x * velocity, movement.y * velocity);
        //ninjaRigidBody.velocity.Normalize();


        animator.SetFloat("moveX", movement.x);
        animator.SetFloat("moveY", movement.y);
        animator.SetBool("isWalking", true);
        

        if (movement.x > 0) {
            //movement += Vector3.right;
            animator.SetBool("isRunningRight", true);
        }
        else { animator.SetBool("isRunningRight", false); }
            
        if (movement.x < 0) {
            //movement += Vector3.left;
            animator.SetBool("isRunningLeft", true);
        }
        else { animator.SetBool("isRunningLeft", false); }

        if (movement.y > 0) {
            //movement += Vector3.up;
            animator.SetBool("isRunningUp", true);
        }else { animator.SetBool("isRunningUp", false); }

        if (movement.y < 0) {
            //movement += Vector3.down;
            animator.SetBool("isRunningDown", true);
        }else {animator.SetBool("isRunningDown", false); }

        //movement.Normalize();
        //transform.position += movement * Time.deltaTime;
        */
    }
}
