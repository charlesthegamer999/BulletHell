using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceStation : MonoBehaviour
{

  public  PlayerCannon ammoData;
    public GameManager gm;
    [SerializeField] string sceneToLoad;
    private void Start()
    {
        ammoData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCannon>();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player has entered the space station.");
            Debug.Log(ammoData.ammoCount);
            SceneManager.LoadScene(sceneToLoad);
            gm.isNewScene = true;
            gm.SpawnPlayer();
            ammoData.ammoCount = 30;
            
        }
    }
}
