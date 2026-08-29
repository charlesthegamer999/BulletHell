using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoxAttack : MonoBehaviour
{
    [SerializeField] float damage;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        collision.gameObject.GetComponent<PlayerHealth>().health += damage;
        collision.gameObject.GetComponent<PlayerHealth>().TakenDamage();
        gameObject.SetActive(false);
        if (collision.gameObject.CompareTag("Player"))
        {
            

        }
    }
}
