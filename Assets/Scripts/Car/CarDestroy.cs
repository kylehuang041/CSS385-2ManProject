using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDestroy : MonoBehaviour
{
    public float boundary = 15.0f;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > boundary || transform.position.x < -boundary)
        {
            Destroy(gameObject);
        }
    }
}
