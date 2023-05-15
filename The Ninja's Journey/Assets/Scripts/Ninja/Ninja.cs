using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Ninja : MonoBehaviour {
    [Header("Moviment Ninja")]
    [SerializeField] public float speed;
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
    [SerializeField] private GameObject weapon1;
    [SerializeField] private string weaponType;

    [SerializeField] private float timeBetweenShots;
    private float timeOfLastShot;
    private GameObject bullet;

    [Header("Bales prefabs")]
    [SerializeField] private Sprite shurikenSprite;
    [SerializeField] private GameObject shurikenPrefab;
    [SerializeField] private Sprite bowSprite;
    [SerializeField] private GameObject arrowPrefab;

    [Header("Camera Shake")]
    [SerializeField] private float shakeIntensity;
    [SerializeField] private float shakeFrequency;
    [SerializeField] private float shakeTime;

    //[SerializeField] private CheckPoint checkPoint;
    //private CheckPointV2 checkPointV2;

    public int health = 3;

    private GameMaster gm;
    private Bow bowScript;
    private Shuriken shurikenScript;


    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPos;

        weaponType = "Bow";
    }

    void FixedUpdate() {
        speed = ChangeSpeedOnHealth();
        MovementProcess();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            CineMachineShake.Instance.ShakeCamera(shakeIntensity, shakeFrequency, shakeTime);
        }
        if (Input.GetMouseButtonDown(1)) {
            if (Time.time - timeOfLastShot >= timeBetweenShots) {
                Shoot();
                timeOfLastShot = Time.time;
            }
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKeyDown(KeyCode.M)) {
            //Manera Dolenta pero funciona (S'ha de passar manualment al script els sprites i gameObjects)
            weapon1.GetComponent<SpriteRenderer>().sprite = shurikenSprite;
            bulletPrefab = shurikenPrefab;

            //Manera bona pero no funciona (Script amb Path dels archis)
            //weapon1.GetComponent<SpriteRenderer>().sprite = shurikenScript.weaponSprite;
            //bulletPrefab = shurikenScript.shurikenPrefab;

        }
        if (Input.GetKeyDown(KeyCode.N)) {
            //Manera Dolenta pero funciona (S'ha de passar manualment al script els sprites i gameObjects)
            weapon1.GetComponent<SpriteRenderer>().sprite = bowSprite;
            bulletPrefab = arrowPrefab;

            //Manera bona pero no funciona (Script amb Path dels archis)
            //weapon1.GetComponent<SpriteRenderer>().sprite = bowScript.weaponSprite;
            //bulletPrefab = bowScript.arrowPrefab;
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

        if (movement != Vector3.zero) {
            rigidBody.MovePosition(transform.position + movement * speed * Time.deltaTime);

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
        Invoke("Respawn", 2f);
    }

    private void Respawn() {
        Destroy(this.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    private float ChangeSpeedOnHealth() {
        if (health == 2) {
            return 4f;
        }
        else if(health == 1) {
            return 3f;
        }
        else {
            return 5f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("WeaponPick")) {
            Destroy(collision.gameObject);
            if (collision.GetComponent<Weapons>().type.Equals("Shuriken") && !weaponType.Equals("Shuriken")) {
                bulletPrefab = collision.GetComponent<Weapons>().bulletPrefab;
                weapon1.GetComponent<SpriteRenderer>().sprite = collision.GetComponent<Weapons>().weaponSprite;
            }
            else if (collision.GetComponent<Weapons>().type.Equals("Bow") && !weaponType.Equals("Bow")) {
                bulletPrefab = collision.GetComponent<Weapons>().bulletPrefab;
                weapon1.GetComponent<SpriteRenderer>().sprite = collision.GetComponent<Weapons>().weaponSprite;
            }
        }
    }
}