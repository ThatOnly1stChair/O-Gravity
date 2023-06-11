using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript: MonoBehaviour
{

    bool beenActivated = false;


    //For gameobject that should be moved, spawned, despawned, etc.
    public GameObject Door;
    public GameObject handlePivot;
    public GameObject handle;
    Vector3 initRot;
    public float speed = 2;
    //Get script from other gameobject
    public DoorOutput doorOutput;
    bool buttonPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        initRot = new Vector3(handlePivot.transform.rotation.x, handlePivot.transform.rotation.y, handlePivot.transform.rotation.z);
        handle.transform.rotation = Quaternion.Euler(-30f, 0f, 0f);
        handlePivot.transform.rotation = Quaternion.Euler(-30f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion target = Quaternion.Euler(30f, 0f, 0f);
        doorOutput = Door.GetComponent<DoorOutput>();
        if (buttonPressed == true)
        {
            if (beenActivated == false)
            {
                while (handlePivot.transform.rotation.x < (target.x - 0.2f))
                {
                    
                    handlePivot.transform.rotation = Quaternion.Slerp(handlePivot.transform.rotation, target, Time.deltaTime * speed);
                    handle.transform.rotation = Quaternion.Slerp(handlePivot.transform.rotation, target, Time.deltaTime * speed);
                }
                
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

    public void SwitchPress()
    {
        buttonPressed = true;
    }
}
