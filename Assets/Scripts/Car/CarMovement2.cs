using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement2 : MonoBehaviour
{
    GameObject carToSpeedObj;
    private float speed;
    // Animator animator;

    void Awake()
    {
        carToSpeedObj = GameObject.FindGameObjectWithTag("CarToSpeedDict");
        if (carToSpeedObj != null)
        {
            CarToSpeed carToSpeed = carToSpeedObj.GetComponent<CarToSpeed>();
            if (carToSpeed != null)
            {
                SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
                if (renderer != null)
                {
                    speed = carToSpeed.GetSpeedForCar(renderer.sprite.name);
                }
                else
                {
                    UnityEngine.Debug.LogError("SpriteRenderer component not found on GameObject: " + gameObject.name);
                }
            }
            else
            {
                UnityEngine.Debug.LogError("CarToSpeed script not found on object: " + carToSpeedObj.name);
            }
        }
        else
        {
            UnityEngine.Debug.LogError("CarToSpeed object not found with tag.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
