using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja2Move : MonoBehaviour {
    [SerializeField] private float velocity;

    [SerializeField] private GameObject firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireForce;
    [SerializeField] private GameObject weapon;

    [SerializeField] private InputScript inputScript;

    private Vector3 movement;
    private Vector2 mousePosition;


    private Rigidbody2D rigidBody;

    private Animator animator;

    [SerializeField] private float shakeIntensity;
    [SerializeField] private float shakeFrequency;
    [SerializeField] private float shakeTime;

    // Start is called before the first frame update
    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update() {
        
    }


    void FixedUpdate() {
        MovementProcess();

        if (Input.GetMouseButtonDown(1)) {
            Shoot();
        }

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void MovementProcess() {
        movement = inputScript.InputDetect();

        if (movement != Vector3.zero) {
            rigidBody.MovePosition(transform.position + movement * velocity * Time.deltaTime);
            weapon.GetComponent<Transform>().position = rigidBody.position;
            firePoint.GetComponent<Transform>().position = weapon.GetComponent<Transform>().position;

            animator.SetFloat("moveX", movement.x);
            animator.SetFloat("moveY", movement.y);
            animator.SetBool("isWalking", true);
        }
        else {
            animator.SetBool("isWalking", false);
        }

        if (Input.GetMouseButtonDown(0)) {
            CineMachineShake.Instance.ShakeCamera(shakeIntensity, shakeFrequency, shakeTime);
        }

        Vector2 aimDirection = mousePosition - rigidBody.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        weapon.GetComponent<Rigidbody2D>().rotation = aimAngle;
    }

    void Shoot() {
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mousePosition.y - rigidBody.position.y, mousePosition.x - rigidBody.position.x) * Mathf.Rad2Deg);
        GameObject bullet = Instantiate(bulletPrefab, firePoint.GetComponent<Transform>().position, rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.GetComponent<Transform>().up * fireForce, ForceMode2D.Impulse);
        
        Destroy(bullet, 5f);
    }
}