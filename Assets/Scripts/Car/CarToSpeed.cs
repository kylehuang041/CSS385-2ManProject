using UnityEngine;
using System.Collections.Generic;

public class CarToSpeed : MonoBehaviour
{
  public GameObject[] carPrefabs;
  private System.Random random;
  private Dictionary<string, float> carToSpeed = new Dictionary<string, float>();

  void Awake()
  {
    random = new System.Random();
    foreach (GameObject carPrefab in carPrefabs)
    {
      SpriteRenderer renderer = carPrefab.GetComponent<SpriteRenderer>();
      if (renderer != null && renderer.sprite != null)
      {
        float randomSpeed = random.Next(7, 20);
        carToSpeed.Add(renderer.sprite.name, randomSpeed);
      }
      else
      {
        Debug.LogWarning("SpriteRenderer not found or sprite is null on GameObject: " + carPrefab.name);
      }
    }
  }

  public float GetSpeedForCar(string spriteName)
  {
    if (carToSpeed.ContainsKey(spriteName))
    {
      return carToSpeed[spriteName];
    }
    else
    {
      Debug.LogError("Speed not found for sprite: " + spriteName);
      return 5f; // or some default speed
    }
  }
}
