using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] SpriteRenderer enemyGFX;

    public void changeHealth(float amount)
    {
        health += amount;

        if(health <= 0)
        {
            enemyGFX.color = Color.red;
            Destroy(gameObject, 0.3f);
        }
        else
        {
            StartCoroutine("flashWhite");
        }
    }

    IEnumerator flashWhite()
    {
        Color originalColor = enemyGFX.color;

        enemyGFX.color = Color.white;

        yield return new WaitForSeconds(0.5f);
        enemyGFX.color = originalColor;
    }
}
