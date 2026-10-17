using System.Collections;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] float spawnRate;
    [SerializeField] AstroidSpawner cannon;
    [SerializeField] float spawnLimit;

    float totalSpawn;
    bool fireReady;
    void Start()
    {
        totalSpawn = 0;
        fireReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (fireReady && totalSpawn <= spawnLimit)
        {
            fireReady = false;
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
               cannon.SpawnAstroid();
        yield return new WaitForSeconds(spawnRate);
        totalSpawn += 1;
        fireReady = true;
    }
}
