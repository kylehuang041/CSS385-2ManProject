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
    spawnInterval = (float)random.Next(150, 350) / 100.0f;
  }

  void Start()
  {
    InvokeRepeating("SpawnCar", 0, spawnInterval);
  }

  void SpawnCar()
  {
    GameObject car = Instantiate(carPrefab, transform.position, Quaternion.identity);
    if (goLeft)
    {
      car.transform.Rotate(new Vector3(0, 0, 180));
    }
    car.AddComponent<CarDestroy>();
    car.AddComponent<CarMovement2>();
  }
}
