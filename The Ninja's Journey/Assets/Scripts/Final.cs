using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour
{
    [SerializeField] private GameObject finalPanel;

    void Start() {
        finalPanel.SetActive(false);
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
        if(collision.CompareTag(tag: "Player")) {
            Toggle();
        }
    }


}
