using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f; // Speed at which the player moves
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        float vertical = Input.GetAxisRaw("Vertical"); // Get vertical input
        float horizontal = Input.GetAxisRaw("Horizontal"); // Get vertical input

        // Calculate the movement direction based on the input values
        Vector3 movement = new Vector3(horizontal, vertical, 0f).normalized;

        // Move the player GameObject
        transform.Translate(movement * speed * Time.fixedDeltaTime);
    }
}
