using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    [SerializeField] private int sceneBuildIndex;
    [SerializeField] ChangeScene changeScene;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void Play() {
        sceneBuildIndex = 0;
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }

    public void Levels() {
        sceneBuildIndex = 5;
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }

    public void Settings() {
        
    }

    public void Quit() {
        Debug.Log("Exiting...");
        Application.Quit();
    }
}