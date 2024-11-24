using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Guns", order = 1)]
public class GunInfor : ScriptableObject {
    public Sprite gunSprite;
    public string gunName;
    public int fireDamage;
    public float fireRate;
    public float fireRange;
    public float fireSpeed;
    public float lifeSteal;
    public float critRate;
    public float critDmg;
   
}
