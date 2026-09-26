using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
   public float health;
    public TMP_Text LivesText;
    [SerializeField] float iframes;
    [SerializeField] SpriteRenderer playerGFX;
    bool canTakeDamage;
    public bool isDead = true;
    float BarsLost = 0;
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
            if (isDead == true) { 
             Destroy(gameObject, 0.5f);
                isDead = false;
            }
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
        
        Debug.Log("You Have Been Hit");
        canTakeDamage = false;
        HealthBars[(int)BarsLost].SetActive(false);
        BarsLost++;
        Debug.Log("You have lost" + BarsLost);
        StartCoroutine("FlashWhite");
    }


    public void HealDamage()
    {
        int BarsLost = 0;
        Debug.Log("You Have Been Healed");
        canTakeDamage = false;
        HealthBars[BarsLost].SetActive(true);
        BarsLost--;
        StartCoroutine("FlashWhite");
    }

    public void RestoreBars()
    {
        for (int i = 0; i < HealthBars.Length; i++)
        {
            HealthBars[i].SetActive(true);
        }
        BarsLost = 0;
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
