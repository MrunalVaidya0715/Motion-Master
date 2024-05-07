using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public float flapForce = 10f; // Adjust the flap force
    public float flapDuration = 0.5f; // Adjust the duration of the flap

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Flap(float velocityMagnitude)
    {
        // Customize the flap force based on the controller velocity magnitude
        float adjustedFlapForce = flapForce * velocityMagnitude;

        StartCoroutine(ApplyFlapForce(adjustedFlapForce));
    }

    IEnumerator ApplyFlapForce(float adjustedFlapForce)
    {
        rb.velocity = Vector3.zero; // Reset velocity before applying force
        rb.AddForce(Vector3.up * adjustedFlapForce, ForceMode.Impulse); // Apply upward force

        yield return new WaitForSeconds(flapDuration);

        rb.velocity = Vector3.zero; // Reset velocity after the flap duration
    }
}
