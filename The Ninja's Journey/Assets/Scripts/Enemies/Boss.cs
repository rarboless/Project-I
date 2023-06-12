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

        if (Vector2.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            Vector2 temp = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            rb.MovePosition(temp);
        }
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

    protected void Die() {
        Destroy(gameObject);
        gm.AddEnemiesKilled(1);
        SpawnCoins();
        SpawnFinalObject();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Bullet")) {
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
        const float spawnInterval = 5.0f;

        while (true) {
            yield return new WaitForSeconds(spawnInterval);

            SpawnSkulls();
        }
    }

    private void SpawnSkulls() {
        //spawn skulls every 5 seconds 
        const float spawnRadius = 3.0f;
        Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = transform.position + new Vector3(randomOffset.x, randomOffset.y, 0.0f);

        GameObject skull = Instantiate(skullPrefab, spawnPosition, Quaternion.identity);


    }

    private void SpawnFinalObject() {
        Final.SetActive(true);
    }
}
