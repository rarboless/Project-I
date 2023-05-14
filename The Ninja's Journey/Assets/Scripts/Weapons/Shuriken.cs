using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shuriken : Weapons 
{
    public GameObject shurikenPrefab;

    void Start() {
        damage = 1;
        fireForce = 20f;
        timeBetweenShots = 0.3f;
        shurikenPrefab = Resources.Load<GameObject>("Assets/Prefabs/Shuriken.prefab");
        
        bulletPrefab = shurikenPrefab;
        weaponSprite.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Assets/Sprites/Shuriken.png");
    }

}
