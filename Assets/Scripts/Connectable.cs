using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connectable : MonoBehaviour
{
    private bool isConnected = false; //Check if the objects are already connected

    private void OnTriggerEnter(Collider other)
    {
        //If we are colliding with the connectable element, and we aren't already connected
        if(other.CompareTag("Connectable") && !isConnected)
        {
            //Turn on the highlight of the other object
            MeshRenderer otherObjectRenderer = other.GetComponent<MeshRenderer>();

            if (otherObjectRenderer)
                otherObjectRenderer.enabled = true;

            ConnectObjects();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Connectable") && !isConnected)
        {
            //Turn off the highlight
            MeshRenderer otherObjectRenderer = other.GetComponent<MeshRenderer>();

            if (otherObjectRenderer)
                otherObjectRenderer.enabled = false;
        }
    }

    private void ConnectObjects()
    {

    }
}
