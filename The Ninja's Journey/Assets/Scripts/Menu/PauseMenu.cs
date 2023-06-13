using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {
    [SerializeField] private GameObject pausePanel;

    [SerializeField] private Animator pauseMenuAnimator;
    private bool isOpen;

    // Start is called before the first frame update
    void Start() {
        pausePanel.SetActive(false);
        isOpen = false;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            isOpen = !isOpen;
            Debug.Log(isOpen);
            pauseMenuAnimator.SetBool("IsOpen", isOpen);
            Toggle();
        }
    }

    public void Toggle() {
        pausePanel.SetActive(!pausePanel.activeSelf);

        if (pausePanel.activeSelf) {
            Time.timeScale = 0f;
        }
        else {
            Time.timeScale = 1f;
        }
    }

    public void ToMainMenu() {
        SceneManager.LoadScene(4, LoadSceneMode.Single);
        Time.timeScale = 1f;
    }
}