using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
    /*private Rigidbody2D Rigidbody2D;
    private Vector3 direction;

    [SerializeField] private float bulletSpeed;*/

    // Start is called before the first frame update
    void Start() {
        //Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        //Rigidbody2D.velocity = direction * bulletSpeed;
    }

    /*public void setDirection(Vector2 direccio) {
        direction = direccio;
    }*/

    private void OnCollisionEnter2D(Collision2D collision) {
        Destroy(gameObject);
    }
}