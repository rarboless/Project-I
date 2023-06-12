using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class CoinHUD : MonoBehaviour
{
    public TextMeshProUGUI pointsHUD;
    public GameMaster gm;
    private int points;

    void Start() {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }
    public void Update() {
        this.points = gm.points;
        pointsHUD.text = this.points.ToString();
    }
}
