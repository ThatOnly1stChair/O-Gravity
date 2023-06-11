using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public float triggerDistance = 0.5f;
    bool beenActivated = false;
    public LayerMask layerToHit;
    Ray ray;

    //For gameobject that should be moved, spawned, despawned, etc.
    public GameObject Door;
    Vector3 initPos;
    public float speed = 0.05f;
    //Get script from other gameobject
    public DoorOutput doorOutput;

    // Start is called before the first frame update
    void Start()
    {
        initPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        doorOutput = Door.GetComponent<DoorOutput>();
}

    // Update is called once per frame
    void Update()
    {
        ray = new Ray(transform.position, transform.up);
        Debug.DrawRay(transform.position, transform.up * triggerDistance, Color.white);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, triggerDistance, layerToHit) && beenActivated == false)
        {
            beenActivated = true;
            while (transform.position.y > (initPos.y - 1.0f))
            {
                transform.Translate(0.0f, -speed, 0.0f);
            }
            transform.Translate(0.0f, 0.0f, 0.0f);
            doorOutput.Trigger();
        }
    }

}
