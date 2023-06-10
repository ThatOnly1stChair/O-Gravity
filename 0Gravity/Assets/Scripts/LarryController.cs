using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LarryController : MonoBehaviour
{
    Vector3 move;
    public float speed = 10f;
    public float border = 35f;
    float xDomain;
    // Start is called before the first frame update
    void Start()
    {
        
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
        
        if (transform.position.z >= border || transform.position.z <= -border)
        {
            transform.Translate(Vector3.zero);
            //transform.position.x = new Vector3(xDomain, 0f, 0f);
        }
        else
        {
            if (transform.position.x == border || transform.position.x == -border)
            {
                move = transform.forward * speed * z;
            }
            transform.Translate(move * Time.deltaTime);
        }

        


    }
}
