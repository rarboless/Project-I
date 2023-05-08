using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private Transform currentCheckpoint;
    private Health playerHealth;

    private void Awake() {
        Instance = this;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    public void Reset() {
        transform.position = currentCheckpoint.position;
        playerHealth.Respawn();

        CineMachineShake.Instance.ShakeCamera(5f, 0.1f, 0.5f);
    }

    public void SetCurrentCheckpoint(Transform checkpoint) {
        currentCheckpoint = checkpoint;
    }
}
