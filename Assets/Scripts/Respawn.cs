using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private float yRespawnValue;
    
    private Vector3 startPosition;
    private Quaternion startRotation;

    private Rigidbody rb;

    private void Awake()
    {
        //Save initial position of object
        startPosition = transform.position;
        startRotation = transform.rotation;

        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //If the object falls below a predefined Y value, then respawn
        if(transform.position.y < yRespawnValue)
        {
            transform.position = startPosition;
            transform.rotation = startRotation;

            //Reset any forces on the rigidbody so the object does not continue moving once respawned
            if (rb) rb.velocity = Vector3.zero;
        }
    }
}
