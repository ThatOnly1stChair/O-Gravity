using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOutput : MonoBehaviour
{
    Vector3 initPos;
    public float speed = 1.0f;

    void Start()
    {
        initPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
    //What happens once the sensor or event has been triggered
    public void Trigger()
    {
        transform.Translate(0.0f, 4.0f, 0.0f);
        
    }

    void Update()
    {
        if (transform.position.y >= (initPos.y + 4.0f))
        {
            transform.Translate(0.0f, 0.0f, 0.0f);
        }
    }
}
