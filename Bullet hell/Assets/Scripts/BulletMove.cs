using UnityEngine;

public class BulletMove : MonoBehaviour
{

    [SerializeField] float speed; // Speed of the bullet  
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * speed);
        Destroy(gameObject, 5f); // Destroy the bullet after 5 seconds
    }

public void SetBulletSpeed(float amount)
    {
        speed = amount;
    }
}
