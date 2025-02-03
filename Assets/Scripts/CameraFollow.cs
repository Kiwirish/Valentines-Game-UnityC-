using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.125f;  // Lower = smoother camera
    public Vector3 offset = new Vector3(0, 2, -10);  // Offset camera slightly above player

    void LateUpdate()
    {
        if (player == null) return;

        // Calculate desired position
        Vector3 desiredPosition = player.position + offset;

        // Smoothly move camera
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
