using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private Transform currentCheckpoint;
    private Health playerHealth;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        }else if(Instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

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
