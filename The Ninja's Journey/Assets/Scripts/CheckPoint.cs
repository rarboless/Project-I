using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {
    private Transform currentCheckpoint;
    private Health playerHealth;

    private void Awake() {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    public void Reset() {
        transform.position = currentCheckpoint.position;
        playerHealth.Respawn(currentCheckpoint);

        CineMachineShake.Instance.ShakeCamera(5f, 0.1f, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.transform.tag == "CheckPoint"){
            currentCheckpoint = collision.transform;
            collision.enabled = false;
            Debug.Log("as");
        }
    }
}