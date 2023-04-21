using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

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
    private void FixedUpdate() {
    }

    void MovementProcess() {
        Vector3 movement = Vector3.zero;
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        if (inputHorizontal > 0) {
            //movement += Vector3.right;
            animator.SetBool("isRunningRight", true);
        }
        else { animator.SetBool("isRunningRight", false); }
            
        if (inputHorizontal < 0) {
            //movement += Vector3.left;
            animator.SetBool("isRunningLeft", true);
        }
        else { animator.SetBool("isRunningLeft", false); }

        if (inputVertical > 0) {
            //movement += Vector3.up;
            animator.SetBool("isRunningUp", true);
        }else { animator.SetBool("isRunningUp", false); }

        if (inputVertical < 0) {
            //movement += Vector3.down;
            animator.SetBool("isRunningDown", true);
        }else {animator.SetBool("isRunningDown", false); }
        rb.velocity = new Vector2(inputHorizontal * velocity, inputVertical * velocity);
        movement.Normalize();
        //transform.position += movement * Time.deltaTime;
        //rb.velocity.Normalize();
    }
}
