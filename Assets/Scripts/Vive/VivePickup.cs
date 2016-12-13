using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VivePickup : MonoBehaviour {

    /* This script is to be used to allow for picking up and manipulating of objects with the vive controller
     * 
     * 
     * */
    //It is important to use an attachment transform that isn't scaled!!

    public ViveControllerManager ControllerManager;
    private Valve.VR.EVRButtonId GrabButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    public ViveControllerManager.Controller Controller;

    private List<FixedJoint> attachedObjects = new List<FixedJoint>();


    // Use this for initialization
    void Start () {

	}
	
	// FixedUpdate is called once per physics frame
	void FixedUpdate () {
        if(ControllerManager.IsReady())
        {
            if (!ControllerManager.GetPress(GrabButton, Controller)) //Released button
            {
                foreach (FixedJoint fj in attachedObjects)
                {
                    GameObject other = fj.gameObject;
                    Rigidbody otherRb = other.GetComponent<Rigidbody>();
                    TrackedVelocityObject tracker = other.GetComponent<TrackedVelocityObject>();
                   // Debug.Log("Releasing joint");
                    Destroy(fj); //Can we destroy an object in a list? (Update) Yes, yes we can
                    Destroy(tracker);
                }
                attachedObjects.Clear();
            }
        }
	    
	}

    void OnTriggerEnter(Collider other)
    {
        if(ControllerManager.IsReady()) //We should move this check to the ControllerManager
        {
            if (ControllerManager.GetPress(GrabButton, Controller)) //Is button down?
            {

                GameObject otherObject = other.gameObject;
                if (otherObject.GetComponent<FixedJoint>() == null) //Only one joint. This call happens a few timems on contact
                {
                    //Debug.Log("Attaching joint");
                    FixedJoint fj = otherObject.AddComponent<FixedJoint>();
                    Rigidbody rb = GetComponent<Rigidbody>();
                    TrackedVelocityObject tracker = otherObject.AddComponent<TrackedVelocityObject>();
                    tracker.Initialize(10);
                    fj.connectedBody = rb;
                    attachedObjects.Add(fj);
                }
                //else Debug.Log("Joint already attached.");

            }
        }
        
    }
}
