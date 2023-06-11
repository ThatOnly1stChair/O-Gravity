using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class LarryController : MonoBehaviour
{
    Vector3 move;
    public float speed = 10f;
    public float border = 35f;
    public float height;
    float xDomain;
    float zDomain;
    float buffer;
    public GameObject spotlight;
    Light light;

    // Start is called before the first frame update
    void Start()
    {
        buffer = border - 0.2f;
        transform.position = new Vector3(border, height, -border);
        light = spotlight.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        //Getting input data from WASD
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        //Moving character with WASD

        xDomain = transform.position.x;
        xDomain = Mathf.Clamp(xDomain, -border, border);
        zDomain = transform.position.z;
        zDomain = Mathf.Clamp(zDomain, -border, border);
        //For moving on z axis
        if (Math.Abs(transform.position.z) > buffer)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Round(transform.position.z));
        }
        if (Math.Abs(transform.position.z) > border)
        {
            transform.Translate(Vector3.zero);
            transform.position = new Vector3(xDomain, transform.position.y, zDomain);
        }
        else
        {
            if (Math.Abs(transform.position.x) == border)
            {
                move = transform.forward * speed * z * (Math.Abs(z)-Math.Abs(x));
            }
            transform.Translate(move * Time.deltaTime);
        }
        //For moving on x axis
        if (Math.Abs(transform.position.x) > buffer)
        {
            transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y, transform.position.z);
        }
        if (Math.Abs(transform.position.x) > border)
        {
            transform.Translate(Vector3.zero);
            transform.position = new Vector3(xDomain, transform.position.y, zDomain);
        }
        else
        {
            if (Math.Abs(transform.position.z) == border)
            {
                move = transform.right * speed * x * (Math.Abs(x) - Math.Abs(z));
            }
            transform.Translate(move * Time.deltaTime);
        }

        //Rotates camera based on position
        if (transform.position.x == -border)
        {
            spotlight.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            light.spotAngle = 30f;
            light.intensity = 8f;
        }
        else if (transform.position.z == border)
        {
            spotlight.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            light.spotAngle = 30f;
            light.intensity = 8f;
        }
        else if (transform.position.z == -border)
        {
            spotlight.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            light.spotAngle = 30f;
            light.intensity = 8f;
        }
        else if (transform.position.x == border)
        {
            spotlight.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
            light.spotAngle = 30f;
            light.intensity = 8f;
        }
        if (transform.position.x <= -border && transform.position.z <= -border)
        {
            spotlight.transform.rotation = Quaternion.Euler(0f, 45f, 0f);
            light.spotAngle = 12f;
            light.intensity = 24f;
        }
        if (transform.position.x >= border && transform.position.z <= -border)
        {
            spotlight.transform.rotation = Quaternion.Euler(0f, -45f, 0f);
            light.spotAngle = 12f;
            light.intensity = 24f;
        }
        
        if (transform.position.x >= border && transform.position.z >= border)
        {
            spotlight.transform.rotation = Quaternion.Euler(0f, -135f, 0f);
            light.spotAngle = 12f;
            light.intensity = 24f;
        }
        
        if (transform.position.x <= -border && transform.position.z >= border)
        {
            spotlight.transform.rotation = Quaternion.Euler(0f, 135f, 0f);
            light.spotAngle = 12f;
            light.intensity = 24f;
        }
           
    }
}
