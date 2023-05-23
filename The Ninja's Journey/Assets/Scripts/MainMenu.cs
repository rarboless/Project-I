using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    [SerializeField] private int sceneBuildIndex;
    [SerializeField] private ChangeScene changeScene;

    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject settingsPanel;

    // Start is called before the first frame update
    void Start() {
        settingsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void Play(int index) {
        sceneBuildIndex = index;
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }

    public void Levels() {
        sceneBuildIndex = 5;
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }

    public void Settings() {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void Quit() {
        Debug.Log("Exiting...");
        Application.Quit();
    }

    public void Back() {
        mainMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }
}