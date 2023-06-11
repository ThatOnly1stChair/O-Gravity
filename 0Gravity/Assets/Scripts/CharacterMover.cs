using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    public CharacterController controller;

    //Variables
    public float moveSpeed = 12f;
    public float gravity = -9.81f;

    //For finding the ground
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    //For gravity and falling
    Vector3 velocity;
    public Camera GarryCamera;

    //Used to rotate the body with the camera
    public float mouseSensitivity;
    public Transform playerBody;
    float xRotation = 0f;

    //For setting up raycast for item interaction
    float rayRange = 2f;
    public LayerMask layerToHit;
    bool interactableReal = false;
    public Transform holdArea;
    private GameObject heldObject;
    public GameObject handshot;
    private Rigidbody heldObjectRB;
    private GameObject hitObj;
    bool holding = false;

    //For turning on/off the UI for interacting
    public GameObject interactText;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Checking for contact with ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded)
        {
            velocity.y = -2f;
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        //Moving character with WASD
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * moveSpeed * Time.deltaTime);

        //Character moved by gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //Camera Controls
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        GarryCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
        ColliderCheck();
        
    }

    //To see if interactable item is in front of camera and to interact with it
    void ColliderCheck()
    {
        Ray ray = new Ray(GarryCamera.transform.position, GarryCamera.transform.forward);
        Debug.DrawRay(GarryCamera.transform.position, GarryCamera.transform.forward * rayRange, Color.white);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayRange, layerToHit))
        {
            //Debug.Log("Hit item!");
            hitObj = hit.transform.gameObject;
            interactText.SetActive(true);
            interactableReal = true;
        }
        else
        {
            interactText.SetActive(false);
            interactableReal = false;
        }
        //Button outputs
        //Lets go of the held object
        if (Input.GetButtonDown("Interact") && holding == true)
        {
            heldObjectRB.useGravity = true;
            heldObjectRB.drag = 1;
            heldObjectRB.constraints = RigidbodyConstraints.None;
            heldObjectRB.transform.parent = null;
            heldObject = null;
            holding = false;
        }
        else if (interactableReal == true)
        {
            //Grabs onto the object in range of ray
            if (Input.GetButtonDown("Interact") && holding == false)
            {
                if (hitObj.tag == "Grabbable")
                {
                    heldObjectRB = hitObj.GetComponent<Rigidbody>();
                    heldObjectRB.useGravity = false;
                    heldObjectRB.drag = 10;
                    heldObjectRB.constraints = RigidbodyConstraints.FreezeRotation;
                    heldObjectRB.transform.parent = holdArea;
                    heldObject = hitObj;
                    holding = true;
                }
                
                //Picks up and holds onto slingshot
                if (hitObj.tag == "Weapon")
                {
                    hitObj.SetActive(false);
                    handshot.SetActive(true);
                }
            }
        }
        
    }

}
