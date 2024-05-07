using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyControl : MonoBehaviour
{
    public float maxHeight = 90f; // Maximum allowed height on the Y-axis

    private void Update()
    {
        // Check if the VR Rig has exceeded the maximum height
        if (transform.position.y > maxHeight)
        {
            // If the height exceeds the maximum, clamp the position to the maximum height
            Vector3 newPosition = transform.position;
            newPosition.y = maxHeight;
            transform.position = newPosition;
        }
    }
}
