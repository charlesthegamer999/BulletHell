using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoxAttack : MonoBehaviour
{
    [SerializeField] float damage;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().ChangeHealth(damage);
     
        }
    }
}
