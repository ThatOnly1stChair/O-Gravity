using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTemplate : MonoBehaviour
{
    public float triggerDistance;

    //For gameobject that should be moved, spawned, despawned, etc.
    public GameObject Output;

    // Start is called before the first frame update
    void Start()
    {
        Ray ray = new Ray(transform.position, transform.up);

    }

    // Update is called once per frame
    void Update()
    {
        //Create if statement with sensor designed above to see if it is triggered
        if (1 == 1)
        {
            //Output.trigger();
        }
    }
}
