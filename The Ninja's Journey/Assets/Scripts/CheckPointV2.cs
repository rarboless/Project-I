using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointV2 : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player" || collision.CompareTag("Player")) {
            Debug.Log("Checkpoint");

            collision.GetComponent<PlayerRespawn>().ReachedCheackPoint(transform.position.x, transform.position.y);
        }
    }
}
