using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2 : MonoBehaviour
{
  public Transform player; // Reference to the player GameObject
  public float followSpeed = 0.5f; // Speed at which camera follows the player
  public float zoomSpeed = 1f; // Speed of zooming in and out
  public float minOrthographicSize = 5f; // Minimum zoom level
  public float maxOrthographicSize = 20f; // Maximum zoom level

  void LateUpdate()
  {
    if (player != null)
    {
      // Set the desired Y position by adding the offset height to the player's Y position
      float desiredYPosition = player.position.y;
      // Interpolate smoothly between the current Y position and the desired Y position
      float smoothedYPosition = Mathf.Lerp(transform.position.y, desiredYPosition, followSpeed);

      // Set the new camera position with the updated Y position
      Vector3 newPosition = new Vector3(transform.position.x, smoothedYPosition, transform.position.z);
      transform.position = newPosition;

      // Handle camera zoom via adjusting orthographic size based on mouse scroll input
      float scroll = Input.GetAxis("Mouse ScrollWheel");
      Camera.main.orthographicSize -= scroll * zoomSpeed;
      Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minOrthographicSize, maxOrthographicSize);
    }
  }
}
