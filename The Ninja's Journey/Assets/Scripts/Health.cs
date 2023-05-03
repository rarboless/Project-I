using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health = 3;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private void Update() {
        foreach(Image heart in hearts) {
            heart.sprite = emptyHeart;
        }
        for(int i = 0; i < health; i++) {
            hearts[i].sprite = fullHeart;
        }
        
        if(Input.GetKeyDown(KeyCode.Z)) {
            TakeDamage();
        }
        if(Input.GetKeyDown(KeyCode.X)) {
            Heal(1);
        }
    }

    public void TakeDamage() {
        health -= 1;
        if(health <= 0) {
            //---
        }
    }

    public void Heal(int heal) {
        health += heal;
        if(health > 3) {
            health = 3;
        }
    }
}
