using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private CinemachineVirtualCamera vcam;
    void Start() {
        var vcam = GetComponent<CinemachineVirtualCamera>();
        vcam.Follow = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
