using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class VelocityTracker : MonoBehaviour
{
    [SerializeField] private XRController leftCon, rightCon;
    public float flapStrength = 5.0f; // Adjust this value to control the bird's flap strength
    public float gravityMultiplier = 2.0f; // Adjust this value to control gravity effect

    private Vector3 leftVelocity, rightVelocity;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Awake(){

    }

    private void Update()
    {
        // Calculate vertical velocity based on controller swings
        CalculateVerticalVelocity(leftCon, ref leftVelocity);
        CalculateVerticalVelocity(rightCon, ref rightVelocity);

        // Calculate the overall vertical velocity for the bird
        float totalVerticalVelocity = (leftVelocity.y + rightVelocity.y) * flapStrength * Time.deltaTime;

        // Apply vertical movement to the bird
        Vector3 newPosition = transform.position + Vector3.up * totalVerticalVelocity;
        rb.MovePosition(newPosition);

        // Apply gravity to the bird
        rb.AddForce(Vector3.down * gravityMultiplier, ForceMode.Acceleration);
    }

    private void CalculateVerticalVelocity(XRController controller, ref Vector3 velocity)
    {
        if (controller != null && controller.inputDevice.TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 currentVelocity))
        {
            velocity = currentVelocity;
        }
    }
}
