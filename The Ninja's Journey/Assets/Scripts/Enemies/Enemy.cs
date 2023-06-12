using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public GameMaster gm;

    [Header("Propietats principals")]
    [SerializeField] public Transform target; //public -> Health
    [SerializeField] protected float chaseRadius;
    [SerializeField] protected float attackRadius;
    [SerializeField] public Transform homePosition;

    [Header("Moviment")]
    protected Vector3 movement;
    protected Animator animator;

    [Header("Estadístiques")]
    [SerializeField] protected float maxHealth;
    [SerializeField] protected float moveSpeed;

    [Header("SFX")]
    public AudioClip hitSFX;
    public AudioClip dieSFX;

    protected Rigidbody2D rb;

    protected BulletScript bs;

    void Start() {
        target = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }

    void Update() {
    }

    protected void TakeDamage() {
        if (maxHealth > 0) {
            maxHealth -= bs.damage;
            SoundManager.Instance.PlaySound(hitSFX);
        }
        if (maxHealth <= 0) {
            Die();
        }
    }

    protected void Die() {
        gm.AddPoints( 1);
        gm.AddEnemiesKilled( 1);
        Destroy(gameObject);
        SoundManager.Instance.PlaySound(dieSFX);
    }

    protected void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Bullet")) {
            bs = collision.collider.GetComponent<BulletScript>();
            TakeDamage();
        }
        if(collision.collider.CompareTag("Player") && this.gameObject.CompareTag("Tree")) {
            Destroy(this.gameObject);
        }
    }
}