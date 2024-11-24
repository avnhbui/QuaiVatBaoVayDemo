using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GunComponent : MonoBehaviour
{
    public GunInfor gunIf; 

    void Start()
    {
        if (gunIf != null)
        {
            gunSprite = gunIf.gunSprite;
            gunName = gunIf.gunName;
            fireDamage = gunIf.fireDamage;
            fireRate = gunIf.fireRate;
            fireRange = gunIf.fireRange;
            fireSpeed = gunIf.fireSpeed;
            lifeSteal = gunIf.lifeSteal;
            critRate = gunIf.critRate;
            critDmg = gunIf.critDmg;
            Debug.Log($"Gun equipped: {gunIf.gunName}");
        }
        else
        {
            Debug.LogWarning("GunSO is not assigned to the GunComponent.");
        }
    }
    public Sprite gunSprite;
    public string gunName;  
    public float fireDamage;
    public float fireRate;
    public float fireRange;
    public float fireSpeed;
    public float lifeSteal;
    public float critRate;
    public float critDmg;
}
