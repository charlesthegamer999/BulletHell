using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] float lives;
    [SerializeField] GameObject player; // must be a PREFAB from the Project window, not an object in a scene

    PlayerHealth playerHealth;

    void Awake()
    {
        // Classic singleton: if one already exists (e.g. this scene has its own copy), remove the duplicate.
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        if (Instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            Instance = null;
        }
    }

    // Runs automatically every time a scene finishes loading, so SpaceStation doesn't need to tell us.
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameOver") return;
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        // Look these up fresh every time. Anything cached from the previous scene is destroyed by now.
        GameObject spawnPoint = GameObject.FindGameObjectWithTag("Respawn");
        if (spawnPoint == null)
        {
            Debug.LogError("No object tagged 'Respawn' in scene " + SceneManager.GetActiveScene().name);
            return;
        }

        GameObject playerClone = Instantiate(player, spawnPoint.transform.position, Quaternion.identity);

        CameraFollow cam = FindFirstObjectByType<CameraFollow>();
        if (cam != null) cam.AquireTarget(playerClone);
        else Debug.LogWarning("No CameraFollow found in scene.");

        // Use the clone we just made rather than FindGameObjectWithTag, which could still find a dying old player.
        playerHealth = playerClone.GetComponent<PlayerHealth>();
        playerHealth.health = 20;
        playerHealth.RestoreBars();
        UpdateLivesText();
    }

    void Update()
    {
        // playerHealth is null (Unity-style) whenever there's no live player, so this is safe between spawns.
        if (playerHealth == null) return;

        if (playerHealth.health <= 0)
        {
            playerHealth.killPlayer();
            playerHealth = null;
            RespawnPlayer();
        }
    }

    public void ChangeLives(float amount)
    {
        lives += amount;
        UpdateLivesText();
    }

    public void RespawnPlayer()
    {
        if (lives > 0)
        {
            ChangeLives(-1);
            SpawnPlayer();
        }
        else
        {
            Debug.Log("Game Over");
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }

    void UpdateLivesText()
    {
        if (playerHealth != null && playerHealth.LivesText != null)
            playerHealth.LivesText.text = "Redeploys: " + lives;
    }
}