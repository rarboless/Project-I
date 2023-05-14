using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using System.Diagnostics;
using UnityEngine.SceneManagement;

public class Ninja : MonoBehaviour {
    [Header("Moviment Ninja")]
    [SerializeField] private float velocity;
    private Vector3 movement;
    private Vector2 mousePosition;

    private Rigidbody2D rigidBody;
    private Animator animator;

    [Header("Scripts funcionals")]
    [SerializeField] private InputScript inputScript;

    [Header("Atac")]
    [SerializeField] private GameObject firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireForce;
    [SerializeField] private GameObject weapon;
    [SerializeField] private float timeBetweenShots;
    private float timeOfLastShot;
    private GameObject bullet;

    [Header("Camera Shake")]
    [SerializeField] private float shakeIntensity;
    [SerializeField] private float shakeFrequency;
    [SerializeField] private float shakeTime;

    //[HideInInspector] public bool dead = false;
    //[SerializeField] private CheckPoint checkPoint;
    //private CheckPointV2 checkPointV2;


    private GameMaster gm;

    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPos;
    }

    void FixedUpdate() {
        MovementProcess();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            CineMachineShake.Instance.ShakeCamera(shakeIntensity, shakeFrequency, shakeTime);
        }
        if (Input.GetMouseButtonDown(1)) {
            if(Time.time - timeOfLastShot >= timeBetweenShots) {
                Shoot();
                timeOfLastShot = Time.time;
            }
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        /*
        if (Input.GetKeyDown(KeyCode.R)) {
            Destroy(this.gameObject);
            checkPoint.Reset();
        }
        */
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 aimDirection = mousePosition - rigidBody.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        weapon.GetComponent<Rigidbody2D>().rotation = aimAngle;
        firePoint.GetComponent<UnityEngine.Transform>().position = weapon.GetComponent<UnityEngine.Transform>().position + (weapon.GetComponent<UnityEngine.Transform>().up * 0.3f);
    }

    void MovementProcess() {
        movement = inputScript.InputDetect();

        if(movement != Vector3.zero) {
            rigidBody.MovePosition(transform.position + movement * velocity * Time.deltaTime);

            animator.SetFloat("moveX", movement.x);
            animator.SetFloat("moveY", movement.y);
            animator.SetBool("isWalking", true);

            weapon.GetComponent<UnityEngine.Transform>().position = rigidBody.position;
            firePoint.GetComponent<UnityEngine.Transform>().position = weapon.GetComponent<UnityEngine.Transform>().position + (weapon.GetComponent<UnityEngine.Transform>().up * 0.3f);

        }
        else {
            animator.SetBool("isWalking", false);
        }
    }

    void Shoot() {
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mousePosition.y - rigidBody.position.y, mousePosition.x - rigidBody.position.x) * Mathf.Rad2Deg);
        
        bullet = Instantiate(bulletPrefab, firePoint.GetComponent<UnityEngine.Transform>().position, rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.GetComponent<UnityEngine.Transform>().up * fireForce, ForceMode2D.Impulse);

        Destroy(bullet, 5f);
    }

    public void Die() {
        animator.SetBool("isDead", true);
        rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;

        Destroy(this.gameObject, 2f);
        //dead = true;
        //wait 2 seconds until load the scene
        new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}