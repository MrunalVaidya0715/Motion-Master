using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class VelTracker : MonoBehaviour
{
    [SerializeField] private XRController leftCon, rightCon;
    private Vector3 leftVelo, rightVelo;
    // Start is called before the first frame update
    public BirdMovement birdMovement;
    void Start()
    {
        
    }
    void Awake()
    {

    }
    // Update is called once per frame
    private void Update()
    {
        if (leftCon.controllerNode == XRNode.LeftHand)
        {
            leftCon.inputDevice.TryGetFeatureValue(CommonUsages.deviceVelocity, out leftVelo);
            birdMovement.Flap(leftVelo.magnitude);
        }

        if (rightCon.controllerNode == XRNode.RightHand)
        {
            rightCon.inputDevice.TryGetFeatureValue(CommonUsages.deviceVelocity, out rightVelo);
            birdMovement.Flap(rightVelo.magnitude);
        }
    }
}
