using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameMasterHUD : MonoBehaviour
{
    public TextMeshProUGUI enemiesKilledHUD;
    public TextMeshProUGUI timeHUD;
    public GameMaster gm;

    private int enemiesKilled;
    private float time;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }

    void Update()
    {
        this.enemiesKilled = gm.enemiesKilled;
        this.time = gm.time;
        this.time = (float) (Math.Round(time, 1));

        enemiesKilledHUD.text = this.enemiesKilled.ToString();
        timeHUD.text = this.time.ToString();
    }
}
