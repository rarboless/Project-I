using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContinueBtn : MonoBehaviour, IPointerClickHandler {
    [SerializeField] private GameObject pausePanel;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void OnPointerClick(PointerEventData eventData) {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
}