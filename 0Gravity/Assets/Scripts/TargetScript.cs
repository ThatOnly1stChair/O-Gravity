using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript: MonoBehaviour
{

    bool beenActivated = false;


    //For gameobject that should be moved, spawned, despawned, etc.
    public GameObject Door;
    Vector3 initPos;
    public float speed = 0.01f;
    //Get script from other gameobject
    public DoorOutput doorOutput;
    bool buttonPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        initPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        doorOutput = Door.GetComponent<DoorOutput>();
}
    
    // Update is called once per frame
    void OnTriggerEnter(Collider collider)
    {   

        if (collider.gameObject.tag == "bullet")
        {
            
            doorOutput.Trigger();
            transform.position += new Vector3(0.0f, 10.0f, 0.0f); 
            
        }
    }

    public void ButtonPress()
    {
        buttonPressed = true;
    }
}
