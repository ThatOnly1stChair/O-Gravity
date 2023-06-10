using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwtichController : MonoBehaviour
{
    //Link all the cameras
    public GameObject topViewCam;
    public GameObject GarryCam;

    bool topCam;

    void Awake()
    {
        topViewCam.SetActive(true);
        GarryCam.SetActive(false);
        topCam = true;
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Switch"))
        {
            if (topCam == true)
            {
                topViewCam.SetActive(false);
                GarryCam.SetActive(true);
                topCam = false;
            }
            else
            {
                topViewCam.SetActive(true);
                GarryCam.SetActive(false);
                topCam = true;
            }
            
        }
    }
}
