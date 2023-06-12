using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZoneDetection : MonoBehaviour
{
    public bool InSafeZone = true;
    bool monsterSpawned = false;
    public GameObject monster;
    public GameObject CameraController;
    CameraSwtichController camControl;
    GameObject colby;
    //All monster spwaner locations
    public GameObject monsterSpawner1;
    public GameObject monsterSpawner2;
    public GameObject monsterSpawner3;
    public GameObject monsterSpawner4;

    void OnStart()
    {
        camControl = CameraController.GetComponent<CameraSwtichController>();
    }

    void OnTriggerEnter (Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            InSafeZone = true;
            CharacterMover garryScript = collision.transform.parent.gameObject.GetComponent<CharacterMover>();
            garryScript.moveSpeed = 6f;
        }
        
    }
    void OnTriggerExit (Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (camControl.topCam == false)
            {
                InSafeZone = false;
                CharacterMover garryScript = collision.transform.parent.gameObject.GetComponent<CharacterMover>();
                garryScript.moveSpeed = 1.5f;
            }
        }
    }

    void Update()
    {
        
        if (InSafeZone == false && monsterSpawned == false)
        {
            int spawner = Random.Range(1, 5);
            switch (spawner)
            {
                case 1:
                    colby = Instantiate(monster, monsterSpawner1.transform.position, monsterSpawner1.transform.rotation);
                    break;
                case 2:
                    colby = Instantiate(monster, monsterSpawner2.transform.position, monsterSpawner2.transform.rotation);
                    break;
                case 3:
                    colby = Instantiate(monster, monsterSpawner3.transform.position, monsterSpawner3.transform.rotation);
                    break;
                case 4:
                    colby = Instantiate(monster, monsterSpawner4.transform.position, monsterSpawner4.transform.rotation);
                    break;
            }
            
            monsterSpawned = true;
        }
        else if (InSafeZone == true)
        {
            Destroy(colby);
            monsterSpawned = false;
        }
    }
}
