using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    [SerializeField] private GameObject gunPrefab; 
    private Transform playerTransform; 
    private List<Vector3> gunPositions = new List<Vector3>(); 
    public static GunManager Instance { get; set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        playerTransform = GameObject.Find("Player").transform; 
        SetupGunPositions();
        InstantiateGuns(); 
    }

    public void ResetEquippedGuns()
    {
        for (int i = 0; i < GameData.equippedGuns.Length; i++)
        {
            GameData.equippedGuns[i] = null; 
        }
    }

    private void SetupGunPositions()
    {
        gunPositions.Add(new Vector3(-1.47f, 0.74f, 0f)); // vtri Equip1
        gunPositions.Add(new Vector3(1.47f, 0.74f, 0f));  // vtri Equip2
        gunPositions.Add(new Vector3(-1.47f, -0.74f, 0f));// vtri Equip3
        gunPositions.Add(new Vector3(1.47f, -0.74f, 0f)); // vtri Equip4
    }

    private void InstantiateGuns()
    {
        for (int i = 0; i < GameData.equippedGuns.Length; i++)
        {
            GunInfor gunIf = GameData.GetEquippedGun(i);

            if (gunIf != null)
            {
                GameObject gun = Instantiate(gunPrefab, playerTransform);
                gun.transform.localPosition = gunPositions[i];
                gun.name = gunIf.gunName;
                Gun gunComponent = gun.GetComponent<Gun>();
                if (gunComponent != null)
                {
                    gunComponent.guns = gunIf;
                    // tim goj con Sprite cua gunPrefab
                    Transform spriteTransform = gun.transform.Find("Sprite");
                    if (spriteTransform != null)
                    {
                        SpriteRenderer gunSpriteRenderer = spriteTransform.GetComponent<SpriteRenderer>();
                        if (gunSpriteRenderer != null)
                        {
                            gunSpriteRenderer.sprite = gunIf.gunSprite;
                        }
                        else
                        {
                            Debug.LogWarning("gunspriteRender null");
                        }
                    }
                    else
                    {
                        Debug.LogWarning("sprite null");
                    }
                }
                else
                {
                    Debug.LogWarning($"gun prefab {gun.name} loi");
                }
            }
            else
            {
                Debug.Log("ko co sung dc equip");
            }
        }
    }




}

