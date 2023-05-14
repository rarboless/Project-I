using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Propietats principals")]
    [SerializeField] public Transform target; //public -> Health
    [SerializeField] protected float chaseRadius;
    [SerializeField] protected float attackRadius;
    [SerializeField] protected Transform homePosition;

    [Header(header: "Moviment")]
    protected Vector3 movement;
    protected Animator animator;

    [Header(header: "Estadístiques")]
    [SerializeField] protected int maxHealth;
    [SerializeField] protected float moveSpeed;
    protected int hits = 0;
    protected Rigidbody2D rb;

    void Start() {
        target = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {

    }
    protected void TakeDamage() {
        maxHealth -= 1;
        hits--;
        if (maxHealth <= 0) {
            Destroy(gameObject);
        }
    }

    protected void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Bullet")) {
            TakeDamage();
        }
    }


}
