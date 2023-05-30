using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;
    [SerializeField] private Ninja ninjaScript;
    private GameMaster gm;
    private int maxHealth = 3;

    [Header("Camera Shake")]
    private float shakeIntensity = 5;
    private float shakeFrequency = 5;
    private float shakeTime = 0.5f;

    void Start () {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }

    private void Update() {
        foreach (Image heart in hearts) {
            heart.sprite = emptyHeart;
        }
        for (int i = 0; i < gm.health; i++) {
            hearts[i].sprite = fullHeart;
        }
    }

    public void TakeDamage() {
        gm.health -= 1;
        SoundManager.Instance.PlaySound(ninjaScript.hitSFX);
        CineMachineShake.Instance.ShakeCamera(shakeIntensity, shakeFrequency, shakeTime);


        if (gm.health <= 0) {
            foreach (Image heart in hearts) {
                heart.sprite = emptyHeart;
            }
            ninjaScript.Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Enemy")) {
            TakeDamage();
        }
        if (collision.collider.CompareTag("FlameBullet")) {
            TakeDamage();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Heal")) {
            AddHealth(1);
            Destroy(collision.gameObject);
            SoundManager.Instance.PlaySound(ninjaScript.healSFX);
        }
        else if (collision.CompareTag("AllHeal")) {
            AddAllHealth();
            Destroy(collision.gameObject);
            SoundManager.Instance.PlaySound(ninjaScript.healSFX);
        }
    }

    public void AddHealth(int value) {
        if(gm.health < 3) {
            gm.health += value;
        }
    }
    public void AddAllHealth() {
        if (HealthRemaining() == 1) {
            gm.health += 1;
        }
        else if (HealthRemaining() == 2) {
            gm.health += 2;
        }
    }

    public int HealthRemaining() {
        return maxHealth - gm.health;
    }
}