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
    [SerializeField] protected Transform homePosition;

    [Header("Moviment")]
    protected Vector3 movement;
    protected Animator animator;

    [Header("Estadístiques")]
    [SerializeField] protected float maxHealth;
    [SerializeField] protected float moveSpeed;

    [Header("SFX")]
    public AudioClip hitSFX;
    public Coin coin;

    protected Rigidbody2D rb;

    protected BulletScript bs;

    void Start() {
        target = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        coin = GameObject.FindGameObjectWithTag("Coin").GetComponent<Coin>();
    }

    void Update() {
        
    }

    protected void TakeDamage() {
        if (maxHealth > 0) {
            maxHealth -= bs.damage;
        }
        if (maxHealth <= 0) {
            Die();
        }

        SoundManager.Instance.PlaySound(hitSFX);
    }

    protected void Die() {
        gm.AddPoints(pointsToAdd: 1);
        Destroy(gameObject);
        SoundManager.Instance.PlaySound(coin.coinSFX);
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