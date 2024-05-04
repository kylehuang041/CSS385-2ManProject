using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player GameObject
    public float followSpeed = 0.5f; // Speed at which camera follows the player
    public Vector3 offset = new Vector3(0, 25, 0); // Offset from the player position, setting the camera height along Z
    public float zoomSpeed = 1f; // Speed of zooming in and out
    public float minOrthographicSize = 5f; // Minimum zoom level
    public float maxOrthographicSize = 20f; // Maximum zoom level

    void LateUpdate()
    {
        if (player != null)
        {
            // Set the desired position by applying the offset to the player's position
            Vector3 desiredPosition = player.position + offset;
            // Interpolate smoothly between the current position and the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, followSpeed);
            transform.position = smoothedPosition;

            // Handle camera zoom via adjusting orthographic size based on mouse scroll input
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            Camera.main.orthographicSize -= scroll * zoomSpeed;
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minOrthographicSize, maxOrthographicSize);
        }
    }
}
