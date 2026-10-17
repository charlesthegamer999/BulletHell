using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceStation : MonoBehaviour
{

  public  PlayerCannon ammoData;
    [SerializeField] string sceneToLoad;
    private void Start()
    {
        ammoData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCannon>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player has entered the space station.");
            Debug.Log(ammoData.ammoCount);
            ammoData.ammoCount = 30;
            
        }
    }
}
