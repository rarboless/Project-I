using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour {
    protected int damage;
    protected float fireForce;
    protected float timeBetweenShots;

    public string type;
    
    public GameObject bulletPrefab;
    public Sprite weaponSprite;
}