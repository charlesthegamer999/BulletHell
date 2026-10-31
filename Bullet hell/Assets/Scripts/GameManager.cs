using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] float lives;
    [SerializeField] GameObject player;

    public bool isNewScene = false;

    GameObject playerSpawnPoint;
    PlayerHealth PlayerH;

    CameraFollow cam;


    GameObject test;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    
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
    void Update()
    {
        if(isNewScene == true)
        {
            SpawnPlayer();
            isNewScene = false;
        }
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
            SceneManager.LoadScene("GameOver");
            // Implement game over logic here (e.g., show game over screen, restart level, etc.)
        }
    }
}
