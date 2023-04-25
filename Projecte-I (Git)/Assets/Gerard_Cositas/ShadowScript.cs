using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowScript : MonoBehaviour {
    [SerializeField] private GameObject ninja;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (ninja != null) {
            Vector3 position = transform.position;
            position.x = ninja.transform.position.x;
            position.y = ninja.transform.position.y - 0.37f;
            transform.position = position;
        }
    }
}