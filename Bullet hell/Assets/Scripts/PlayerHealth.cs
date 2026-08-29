using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   public /* [SerializeField]*/ float health;
    [SerializeField] float iframes;
    [SerializeField] SpriteRenderer playerGFX;
    bool canTakeDamage;
    [SerializeField] GameObject[] HealthBars;

    void Start()
    {
        canTakeDamage = true;
    }

    private void Update()
    {
        if (health <= 0)
        {
            Debug.Log("Player is dead");
            Destroy(gameObject, 0.5f);
        }
    }

    public void ChangeHealth(float amount)
    {
        if (amount > 0 && canTakeDamage)
        {
            health += amount;
            canTakeDamage = false;
            StartCoroutine("FlashWhite");
            

        }
    }

    public void TakenDamage()
    {
        int BarsLost = 0;
        Debug.Log("You Have Been Hit");
        canTakeDamage = false;
        HealthBars[BarsLost].SetActive(false);
        BarsLost++;
        StartCoroutine("FlashWhite");
    }


    IEnumerator FlashWhite()
    {
       Color originColor = playerGFX.color;

        playerGFX.color = Color.orange;

        yield return new WaitForSeconds(iframes);

        playerGFX.color = originColor;
        canTakeDamage = true;
    }


}
