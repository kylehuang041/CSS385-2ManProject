using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Obstacle") {
            Debug.Log("We hit an obstacle!");

            SceneManager.LoadScene("SpawnManager");
        }
    }
}
