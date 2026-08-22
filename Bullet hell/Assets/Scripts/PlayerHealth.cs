using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] float iframes;
    [SerializeField] SpriteRenderer playerGFX;
    bool canTakeDamage;

    void Start()
    {
        canTakeDamage = true;
    }

    public void ChangeHealth(float amount)
    {
        if (amount > 0 && canTakeDamage)
        {
            health += amount;
            canTakeDamage = false;
            StartCoroutine("FlashWhite");
            if(health <= 0)
            {
                Debug.Log("Player is dead");
                Destroy(gameObject, 0.5f);
            }

        }
    }


    IEnumerator FlashWhite()
    {
       Color originColor = playerGFX.color;

        playerGFX.color = Color.white;

        yield return new WaitForSeconds(iframes);

        playerGFX.color = originColor;
        canTakeDamage = true;
    }


}
