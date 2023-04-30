using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Ninja : MonoBehaviour {
    [Header("Moviment Ninja")]
    [SerializeField] private float velocity;
    private Vector3 movement;
    private Vector2 mousePosition;

    private Rigidbody2D rigidBody;
    private Animator animator;

    [SerializeField] private InputScript inputScript;

    [Header("Atac")]
    [SerializeField] private GameObject firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireForce;
    [SerializeField] private GameObject weapon;

    [Header("Camera Shake")]
    [SerializeField] private float shakeIntensity;
    [SerializeField] private float shakeFrequency;
    [SerializeField] private float shakeTime;

    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate() {
        MovementProcess();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            CineMachineShake.Instance.ShakeCamera(shakeIntensity, shakeFrequency, shakeTime);
        }
        if (Input.GetMouseButtonDown(1)) {
            Shoot();
        }

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 aimDirection = mousePosition - rigidBody.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        weapon.GetComponent<Rigidbody2D>().rotation = aimAngle;
    }

    void MovementProcess() {
        movement = inputScript.InputDetect();

        if(movement != Vector3.zero) {
            rigidBody.MovePosition(transform.position + movement * velocity * Time.deltaTime);
            weapon.GetComponent<UnityEngine.Transform>().position = rigidBody.position;
            firePoint.GetComponent<UnityEngine.Transform>().position = weapon.GetComponent<UnityEngine.Transform>().position;


            animator.SetFloat("moveX", movement.x);
            animator.SetFloat("moveY", movement.y);
            animator.SetBool("isWalking", true);
        }
        else {
            animator.SetBool("isWalking", false);
        }
    }

    void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.GetComponent<UnityEngine.Transform>().position, bulletPrefab.GetComponent<UnityEngine.Transform>().rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.GetComponent<UnityEngine.Transform>().up * fireForce, ForceMode2D.Impulse);

        Destroy(bullet, 5f);
    }
}