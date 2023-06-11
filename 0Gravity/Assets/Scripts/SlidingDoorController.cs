using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoorController : MonoBehaviour
{
    public GameObject slidingDoor;
    
    Vector3 move;
    public float speed = 10f;
    public float leftBorder = 1.75f;
    public float rightBorder = -2.25f;
    float xDomain;
    float leftBuffer;
    float rightBuffer;

    // Start is called before the first frame update
    void Start()
    {
        leftBuffer = leftBorder - 0.05f;
        rightBuffer = rightBorder + 0.05f;
        slidingDoor.transform.position = new Vector3(leftBorder, slidingDoor.transform.position.y, slidingDoor.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        //Getting input data from WASD
        float x = Input.GetAxis("Horizontal");
        //Moving character with WASD

        xDomain = slidingDoor.transform.position.x;
        xDomain = Mathf.Clamp(xDomain, rightBorder, leftBorder);
        
        
        //For moving on x axis
        if (slidingDoor.transform.position.x > leftBuffer)
        {
            slidingDoor.transform.position = new Vector3(leftBorder, slidingDoor.transform.position.y, slidingDoor.transform.position.z);
        }
        if (slidingDoor.transform.position.x < rightBuffer)
        {
            slidingDoor.transform.position = new Vector3(rightBorder, slidingDoor.transform.position.y, slidingDoor.transform.position.z);
        }
        if (slidingDoor.transform.position.x > leftBorder || slidingDoor.transform.position.x < rightBorder)
        {
            transform.Translate(Vector3.zero);
            slidingDoor.transform.position = new Vector3(xDomain, slidingDoor.transform.position.y, slidingDoor.transform.position.z);
        }
        else
        {
            move = slidingDoor.transform.right * -speed * x;
            slidingDoor.transform.Translate(move * Time.deltaTime);
        }
    }
}
