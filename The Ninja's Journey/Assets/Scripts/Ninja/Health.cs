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
    private int maxHealth = 3;

    private void Update() {
        foreach (Image heart in hearts) {
            heart.sprite = emptyHeart;
        }
        for (int i = 0; i < ninjaScript.health; i++) {
            hearts[i].sprite = fullHeart;
        }
    }

    public void TakeDamage() {
        ninjaScript.health -= 1;

        if (ninjaScript.health <= 0) {
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
        }
        else if (collision.CompareTag("AllHeal")) {
            AddAllHealth();
            Destroy(collision.gameObject);
        }
    }

    public void AddHealth(int value) {
        if(ninjaScript.health < 3) {
            ninjaScript.health += value;
        }
    }
    public void AddAllHealth() {
        if (HealthRemaining() == 1) {
            ninjaScript.health += 1;
        }
        else if (HealthRemaining() == 2) {
            ninjaScript.health += 2;
        }
    }

    public int HealthRemaining() {
        return maxHealth - ninjaScript.health;
    }
}