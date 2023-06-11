using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningScript : MonoBehaviour
{
    float rotationSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        transform.Rotate(0f, rotationSpeed, 0f, Space.Self);
    }
}
