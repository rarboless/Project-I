using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class CoinHUD : MonoBehaviour
{
    public TextMeshProUGUI pointsHUD;
    public TextMeshProUGUI pointsHUDFinal;
    public GameMaster gm;
    private int points;

    void Start() {
        //pointsHUD = GetComponent<TextMeshProUGUI>();
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }
    public void Update() {
        this.points = gm.points;
        pointsHUD.text = this.points.ToString();
        pointsHUDFinal.text = this.points.ToString(); 
        //pointsHUD.text = gmScript.TotalPoints.ToString(); 
    }
}
