using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroy : MonoBehaviour
{
  private Vector3 spawnPos;

  void Awake() {
    spawnPos = transform.position;
  }

  void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.CompareTag("Car"))
    {
      transform.position = spawnPos;
    }
  }
}
