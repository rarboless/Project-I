using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : Enemy
{
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;

    private Vector3 movement;
    private Animator animator;

    public int health = 3;

    void Start() {
        target = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    private void Update() {
        CheckDistance();
    }

    void CheckDistance() {
        animator.SetBool("isWalking", true);

        if (Vector2.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            animator.SetFloat("moveX", movement.x);
            animator.SetFloat("moveY", movement.y);
        }
        else {
            transform.position = Vector2.MoveTowards(transform.position, homePosition.position, moveSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage() {
        health -= 1;
        if(health <= 0) {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.collider.CompareTag("Bullet")) {
            TakeDamage();
        }
    }
}
