using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;
    public GameMaster gm;
    public AudioClip coinSFX;

    void Start() {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            gm.AddPoints(value);
            Destroy(this.gameObject);
            SoundManager.Instance.PlaySound(coinSFX);
        }
    }
}
