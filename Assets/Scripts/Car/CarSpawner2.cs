using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner2 : MonoBehaviour
{
  public GameObject carPrefab;
  public bool goLeft = false;
  private float spawnInterval = 2.0f;
  System.Random random;

  void Awake()
  {
    random = new System.Random();
    spawnInterval = (float)random.Next(150, 300) / 100.0f;
  }

  void Start()
  {
    InvokeRepeating("SpawnCar", 0, spawnInterval);
  }

  void SpawnCar()
  {
    GameObject car = Instantiate(carPrefab, transform.position, Quaternion.identity);
    // Adjust the sorting order of the car to render above the roads
    Renderer carRenderer = car.GetComponent<Renderer>();
    if (carRenderer != null)
    {
      // Find all GameObjects with the "Road" tag
      GameObject[] roads = GameObject.FindGameObjectsWithTag("Road");

      // Initialize maxSortingOrder with the lowest possible value
      int maxSortingOrder = int.MinValue;

      // Loop through each road GameObject
      foreach (GameObject road in roads)
      {
        // Get the Renderer component of the road
        Renderer roadRenderer = road.GetComponent<Renderer>();

        // Check if the Renderer component exists and update maxSortingOrder if needed
        if (roadRenderer != null && roadRenderer.sortingOrder > maxSortingOrder)
        {
          maxSortingOrder = roadRenderer.sortingOrder;
        }
      }

      // Set the sorting order of the car to be higher than the roads
      carRenderer.sortingOrder = maxSortingOrder + 1;
    }
    else
    {
      Debug.LogError("Renderer component not found on car prefab.");
    }
    if (goLeft)
    {
      car.transform.Rotate(new Vector3(0, 0, 180));
    }
    car.AddComponent<CarDestroy>();
    car.AddComponent<CarMovement>();
  }
}
