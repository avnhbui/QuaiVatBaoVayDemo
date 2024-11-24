using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjecTile : MonoBehaviour
{
    private Gun parentGun;
    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * parentGun.guns.fireSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.gameObject.GetComponent<Enemy>();
        if(enemy != null)
        {
            Destroy(gameObject);
            enemy.Hit(parentGun.guns.fireDamage);
        }
    }
    public void SetParentGun(Gun gun)
    {
        parentGun = gun;
    }
}
