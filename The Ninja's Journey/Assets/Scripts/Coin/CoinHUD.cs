using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class CoinHUD : MonoBehaviour
{
    public TextMeshProUGUI pointsHUD;
    public GameMaster gmScript;

    public void Update() {
        pointsHUD.text = gmScript.points.ToString(); 
        //pointsHUD.text = gmScript.TotalPoints.ToString(); 
    }
}
