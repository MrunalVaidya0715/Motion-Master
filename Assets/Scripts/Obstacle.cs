using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 5;
   
    public void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
    
}
