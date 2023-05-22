using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
    [SerializeField] private string scene;
    [SerializeField] ChangeScene changeScene;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void Play() {
        scene = "Exterior";
        changeScene.FadeTo(scene);
    }

    public void Levels() {

    }

    public void Settings() {

    }

    public void Quit() {
        Debug.Log("Exiting...");
        Application.Quit();
    }
}