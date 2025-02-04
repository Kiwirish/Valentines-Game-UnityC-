using System.Collections;
using System.Collections.Generic;
//using UnityEngine;

//public class CameraFollow : MonoBehaviour
//{
//    public Transform player;
//    public float smoothSpeed = 0.125f;  // Lower = smoother camera
//    public Vector3 offset = new Vector3(0, 2, -10);  // Offset camera slightly above player

//    void LateUpdate()
//    {
//        if (player == null) return;

//        // Calculate desired position
//        Vector3 desiredPosition = player.position + offset;

//        // Smoothly move camera
//        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
//        transform.position = smoothedPosition;
//    }
//}

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.125f;
    public Vector3 offset = new Vector3(0, 2, -10);

    private Camera cam;
    private float startTime;
    private float zoomDuration = 2f;
    private float startSize;
    private float zoomSize = 2f;  // How close to zoom in
    private float normalSize = 8f; // Your normal camera size
    private bool isZooming = true;

    void Start()
    {
        cam = GetComponent<Camera>();
        startTime = Time.time;
        startSize = normalSize;
        cam.orthographicSize = startSize;
    }

    void LateUpdate()
    {
        if (player == null) return;

        // Handle camera following
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Handle zoom effect
        if (isZooming)
        {
            float elapsed = Time.time - startTime;
            if (elapsed < zoomDuration / 2)
            {
                // First half - zoom in
                float t = elapsed / (zoomDuration / 2);
                cam.orthographicSize = Mathf.Lerp(startSize, zoomSize, t);
            }
            else if (elapsed < zoomDuration)
            {
                // Second half - zoom out
                float t = (elapsed - zoomDuration / 2) / (zoomDuration / 2);
                cam.orthographicSize = Mathf.Lerp(zoomSize, normalSize, t);
            }
            else
            {
                // End zoom effect
                isZooming = false;
                cam.orthographicSize = normalSize;
            }
        }
    }
}