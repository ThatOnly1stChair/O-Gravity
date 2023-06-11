using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwtichController : MonoBehaviour
{
    //Link all the cameras
    public GameObject topViewCam;
    public GameObject GarryCam;
    //Link all gameobjects with controllers
    public GameObject LarryController;
    public GameObject GarryController;
    public bool topCam;

    //Connect to garry's stats
    float garrySpeed;
    float garrySense;

    void Awake()
    {
        topViewCam.SetActive(true);
        GarryCam.SetActive(false);
        LarryController.GetComponent<LarryController>().enabled = true;
        GarryController.GetComponent<CharacterMover>().enabled = false;
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
                LarryController.GetComponent<LarryController>().enabled = false;
                GarryController.GetComponent<CharacterMover>().enabled = true;
                topCam = false;
                
            }
            else
            {
                topViewCam.SetActive(true);
                GarryCam.SetActive(false);
                LarryController.GetComponent<LarryController>().enabled = true;
                GarryController.GetComponent<CharacterMover>().enabled = false;
                topCam = true;
            }
            
        }
        

    }

    public void SwitchCamera(Camera camera)
    {
        topViewCam.SetActive(false);
        GarryCam.SetActive(false);
        LarryController.GetComponent<LarryController>().enabled = false;
        //GarryController.GetComponent<CharacterMover>().enabled = false;
        topCam = false;

    }

    public void SwitchToGarry(Camera camera)
    {
        GarryCam.SetActive(true);
        camera.gameObject.SetActive(false);
        topViewCam.SetActive(false);
        LarryController.GetComponent<LarryController>().enabled = false;
        GarryController.GetComponent<CharacterMover>().enabled = true;
        topCam = false;

        
    }
}
