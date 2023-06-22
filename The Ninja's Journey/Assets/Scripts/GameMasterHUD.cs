using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameMasterHUD : MonoBehaviour {
    public TextMeshProUGUI enemiesKilledHUD;
    public TextMeshProUGUI timeHUD;
    public TextMeshProUGUI pointsHUDFinal;
    public GameMaster gm;

    private int enemiesKilled;
    private float time;
    private int points;

    void Start() {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }

    void Update() {
        this.enemiesKilled = gm.enemiesKilled;
        this.time = gm.time;
        this.time = (float) (Math.Round(time, 1));

        enemiesKilledHUD.text = this.enemiesKilled.ToString();
        this.points = gm.points;
        pointsHUDFinal.text = this.points.ToString();
        timeHUD.text = this.time.ToString();
    }
}