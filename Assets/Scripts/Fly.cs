using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using TMPro;

public class Fly : MonoBehaviour
{
     public XRController controller; // Reference to the XRController
    public AudioClip flapSound; // Reference to the flap sound clip

    public float flyForce = 3.5f; // Adjust the fly force

    private bool canFly = true; // Control whether the bird can fly
    private Rigidbody rb; // Reference to the Rigidbody of the VR Rig
    private AudioSource audioSource; // Reference to the AudioSource component
    public TMP_Text FlapsText;
    private int flaps = -1;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
        audioSource.clip = flapSound; // Assign the flap sound clip to the AudioSource
    }

    private void Update()
    {
        // Check for input to trigger flying action
        // if (canFly && controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue)
        // {
        //     FlyUp();
        //     PlayFlapSound(); // Call the function to play flap sound
        // }
        if (canFly && Input.GetKeyDown(KeyCode.U))
        {
            FlyUp();
            PlayFlapSound(); // Call the function to play flap sound
        }
    }
     void UpdateScoreUI()
    {
        if (FlapsText != null)
        {
            FlapsText.text = "Flaps: " + flaps.ToString(); // Update the text displayed on the UI
        }
    }

    public void FlyUp()
    {
        rb.velocity = Vector3.zero; // Reset velocity before applying force
        rb.AddForce(Vector3.up * flyForce, ForceMode.Impulse); // Apply upward force
        flaps++;
        UpdateScoreUI();
    }

    public void PlayFlapSound()
    {
        audioSource.Play(); // Play the flap sound
    }
}
