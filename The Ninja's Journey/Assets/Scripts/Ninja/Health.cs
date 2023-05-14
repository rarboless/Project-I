using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    //public int health = 3; //public -> Ninja uses

    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;

    [SerializeField] private Ninja ninjaScript;
    //[SerializeField] private GameObject ninjaPrefab;
    //private GameObject ninja;

    [SerializeField] private CinemachineVirtualCamera vcam;

    [SerializeField] private Skull enemy;

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
    
    /*
    public void Respawn(Transform checkpointTransform) {
        AddHealth(3);
        ninja = Instantiate(ninjaPrefab, checkpointTransform.position, checkpointTransform.rotation);
        vcam.Follow = ninja.transform;
        enemy.target = ninja.transform;
        //ninjaScript.dead = false;
    }
    */
}