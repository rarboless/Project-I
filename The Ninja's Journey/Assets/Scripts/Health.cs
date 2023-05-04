using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    public int health = 3;

    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;

    [SerializeField] private Ninja ninja;

    private void Update() {
        foreach (Image heart in hearts) {
            heart.sprite = emptyHeart;
        }
        for (int i = 0; i < health; i++) {
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
        if (health <= 0) {
            ninja.Die();
        }

        health -= 1;
    }

    public void Heal() {
        health += 1;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Enemy")) {
            TakeDamage();
        }
        if (collision.collider.CompareTag("Heal")) {
            health += 1;
            Destroy(collision.gameObject);
        }
    }
}