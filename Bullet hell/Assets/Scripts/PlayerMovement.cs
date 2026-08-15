using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 200f;
    public Rigidbody2D rb;
 //   public float rotateInputForCannon;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Rotate with A/D
        float rotateInput = 0f;
        if (Input.GetKey(KeyCode.A)) rotateInput = 1f;
        if (Input.GetKey(KeyCode.D)) rotateInput = -1f;

     //   Quaternion currentQuaternion = transform.rotation;
        // Get the rotation of the player here to be used in the player cannon script
      //  Debug.Log("Rotate Input: " + currentQuaternion);

        transform.Rotate(0f, 0f, rotateInput * rotationSpeed * Time.deltaTime);

        // Move forward with W, in the direction the player is facing
        float moveInput = Input.GetKey(KeyCode.W) ? 1f : 0f;
        Vector2 moveDirection = transform.up * moveInput;
        rb.linearVelocity = moveDirection * speed;
 
    }
}