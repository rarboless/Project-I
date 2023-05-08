using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    public int health = 3;

    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;

    [SerializeField] private Ninja ninjaScript;
    [SerializeField] private GameObject ninjaPrefab;
    private GameObject ninja;

    [SerializeField] private CinemachineVirtualCamera vcam;

    [SerializeField] private Skull enemy;

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
        if (health <= 1) {
            ninjaScript.Die();
            foreach (Image heart in hearts) {
                heart.sprite = emptyHeart;
            }
        }

        health -= 1;
    }

    public void Heal() {
        if (health < 3) {
            health += 1;
        }
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

    public void AddHealth(int value) {
        if (health < 3) {
            health += value;
        }
    }

    public void Respawn(Transform checkpointTransform) {
        AddHealth(3);
        ninja = Instantiate(ninjaPrefab, checkpointTransform.position, checkpointTransform.rotation);
        vcam.Follow = ninja.transform;
        enemy.target = ninja.transform;

    }
}