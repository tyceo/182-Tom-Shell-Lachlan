using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    // References to the two HingeJoint2D components
    public HingeJoint2D hingeJointToChange;

    // Reference to the new Rigidbody2D to connect
    public Rigidbody2D newConnectedBody;

    void Start()
    {
        // Ensure the hingeJointToChange is set
        if (hingeJointToChange == null)
        {
            Debug.LogError("Please assign the specific HingeJoint2D component in the Inspector.");
        }
    }

    public void ChangeConnectedBody()
    {
        if (hingeJointToChange != null && newConnectedBody != null)
        {
            // Change the connected body of the specific HingeJoint2D
            hingeJointToChange.connectedBody = newConnectedBody;
            Debug.Log("Specific HingeJoint2D connected body changed.");
        }
        else
        {
            Debug.LogError("HingeJoint2D or newConnectedBody is missing.");
        }
    }
}
