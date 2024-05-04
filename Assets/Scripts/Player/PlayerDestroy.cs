using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroy : MonoBehaviour
{
  void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.CompareTag("Car"))
    {
      Destroy(gameObject);
    }
  }
}
