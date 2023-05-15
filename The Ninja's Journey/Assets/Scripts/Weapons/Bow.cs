using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bow : Weapons  {
    private GameObject arrowPrefab;

    void Start() {
        damage = 1;
        fireForce = 20f;
        timeBetweenShots = 0.3f;
        arrowPrefab = Resources.Load<GameObject>("Assets / Prefabs / Arrow.prefab");

        type = "Bow";

        bulletPrefab = arrowPrefab;
        weaponSprite.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Assets/Sprites/Sprite.png");
    }
}