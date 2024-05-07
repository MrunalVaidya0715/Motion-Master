using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public float threshold;
    public float freezeDuration = 2f;
    private Rigidbody rb;

    private void Start()
    {
        // Get the Rigidbody component attached to the object
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component not found on the object!");
        }
    }

    private void FixedUpdate()
    {
        if (transform.position.y < threshold)
        {
             transform.position = new Vector3(0, 45f, 0);
            StartCoroutine(FreezeAndRespawn());
        }
    }

    private IEnumerator FreezeAndRespawn()
    {
        // Freeze the Y-axis by temporarily setting the Rigidbody's constraints
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

        // Wait for the specified duration
        yield return new WaitForSeconds(freezeDuration);

        // Unfreeze the Y-axis by resetting Rigidbody's constraints
        rb.constraints = RigidbodyConstraints.None;
    }
}
