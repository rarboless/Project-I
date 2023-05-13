using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FlameEnemy : Enemy {
    [Header("Propietats principals")]
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;

    [Header("Moviment")]
    private Vector3 movement;
    private Animator animator;

    [Header("Estadístiques")]
    public int maxHealth = 3;
    private int hits = 0;
    public float moveSpeed;
    private Rigidbody2D rb;

    [Header("Atac stuff")]
    [SerializeField] private GameObject firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireForce;
    [SerializeField] private GameObject weapon;
    [SerializeField] private float timeBetweenShots;
    private float timeOfLastShot;
    private GameObject bullet;

    void Start() {
        target = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        CheckDistance();
        if (Vector2.Distance(target.position, transform.position) <= attackRadius) {
            if (Time.time - timeOfLastShot >= timeBetweenShots) {
                Shoot();
                timeOfLastShot = Time.time;
            }
        }

        Vector2 aimDirection = target.position - firePoint.transform.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        weapon.GetComponent<Rigidbody2D>().rotation = aimAngle;
        firePoint.GetComponent<UnityEngine.Transform>().position = weapon.GetComponent<UnityEngine.Transform>().position + (weapon.GetComponent<UnityEngine.Transform>().up * 0.3f);
    }

    void CheckDistance() {
        target = GameObject.FindWithTag("Player").transform;

        animator.SetBool("isWalking", true);

        if (Vector2.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            //move with rb instead
            Vector2 temp = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            //rb.MovePosition(temp);

            animator.SetFloat("moveX", movement.x);
            animator.SetFloat("moveY", movement.y);

            weapon.GetComponent<UnityEngine.Transform>().position = rb.position;
            firePoint.GetComponent<UnityEngine.Transform>().position = weapon.GetComponent<UnityEngine.Transform>().position + (weapon.GetComponent<UnityEngine.Transform>().up * 0.3f);
        }
        else {
            transform.position = Vector2.MoveTowards(transform.position, homePosition.position, moveSpeed * Time.deltaTime);
        }
    }

    void Shoot() {
        Vector2 direction = target.position - firePoint.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        bullet = Instantiate(bulletPrefab, firePoint.transform.position, rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(direction.normalized * fireForce, ForceMode2D.Impulse);

        Destroy(bullet, 5f);
    }

    public void TakeDamage() {
        maxHealth -= 1;
        hits--;
        if (maxHealth <= 0) {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Bullet")) {
            TakeDamage();
        }
    }
}