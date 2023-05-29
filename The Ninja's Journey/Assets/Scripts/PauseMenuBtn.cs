using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenuBtn : MonoBehaviour {
    [SerializeField] private GameObject pausePanel;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void OnPublicClick(PointerEventData eventData) {
        pausePanel.SetActive(true);
        Time.timeScale = 1f;
    }
}