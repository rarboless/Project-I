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

    private void Update() {
        foreach (Image heart in hearts) {
            heart.sprite = emptyHeart;
        }
        for (int i = 0; i < ninjaScript.health; i++) {
            hearts[i].sprite = fullHeart;
        }
        
        if (Input.GetKeyDown(KeyCode.Z)) {
            TakeDamage();
        }
        if (Input.GetKeyDown(KeyCode.X)) {
            Heal();
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

    public void Heal() {
        if (ninjaScript.health < 3) {
            ninjaScript.health += 1;
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
    }


    public void AddHealth(int value) {
        if (ninjaScript.health < 3) {
            ninjaScript.health += value;
        }
    }
}