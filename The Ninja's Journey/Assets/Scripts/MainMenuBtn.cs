using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenuBtn : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void OnPointerClick(PointerEventData eventData) {
        SceneManager.LoadScene(4, LoadSceneMode.Single);
        Time.timeScale = 1f;
    }
}