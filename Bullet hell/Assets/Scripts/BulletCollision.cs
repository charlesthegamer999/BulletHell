using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    [SerializeField] float bulletDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHealth>().changeHealth(-bulletDamage);
            Destroy(gameObject);
        }
    }

    public void ChangeBulletDamage(float amount)
    {
        bulletDamage = amount;
    }
}
