using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameMaster gm;

    [Header("Propietats principals")]
    [SerializeField] public Transform target; //public -> Health
    [SerializeField] private float chaseRadius;
    [SerializeField] private float attackRadius;

    [Header("Moviment")]
    private Vector3 movement;
    private Animator animator;

    [Header("Estadístiques")]
    [SerializeField] private float health;
    [SerializeField] private float maxHealth = 11;
    [SerializeField] private float moveSpeed;

    [Header("SFX")]
    public AudioClip hitSFX;

    [Header("Prefabs")]
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private GameObject skullPrefab;

    [SerializeField] HealthBar healthBar;
    [SerializeField] GameObject Final;

    private Rigidbody2D rb;

    private BulletScript bs;

    private bool canDash = true; 
    private float dashCooldown = 5.0f;


    private void Awake() {
        healthBar = GetComponentInChildren<HealthBar>();
    }

    void Start() {
        target = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        healthBar.UpdateHealthBar(health, maxHealth);
        StartCoroutine(SpawnSkullsCoroutine());
    }


    void FixedUpdate() {
        Movement();
    }

    void Movement() {

        target = GameObject.FindWithTag("Player").transform;

        if (Vector2.Distance(target.position, transform.position) <= chaseRadius) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            Vector2 temp = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            rb.MovePosition(temp);
        }

        if (Vector2.Distance(target.position, transform.position) <= attackRadius && canDash) {
            StartCoroutine(PerformDash());
        }

    }
    private IEnumerator PerformDash() {
        canDash = false;
        Vector2 dashDirection = (target.position - transform.position).normalized;
        float dashDuration = 0.5f; 
        float dashSpeed = moveSpeed * 4.0f;

        float dashTimer = 0f;

        while (dashTimer < dashDuration) {
            transform.position += (Vector3)dashDirection * dashSpeed * Time.deltaTime;
            dashTimer += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(dashCooldown);

        canDash = true; 
    }
    
    private void TakeDamage() {
        if (health > 0) {
            health -= bs.damage;
            healthBar.UpdateHealthBar(health, maxHealth);
        }
        if (health <= 0) {
            Die();
        }

        SoundManager.Instance.PlaySound(hitSFX);
    }

    private void Die() {
        Destroy(gameObject);
        gm.AddEnemiesKilled(1);
        SpawnCoins();
        SpawnFinalObject();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Bullet") || collision.collider.CompareTag("KunaiBullet")) {
            bs = collision.collider.GetComponent<BulletScript>();
            TakeDamage();
        }
    }

    private void SpawnCoins() {
        const int numCoins = 10;
        const float spawnRadius = 2.0f;

        for (int i = 0; i < numCoins; i++) {
            Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;
            Vector3 spawnPosition = transform.position + new Vector3(randomOffset.x, randomOffset.y, 0.0f);

            GameObject coin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
        }
    }

    private IEnumerator SpawnSkullsCoroutine() {
        const float spawnInterval = 3.0f;

        while (true) {
            yield return new WaitForSeconds(spawnInterval);

            SpawnSkull();
        }
    }

    private void SpawnSkull() {
        float spawnRadius = 3.0f;

        Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = transform.position + new Vector3(randomOffset.x, randomOffset.y, 0.0f);

        GameObject skull = Instantiate(skullPrefab, spawnPosition, Quaternion.identity);
        Enemy skullEnemy = skull.GetComponent<Enemy>();
        skullEnemy.homePosition = target;
    }

    private void SpawnFinalObject() {
        Final.SetActive(true);
    }
}
