using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;
    public GameMaster gm;
    //public AudioClip coinSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            gm.AddPoints(value);
            //AudioSource.PlayClipAtPoint(coinSound, transform.position);
            Destroy(this.gameObject);
        }
    }
}
