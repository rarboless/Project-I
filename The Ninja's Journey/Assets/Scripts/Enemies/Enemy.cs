using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
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
    public AudioClip dieSFX;

    protected Rigidbody2D rb;

    protected BulletScript bs;

    void Start() {
        
    }

    void Update() {

    }

    protected void TakeDamage() {
        if (maxHealth <= 0) {
            AudioManager.Instance.PlaySound(dieSFX);
            Destroy(gameObject);
        }else if (maxHealth > 0) {
            maxHealth -= bs.damage;
            AudioManager.Instance.PlaySound(hitSFX);
        }
    }

    protected void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Bullet")) {
            bs = collision.collider.GetComponent<BulletScript>();
            TakeDamage();
        }
    }
}