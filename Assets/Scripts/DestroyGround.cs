using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGround : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Destroy(other.gameObject);
        
        }
    }
}
