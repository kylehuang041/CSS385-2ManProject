using System.Security.AccessControl;
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CarToSpeed : MonoBehaviour
{
  public GameObject[] carPrefabs;
  private System.Random random;
  private Dictionary<GameObject, float> carToSpeed = new Dictionary<GameObject, float>();

  void Awake()
  {
    random = new System.Random();
    foreach (GameObject carPrefab in carPrefabs)
    {
      float randomSpeed = random.Next(7, 20);
      carToSpeed.Add(carPrefab, randomSpeed);
    }
    
  }

  public float GetSpeedForCar(GameObject car)
  {
    if (carToSpeed.ContainsKey(car))
    {
      return carToSpeed[car];
    }
    else
    {
      Debug.LogError("Car speed not found for GameObject: " + car.name);
      return 5f;
    }
  }
}