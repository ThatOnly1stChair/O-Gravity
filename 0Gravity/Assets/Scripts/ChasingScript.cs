using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingScript : MonoBehaviour
{
    public GameObject Player;
    public float moveSpeed = 4.0f;
    public float maxDistance = 10f;
    public float minDistance = 5f;
    float dist;
    Rigidbody RB;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("/Garry/Body");
        RB = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player.transform.position);

        dist = Vector3.Distance(transform.position, Player.transform.position);
        if (dist >= minDistance)
        {
            moveSpeed = 10f;
        }
        else if (dist <= maxDistance)
        {
            moveSpeed = 20f;
        } else
        {
            moveSpeed = 40f;
        }

    }

    void FixedUpdate()
    {
        RB.AddRelativeForce(new Vector3(0.0f, 0.0f, moveSpeed));
    }
}
