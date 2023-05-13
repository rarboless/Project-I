using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : Enemy {
    public Transform target;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float rotateSpeed = 0.0025f;
    private Rigidbody2D rb;

    [SerializeField] private float Range = 5f;
    [SerializeField] private float distanceToStop = 3f; //L'enemic es deixarà de moure cap el jugador 

    [SerializeField] private Transform firePoint;

    [SerializeField] private float fireRate;
    private float timeToFire;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (!target) {
            GetTarget();
        }
        else {
            RotateTowardsTaarget();
        }

        if (Vector2.Distance(target.position, transform.position) <= distanceToStop) {
            Shoot();
        }
    }

    private void FixedUpdate() {
        if (Vector2.Distance(target.position, transform.position) >= distanceToStop) {
            //rb.velocity = transform.up * moveSpeed;

            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            //move with rb instead
            Vector2 temp = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            rb.MovePosition(temp);
        }
    }

    private void GetTarget() {
        if (GameObject.FindGameObjectWithTag("Player")) {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void RotateTowardsTaarget() {
        Vector2 targetDirection = target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion quaternion = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, quaternion, rotateSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            Destroy(collision.gameObject);
            target = null;
        }
        else if (collision.gameObject.CompareTag("Bullet")) {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void Shoot() {
        if (timeToFire <= 0f) {
            Debug.Log("Shoot");
            timeToFire = fireRate;
        }
        else {
            timeToFire -= Time.deltaTime;
        }
    }
}