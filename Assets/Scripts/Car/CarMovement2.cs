using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement2 : MonoBehaviour
{
    GameObject carToSpeedObj;
    private float speed;

    Animator animator;

    void Awake() {
        animator = GetComponent<Animator>();
        animator.SetBool("Pressed", true);
        carToSpeedObj = GameObject.FindGameObjectWithTag("CarToSpeed");
        if (carToSpeedObj != null) {
            CarToSpeed carToSpeed = carToSpeedObj.GetComponent<CarToSpeed>();
            if (carToSpeed != null) {
                speed = carToSpeed.GetSpeedForCar(gameObject);
            } else {
                UnityEngine.Debug.LogError("CarToSpeed script not found.");
            }
        } else {
            UnityEngine.Debug.LogError("CarToSpeed object not found with tag.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
