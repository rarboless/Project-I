using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : Enemy { 
    void Start() {
        target = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
     
    }


    void FixedUpdate() {
        Movement();
    }

    void Movement() {
        target = GameObject.FindWithTag("Player").transform;

        animator.SetBool("isWalking", true);

        if (Vector2.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            Vector2 temp = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            rb.MovePosition(temp);

            animator.SetFloat("moveX", movement.x);
            animator.SetFloat("moveY", movement.y);
        }
        else {
            transform.position = Vector2.MoveTowards(transform.position, homePosition.position, moveSpeed * Time.deltaTime);
        }
    }
}