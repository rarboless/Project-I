using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    public int TotalPoints { get { return TotalPoints; } }
    public int points;
    public int health;


    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(instance);
        } else {
            Destroy(gameObject);
        }
    }

    public void AddPoints(int pointsToAdd) {
        points += pointsToAdd;
        Debug.Log("Points: " + points);
    }
}
