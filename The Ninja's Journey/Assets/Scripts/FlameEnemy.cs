using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FlameEnemy : Enemy {
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

    [SerializeField] private GameObject firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireForce;
    [SerializeField] private float timeBetweenShots;
    private float timeOfLastShot;
    private GameObject bullet;

    void Start() {
        target = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
        healthBar.SetHealth(hits, maxHealth);
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        CheckDistance();
        if (Vector2.Distance(target.position, transform.position) <= attackRadius) {
            if (Time.time - timeOfLastShot >= timeBetweenShots) {
                Debug.Log("efsg");
                Shoot();
                timeOfLastShot = Time.time;
            }
        }
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
        }
        else {
            transform.position = Vector2.MoveTowards(transform.position, homePosition.position, moveSpeed * Time.deltaTime);
        }
    }
    void Shoot() {
        //Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(target.position.y - rb.position.y, target.position.x - rb.position.x) * Mathf.Rad2Deg);

        bullet = Instantiate(bulletPrefab, firePoint.GetComponent<UnityEngine.Transform>().position, firePoint.GetComponent<UnityEngine.Transform>().rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.GetComponent<UnityEngine.Transform>().up * fireForce, ForceMode2D.Impulse);

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