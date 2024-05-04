using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f; // Speed at which the player moves
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float vertical = Input.GetAxisRaw("Vertical"); // Get vertical input
        
        Vector3 movement = new Vector3(0, 0, vertical); // Create a movement vector
        rb.MovePosition(transform.position + speed * movement * Time.deltaTime);



    }
}
