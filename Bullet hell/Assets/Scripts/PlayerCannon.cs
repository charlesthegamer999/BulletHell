using System.Collections;
using UnityEngine;

public class PlayerCannon : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    [SerializeField] float damageValue;
    [SerializeField] float bulletSpeed;
    [SerializeField] Transform firePoint; // drag the FirePoint child here in Inspector
    [SerializeField] float ammoCount;
    public float attackCooldown = 0f;

    PlayerMovement playerMove;
    bool fireReady;

    void Start()
    {
        fireReady = true;
        playerMove = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && fireReady && ammoCount > 0)
        {
            StartCoroutine(Fire());
        }
    }

    IEnumerator Fire()
    {
        Debug.Log("Firing");
        fireReady = false;

        // Use the player's current rotation directly - no need to pass an angle in from PlayerMovement
        GameObject bulletClone = Instantiate(Bullet, firePoint.position, transform.rotation);
        BulletMove bm = bulletClone.GetComponent<BulletMove>();
        if (bm != null)
        {
            bm.SetBulletSpeed(bulletSpeed);
        }

        ammoCount--;
        yield return new WaitForSeconds(attackCooldown);
        fireReady = true;
    }
}