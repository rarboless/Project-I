using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour {
    [SerializeField] private GameObject finalPanel;

    private PauseMenu pmScript;

    void Start() {
        finalPanel.SetActive(false);
        pmScript = GameObject.FindGameObjectWithTag("Pause").GetComponent<PauseMenu>();
        pmScript.enabled = true;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            Toggle();
        }
    }

    public void Toggle() {
        finalPanel.SetActive(!finalPanel.activeSelf);

        if (finalPanel.activeSelf) {
            Time.timeScale = 0f;
        }
        else {
            Time.timeScale = 1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag(tag: "Player")) {
            Toggle();
            pmScript.enabled = false;
        }
    }
}