using TMPro.EditorUtilities;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] float lives;
    [SerializeField] GameObject player;

    GameObject playerSpawnPoint;
    PlayerHealth PlayerH;


    GameObject test;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        playerSpawnPoint = GameObject.FindGameObjectWithTag("Respawn");

   
        SpawnPlayer();
        PlayerH = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        test = GameObject.FindGameObjectWithTag("Player");

        PlayerH.LivesText.text = "Redeploys: " + lives;

    }


    public void SpawnPlayer()
    {
        

        GameObject playerClone = Instantiate(player, playerSpawnPoint.transform.position, Quaternion.identity);
       
        PlayerH = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        test = GameObject.FindGameObjectWithTag("Player");
       
        PlayerH.health = 20;
        PlayerH.RestoreBars();
    }
     //Update is called once per frame
    void Update()
    {
       if (PlayerH.health <= 0 && !PlayerH.isDead)
        {
            RespawnPlayer();
        }
    }

    public void ChangeLives(float amount)
    {
        lives += amount;
        PlayerH.LivesText.text = "Redeploys: " + lives;
       
    }

    public void RespawnPlayer()
    {
        if (lives > 0)
        {
            ChangeLives(-1);
            PlayerH.health = 20;
            PlayerH.RestoreBars();
            //  SpawnPlayer();
        }
        else
        {
            PlayerH.isDead = true;

            Debug.Log("Game Over");
            // Implement game over logic here (e.g., show game over screen, restart level, etc.)
        }
    }
}
