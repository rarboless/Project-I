using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointV2 : MonoBehaviour
{
    private GameMaster gm;
    private Health playerHealth;

    void Start() {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();

    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player" || collision.CompareTag("Player")) {
            Debug.Log("Checkpoint");
            gm.lastCheckPointPos = transform.position;
        }
    }
}
