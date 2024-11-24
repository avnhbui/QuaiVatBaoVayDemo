using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] float moveSpeed = 6;
    [SerializeField] FixedJoystick joystick; // joystick
    public GameObject dieInfor;
    Animator animator;
    Rigidbody2D rb;
    int maxHealth = 100;
    int currrentHealth;
    bool dead = false;
    Vector2 movement;
    int facingDirection = 1; // 1 phai, -1 trai

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currrentHealth = maxHealth;
        healthText.text = currrentHealth.ToString();
        dieInfor.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Hit(10);
        }
        if (dead)
        {
            movement = Vector2.zero;
            animator.SetFloat("Velo", 0);
            return;
        }

        float moveHorizontal = joystick.Horizontal;
        float moveVertical = joystick.Vertical;

        movement = new Vector2(moveHorizontal, moveVertical).normalized;
        animator.SetFloat("Velo", movement.magnitude);

        if (movement.x != 0)
        {
            facingDirection = movement.x > 0 ? 1 : -1;
            transform.localScale = new Vector2(facingDirection, 1);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = movement * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            Hit(20);
        }
    }

    void Hit(int dmg)
    {
        animator.SetTrigger("Hit");
        currrentHealth -= dmg;
        healthText.text = Mathf.Clamp(currrentHealth, 0, maxHealth).ToString();
        if (currrentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        dead = true;
        dieInfor.SetActive(true);
        Time.timeScale = 0;
        GunManager.Instance.ResetEquippedGuns();
    }
}
