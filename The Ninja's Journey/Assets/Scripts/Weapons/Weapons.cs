using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour {
    protected int damage;
    protected float fireForce;
    protected float timeBetweenShots;
    protected string type;

    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected Sprite weaponSprite;
}