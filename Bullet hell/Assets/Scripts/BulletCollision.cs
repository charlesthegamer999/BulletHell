using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    [SerializeField] float bulletDamage;
    public PlayerMovement playerMovement;
    private void Start()
    {
        PlayerMovement playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayerMovement playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
            collision.gameObject.GetComponent<EnemyHealth>().changeHealth(-bulletDamage);
            playerMovement.breakSound.Play();
            Destroy(gameObject);
        }
    }

    public void ChangeBulletDamage(float amount)
    {
        bulletDamage = amount;
    }
}
