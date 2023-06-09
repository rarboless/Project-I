using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FlameEnemy : Enemy {
    [Header("Propietats del Atac")]
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
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();

    }

    private void Update() {
        CheckDistance();

        Vector2 aimDirection = target.position - firePoint.transform.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        weapon.GetComponent<Rigidbody2D>().rotation = aimAngle;
        firePoint.GetComponent<UnityEngine.Transform>().position = weapon.GetComponent<UnityEngine.Transform>().position + (weapon.GetComponent<UnityEngine.Transform>().up * 0.3f);
    }

    void FixedUpdate() {
        Movement();
    }

    void Movement() {
        target = GameObject.FindWithTag("Player").transform;


        if (Vector2.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius) {
            movement = (target.position- transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

            animator.SetFloat("moveX", movement.x);
            animator.SetFloat("moveY", movement.y);
            animator.SetBool("isWalking", true);


            weapon.GetComponent<UnityEngine.Transform>().position = rb.position;
            firePoint.GetComponent<UnityEngine.Transform>().position = weapon.GetComponent<UnityEngine.Transform>().position + (weapon.GetComponent<UnityEngine.Transform>().up * 0.3f);
        }
        else {
            transform.position = Vector2.MoveTowards(transform.position, homePosition.position, moveSpeed * Time.deltaTime);
            animator.SetBool("isWalking", false);

        }
    }

    void CheckDistance() {
        if (Vector2.Distance(target.position, transform.position) <= attackRadius) {
            if (Time.time - timeOfLastShot >= timeBetweenShots) {
                Shoot();
                timeOfLastShot = Time.time;
            }
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
}