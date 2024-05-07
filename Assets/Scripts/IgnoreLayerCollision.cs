using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreLayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(8, 9);
    }

}
