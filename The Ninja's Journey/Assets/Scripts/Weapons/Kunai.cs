using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Kunai : Weapons {
    private GameObject kunaiPrefab;

    // Start is called before the first frame update
    void Start() {
        damage = 10;
        fireForce = 10f;
        timeBetweenShots = 0.3f;
        kunaiPrefab = Resources.Load<GameObject>("Assets/Prefabs/Kunai.prefab");

        bulletPrefab = kunaiPrefab;
        weaponSprite.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Assets/Sprites/Kunai.png");
    }
}