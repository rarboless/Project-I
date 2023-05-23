using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    [SerializeField] private GameObject pausePanel;

    // Start is called before the first frame update
    void Start() {
        pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void Continue() {

    }

    public void ToMainMenu() {
        SceneManager.LoadScene(4, LoadSceneMode.Single);
    }
}