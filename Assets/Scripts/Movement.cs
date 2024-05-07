using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float forwardSpeed = 2.0f; 
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forwardMovement = transform.forward * forwardSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + forwardMovement);
        // Debug information
        Debug.Log("Moving Forward: " + forwardMovement.magnitude + " meters per second");

        // Calculate distance from the ground (assuming the object's center is at ground level)
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            float distanceFromGround = hit.distance;
            Debug.Log("Distance from Ground: " + distanceFromGround + " meters");
        }
    }
}
