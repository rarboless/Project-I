using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.Timeline.Actions;

public class Ninja : MonoBehaviour {
    [Header("Movement Ninja")]
    [SerializeField] public float speed;
    private Vector3 movement;
    private Vector2 mousePosition;

    private Rigidbody2D rigidBody;
    private Animator animator;

    [Header("Scripts")]
    [SerializeField] private InputScript inputScript;

    [Header("Atac")]
    [SerializeField] private GameObject firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireForce;

    [SerializeField] private GameObject weaponGameObject;
    [SerializeField] private GameObject weaponSpriteObject;

    [SerializeField] private float timeBetweenShots;
    private float timeOfLastShot;
    private GameObject bullet;

    [Header("Bullet prefabs")]
    [SerializeField] private Sprite shurikenSprite;
    [SerializeField] private GameObject shurikenPrefab;
    [SerializeField] private Sprite bowSprite;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Sprite kunaiSprite;
    [SerializeField] private GameObject kunaiPrefab;

    [Header("SFX")]
    public AudioClip pickWeaponSFX;
    public AudioClip healSFX;
    public AudioClip hitSFX;
    public AudioClip bulletSFX;

    private GameMaster gm;

    public static Ninja instance;

    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }

    void FixedUpdate() {
        speed = ChangeSpeedOnHealth();
        MovementProcess();
    }

    private void Update() {
        Weapon();

        if (Input.GetMouseButtonDown(0)) {
            if (Time.time - timeOfLastShot >= timeBetweenShots) {
                if (gm.currentWeapon == 2) {
                    ShootKunai();
                }
                else {
                    Shoot();
                }
                
                timeOfLastShot = Time.time;
            }
        }

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 aimDirection = mousePosition - rigidBody.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        weaponGameObject.GetComponent<Rigidbody2D>().rotation = aimAngle;
        firePoint.GetComponent<UnityEngine.Transform>().position = weaponGameObject.GetComponent<UnityEngine.Transform>().position + (weaponGameObject.GetComponent<UnityEngine.Transform>().up * 0.3f);
    }

    void MovementProcess() {
        movement = inputScript.InputDetect();

        if (movement != Vector3.zero) {
            rigidBody.MovePosition(transform.position + movement * speed * Time.deltaTime);

            animator.SetFloat("moveX", movement.x);
            animator.SetFloat("moveY", movement.y);
            animator.SetBool("isWalking", true);

            weaponGameObject.GetComponent<UnityEngine.Transform>().position = rigidBody.position;
            firePoint.GetComponent<UnityEngine.Transform>().position = weaponGameObject.GetComponent<UnityEngine.Transform>().position + (weaponGameObject.GetComponent<UnityEngine.Transform>().up * 0.3f);

        }
        else {
            animator.SetBool("isWalking", false);
        }
    }

    void Shoot() {
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mousePosition.y - rigidBody.position.y, mousePosition.x - rigidBody.position.x) * Mathf.Rad2Deg);
        
        bullet = Instantiate(bulletPrefab, firePoint.GetComponent<UnityEngine.Transform>().position, rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.GetComponent<UnityEngine.Transform>().up * fireForce, ForceMode2D.Impulse);

        SoundManager.Instance.PlaySound(bulletSFX);

        Destroy(bullet, 5f);
    }

    void ShootKunai() {
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mousePosition.y - rigidBody.position.y, mousePosition.x - rigidBody.position.x) * Mathf.Rad2Deg);

        Vector3 secondaryBullets = new Vector3(0, 0, 90);

        bullet = Instantiate(bulletPrefab, firePoint.GetComponent<UnityEngine.Transform>().position, rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.GetComponent<UnityEngine.Transform>().up * fireForce, ForceMode2D.Impulse);
        bullet = Instantiate(bulletPrefab, firePoint.GetComponent<UnityEngine.Transform>().position + secondaryBullets , rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.GetComponent<UnityEngine.Transform>().up * fireForce, ForceMode2D.Impulse);
        bullet = Instantiate(bulletPrefab, firePoint.GetComponent<UnityEngine.Transform>().position - secondaryBullets, rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.GetComponent<UnityEngine.Transform>().up * fireForce, ForceMode2D.Impulse);

        SoundManager.Instance.PlaySound(bulletSFX);

        Destroy(bullet, 5f);
    }

    public void Die() {
        animator.SetBool("isDead", true);
        rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
        Invoke("Respawn", 2f);
    }

    private void Respawn() {
        Destroy(this.gameObject);
        gm.health = 3;
        gm.points = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    private float ChangeSpeedOnHealth() {
        if (gm.health == 2) {
            return 4f;
        }
        else if (gm.health == 1) {
            return 3f;
        }
        else {
            return 5f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Shuriken")) {
            gm.currentWeapon = 1;
            Destroy(collision.gameObject);
            SoundManager.Instance.PlaySound(pickWeaponSFX);
        }
        if (collision.CompareTag("Bow")) {
            gm.currentWeapon = 0;
            Destroy(collision.gameObject);
            SoundManager.Instance.PlaySound(pickWeaponSFX);
        }
        if (collision.CompareTag("Kunai")) {
            gm.currentWeapon = 2;
            Destroy(collision.gameObject);
            SoundManager.Instance.PlaySound(pickWeaponSFX);
        }
    }

    private void Weapon() {
        if (gm.currentWeapon == 2) {
            weaponSpriteObject.GetComponent<SpriteRenderer>().sprite = kunaiSprite;
            bulletPrefab = kunaiPrefab;
        }
        else if (gm.currentWeapon == 1) {
            weaponSpriteObject.GetComponent<SpriteRenderer>().sprite = shurikenSprite;
            bulletPrefab = shurikenPrefab;
        }
        else if (gm.currentWeapon == 0) {
            weaponSpriteObject.GetComponent<SpriteRenderer>().sprite = bowSprite;
            bulletPrefab = arrowPrefab;
        }
    }
}