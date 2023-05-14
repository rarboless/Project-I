using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private float checkPointX;
    private float checkPointY;

    void Start()
    {
        if(PlayerPrefs.GetFloat("checkPointX") != 0) {
            transform.position = new Vector2(PlayerPrefs.GetFloat("checkPointX"), PlayerPrefs.GetFloat("checkPointY"));
        }

        
    }
    
    public void ReachedCheackPoint(float x, float y) {
        PlayerPrefs.SetFloat("checkPointX", x);
        PlayerPrefs.SetFloat("checkPointY", y);
    }
}
