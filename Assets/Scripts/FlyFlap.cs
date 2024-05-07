using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyFlap : MonoBehaviour
{
    public Fly flyScript; // Reference to the Fly script (attached to the VR Rig)
    public string upperColliderTag = "UpperFlapCollider"; // Tag assigned to the upper flap collider
    public string lowerColliderTag = "LowerFlapCollider"; // Tag assigned to the lower flap collider

    private enum FlapStage { None, Upper, Lower }; // Enum to track flap stages
    private FlapStage currentFlapStage = FlapStage.None; // Current flap stage

    private void Start()
    {
        if (flyScript == null)
        {
            flyScript = GetComponent<Fly>(); // Try to get the Fly component if not assigned in the Inspector
        }

        if (flyScript == null)
        {
            Debug.LogWarning("FlyScript reference is not assigned or found on the GameObject.");
        }
        else
        {
            Debug.Log("Got Ref");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(upperColliderTag))
        {
            if (currentFlapStage == FlapStage.None || currentFlapStage == FlapStage.Upper)
            {
                currentFlapStage = FlapStage.Upper; // Set current stage to upper if it's the first or upper is already triggered
                Debug.Log("Up Enter!");
            }
            else
            {
                // If lower is already triggered, reset to None
                currentFlapStage = FlapStage.None;
            }
        }

        if (other.CompareTag(lowerColliderTag))
        {
            if (currentFlapStage == FlapStage.Upper)
            {
                currentFlapStage = FlapStage.Lower; // Set current stage to lower if upper is already triggered
                Debug.Log("Low Enter!");
            }
            else
            {
                // If upper is not triggered yet or already exited, reset to None
                currentFlapStage = FlapStage.None;
            }
        }

        // Check if both upper and lower flaps are detected
        if (currentFlapStage == FlapStage.Lower)
        {
            Debug.Log("Flap detected!");
            PerformFlap(); // Perform the flap action
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(upperColliderTag))
        {
            if (currentFlapStage == FlapStage.Upper)
            {
                currentFlapStage = FlapStage.None; // Reset current stage when upper collider is exited
                Debug.Log("Up Exit!");
            }
        }

        if (other.CompareTag(lowerColliderTag))
        {
            if (currentFlapStage == FlapStage.Lower)
            {
                currentFlapStage = FlapStage.None; // Reset current stage when lower collider is exited
                Debug.Log("Low Exit!");
            }
        }
    }

    private void PerformFlap()
    {
        // Trigger the FlyUp() function from the Fly script if the reference is valid
        if (flyScript != null)
        {
            flyScript.FlyUp();
            flyScript.PlayFlapSound(); // Optionally, play the flap sound from the Fly script
        }
        else
        {
            Debug.LogWarning("FlyScript reference is null. Cannot perform the flap.");
        }

        // Reset flap stage after performing the flap action
        currentFlapStage = FlapStage.None;
    }
}
