using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    [SerializeField] private int sceneBuildIndex;

    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject levelsPanel;
    
    // Start is called before the first frame update
    void Start() {
        settingsPanel.SetActive(false);
        levelsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void Play(int index) {
        sceneBuildIndex = index;
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }

    public void Levels() {
        mainMenuPanel.SetActive(false);
        levelsPanel.SetActive(true);
    }

    public void Settings() {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void Quit() {
        Debug.Log("Exiting...");
        Application.Quit();
    }

    public void Back(GameObject panel) {
        mainMenuPanel.SetActive(true);
        panel.SetActive(false);
    }
}