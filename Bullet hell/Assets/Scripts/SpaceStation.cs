using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceStation : MonoBehaviour
{
    [SerializeField] string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player has entered the space station.");
            // GameManager listens for the scene load and spawns the player itself.
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}