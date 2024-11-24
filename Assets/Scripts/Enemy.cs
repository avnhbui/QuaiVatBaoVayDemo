using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] int maxHealth = 100;
    [SerializeField] float speed = 2f;

    [Header("Charger")]
    [SerializeField] bool isCharger;
    [SerializeField] float distanceToCharge = 5f;
    [SerializeField] float chargeSpeed = 4f;
    [SerializeField] float prepareTime = 2f;
    bool isCharging = false;
    bool isPrepareCharge = false;
    private int currentHealth;
    Animator animator;
    Transform target;
    Rigidbody2D rb;
    int killCounter = 0;
    private void Start()
    {
        currentHealth = maxHealth;
        target = GameObject.Find("Player").transform;
        animator = GetComponent<Animator>();

    }
    private void Update()
    {
        if (!WaveManager.instance.WaveRunning()) return;
        if (isPrepareCharge) return;
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            direction.Normalize();
            transform.position += direction * speed * Time.deltaTime;
            var playerToTheRight = target.position.x > transform.position.x;
            transform.localScale = new Vector2(playerToTheRight ? -1 : 1, 1);
        }
        if(isCharger && !isCharging && Vector2.Distance(transform.position, target.position) < distanceToCharge)
        {
            isPrepareCharge = true;
            Invoke("StartCharging", prepareTime);
        }

    }
    void StartCharging()
    {
        isPrepareCharge = false ;
        isCharging = true ;
        speed = chargeSpeed;
    }
    public void Hit(int dmg)
    {
        currentHealth -= dmg;
        animator.SetTrigger("Hit");
        DamagePopup.Create(transform.position, dmg);
        if (currentHealth <= 0 )
        {
            Destroy(gameObject);
            KillManager.Instance.AddKill();
        }
    }
}
