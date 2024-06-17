using UnityEngine;
using System.Collections;

public class ConnectableFixedJoint : MonoBehaviour
{
    public bool isConnected = false; //To check if objects are already connected
    private FixedJoint fixedJoint; //FixedJoint component to connect objects
    private bool isConnecting = false; //To prevent multiple connections

    private void OnTriggerEnter(Collider other)
    {
        //Check if the other object has the correct tag and is not already connected
        if (other.CompareTag("Connectable") && !isConnected && !isConnecting)
        {
            //Make sure we aren't connecting to ourselves
            if (other.gameObject != gameObject)
            {
                //Connect to the other object
                StartCoroutine(ConnectObjects(other.gameObject));
            }
        }
    }

    private IEnumerator ConnectObjects(GameObject otherObject)
    {
        isConnecting = true;

        //Wait for a short duration to prevent both objects from connecting at the same time
        yield return new WaitForSeconds(0.1f);

        //Check again to make sure the connection hasn't been made by the other object
        if (!isConnected)
        {
            //Add a FixedJoint component to the current object
            fixedJoint = gameObject.AddComponent<FixedJoint>();

            //Set the connected body to the other object's Rigidbody
            fixedJoint.connectedBody = otherObject.GetComponent<Rigidbody>();

            //Set isConnected to true for both objects
            isConnected = true;
            otherObject.GetComponent<ConnectableFixedJoint>().isConnected = true;

            Debug.Log("Objects connected");

            //Adjust physics properties to ensure a strong connection
            fixedJoint.breakForce = Mathf.Infinity;
            fixedJoint.breakTorque = Mathf.Infinity;
            fixedJoint.enableCollision = false;
            fixedJoint.enablePreprocessing = false;
        }

        isConnecting = false;
    }
}
