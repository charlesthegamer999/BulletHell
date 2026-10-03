using UnityEngine;

public class AstroidSpawner : MonoBehaviour
{
    [SerializeField] GameObject astroidPrefab;
    [SerializeField] float speed;

    Transform spawnPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPoint = transform;
    }

    public void SpawnAstroid()
    {
        GameObject astroidClone = Instantiate(astroidPrefab);
        astroidClone.transform.position = spawnPoint.position;
        astroidClone.transform.rotation = spawnPoint.rotation;
        astroidClone.GetComponent<Rigidbody2D>().AddForce(transform.up * speed, ForceMode2D.Impulse);
    }
}
