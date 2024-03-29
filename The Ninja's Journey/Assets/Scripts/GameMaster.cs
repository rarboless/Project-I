using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    public int TotalPoints { get { return TotalPoints; } }
    public int points;
    public int health;
    public int currentWeapon;

    public int enemiesKilled;
    public float time;


    void Awake() {
        health = 3;
        points = 0;
        currentWeapon = 0;

        time = 0;
        enemiesKilled = 0;

        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(instance);
        } else {
            Destroy(gameObject);
        }
    }
    public void Update() {
        time += Time.deltaTime;
    }

    public void AddPoints(int pointsToAdd) {
        points += pointsToAdd;
    }

    public void AddEnemiesKilled(int number) {
        enemiesKilled += number;
    }

}
