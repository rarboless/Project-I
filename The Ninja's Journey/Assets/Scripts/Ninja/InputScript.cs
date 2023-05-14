using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputScript : MonoBehaviour {
    public Vector3 InputDetect() {
        Vector3 movement;

        movement = Vector3.zero;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement = new Vector3(movement.x, movement.y, 0).normalized;
        return movement;
    }
}