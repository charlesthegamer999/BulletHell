using TMPro.EditorUtilities;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] float lives;
    [SerializeField] GameObject player;

    GameObject playerSpawnPoint;
    PlayerHealth PlayerH;

    CameraFollow cam;


    GameObject test;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        playerSpawnPoint = GameObject.FindGameObjectWithTag("Respawn");

        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();

        SpawnPlayer();
      //  PlayerH = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        test = GameObject.FindGameObjectWithTag("Player");

        PlayerH.LivesText.text = "Redeploys: " + lives;

    }


    public void SpawnPlayer()
    {
        

        GameObject playerClone = Instantiate(player, playerSpawnPoint.transform.position, Quaternion.identity);
       cam.AquireTarget(playerClone);
        PlayerH = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        test = GameObject.FindGameObjectWithTag("Player");
       
        PlayerH.health = 20;
        PlayerH.RestoreBars();
    }
     //Update is called once per frame
    void FixedUpdate()
    {
        PlayerH = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        PlayerH.LivesText.text = "Redeploys: " + lives;
        if (PlayerH.health <= 0)
        {
            PlayerH.killPlayer();
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
              SpawnPlayer();
            PlayerH.LivesText.text = "Redeploys: " + lives;
        }
        else
        {
           

            Debug.Log("Game Over");
            // Implement game over logic here (e.g., show game over screen, restart level, etc.)
        }
    }
}
