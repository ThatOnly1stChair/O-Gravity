using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript: MonoBehaviour
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
    void Update()
    {
        
        if (buttonPressed == true)
        {
            if (beenActivated == false)
            {
                while (transform.position.x > (initPos.x - 0.4f))
                {
                    transform.Translate(-speed, 0.0f, 0.0f);
                }
                transform.Translate(0.0f, 0.0f, 0.0f);
                doorOutput.Trigger();
            } 
            else
            {
                Debug.Log("Already pressed once, calm down.");
            }
            beenActivated = true;
            buttonPressed = false;
        }
    }

    public void ButtonPress()
    {
        buttonPressed = true;
    }
}
