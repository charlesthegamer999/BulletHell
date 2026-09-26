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
        if (damage < 0)
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakenDamage();
        }
        else
        {
            collision.gameObject.GetComponent<PlayerHealth>().HealDamage();
        }
        gameObject.SetActive(false);
        
    }
}
