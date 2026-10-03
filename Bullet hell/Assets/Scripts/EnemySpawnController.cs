using System.Collections;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] float spawnRate;
    [SerializeField] AstroidSpawner cannon;

    bool fireReady;
    void Start()
    {
        fireReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (fireReady)
        {
            fireReady = false;
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
               cannon.SpawnAstroid();
        yield return new WaitForSeconds(spawnRate);
        fireReady = true;
    }
}
