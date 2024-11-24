using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] GameObject muzzel;
    [SerializeField] Transform muzzelPos;
    [SerializeField] GameObject projectile;

    [Header("Config")]
    public GunInfor guns;
    private SpriteRenderer spriteRenderer;
    [SerializeField] float fireDistance;
    [SerializeField] float fireRate = 0.5f;

    Transform closestEnemy; 
    private float timeSinceLastShot = 0f;
    int limitShot = 0;
    private bool isDelaying = false;
    Animator animator;

    public static Gun Instance { get; set; }

    private void Start()
    {
        animator = GetComponent<Animator>();
        timeSinceLastShot = guns.fireRate;
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (guns != null && spriteRenderer != null)
        {
            spriteRenderer.sprite = guns.gunSprite;
        }
    }

    private void Update()
    {
        FindClosestEnemy();
        AimEnemy();
        Shooting();
    }

    void FindClosestEnemy()
    {
        closestEnemy = null;
        float closestDistance = Mathf.Infinity;
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance && distance < guns.fireRange)
            {
                closestDistance = distance;
                closestEnemy = enemy.transform;
            }
        }
    }

    void Shooting()
    {
        if (closestEnemy != null)
        {
            timeSinceLastShot += Time.deltaTime;
            if (timeSinceLastShot > guns.fireRate)
            {
                Shoot();
                timeSinceLastShot = 0;
            }
        }
    }

    void Shoot()
    {
        if (limitShot < 8)
        {
            var muzzltGo = Instantiate(muzzel, muzzelPos.position, transform.rotation);
            muzzltGo.transform.SetParent(transform);
            Destroy(muzzltGo, 0.05f);
            var projectileGo = Instantiate(projectile, muzzelPos.position, transform.rotation);
            projectileGo.GetComponent<ProjecTile>().SetParentGun(this);
            limitShot++;
            Destroy(projectileGo, 3f);
        }
        else if (!isDelaying) 
        {
            StartCoroutine(DeLayShot(2f));
        }
    }

    void AimEnemy()
    {
        if (closestEnemy != null)
        {
            Vector3 direction = closestEnemy.position - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    IEnumerator DeLayShot(float delay)
    {
        isDelaying = true;
        yield return new WaitForSeconds(delay);
        limitShot = 0; 
        isDelaying = false;
    }
}
