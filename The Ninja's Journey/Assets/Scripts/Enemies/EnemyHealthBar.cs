using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour {
    [SerializeField] private Slider slider;
    [SerializeField] private Color low;
    [SerializeField] private Color high;
    [SerializeField] private Vector3 offset;

    public void SetHealth(int health, int maxHealth) {
        slider.gameObject.SetActive(health < maxHealth);
        slider.value = health;
        slider.maxValue = maxHealth;

        slider.fillRect.GetComponent<UnityEngine.UI.Image>().color = Color.Lerp(low, high, slider.normalizedValue);
    }

    // Update is called once per frame
    void Update() {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
        
    }
}