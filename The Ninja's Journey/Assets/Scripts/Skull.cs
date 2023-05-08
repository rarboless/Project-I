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

    public int maxHealth = 3;
    private int hits = 0;
    public EnemyHealthBar healthBar;
    public float moveSpeed;
    private Rigidbody2D rb;

    void Start() {
        target = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
        healthBar.SetHealth(hits, maxHealth);
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        CheckDistance();
    }

    void CheckDistance() {
        target = GameObject.FindWithTag("Player").transform;

        animator.SetBool("isWalking", true);

        if (Vector2.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            //move with rb instead
            Vector2 temp = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            rb.MovePosition(temp);

            animator.SetFloat("moveX", movement.x);
            animator.SetFloat("moveY", movement.y);
        }
        else {
            transform.position = Vector2.MoveTowards(transform.position, homePosition.position, moveSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage() {
        maxHealth -= 1;
        hits--;
        if(maxHealth <= 0) {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.collider.CompareTag("Bullet")) {
            TakeDamage();
        }
    }
}
