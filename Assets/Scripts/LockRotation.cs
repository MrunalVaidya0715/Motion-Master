using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotation : MonoBehaviour
{
    private void Update()
    {
        // Lock rotation of the XR Rig (assuming Y-axis rotation)
        transform.rotation = Quaternion.Euler(0f, transform.eulerAngles.y, 0f);
    }
}
