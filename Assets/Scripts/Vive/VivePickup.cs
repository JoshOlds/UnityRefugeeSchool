using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VivePickup : MonoBehaviour {

    //It is important to use an attachment transform that isn't scaled!!

    public ViveControllerManager ControllerManager;
    private Valve.VR.EVRButtonId GrabButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    public ViveControllerManager.Controller Controller;
    public Transform AttachTransform;

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
                    attachedObjects.Remove(fj);
                    Destroy(fj);
                }
            }
        }
	    
	}

    void OnTriggerEnter(Collider other)
    {
        if(ControllerManager.IsReady())
        {
            if (ControllerManager.GetPress(GrabButton, Controller))
            {

                GameObject otherObject = other.gameObject;
                if (otherObject.GetComponent<FixedJoint>() == null)
                {
                    FixedJoint fj = otherObject.AddComponent<FixedJoint>();
                    Rigidbody rb = GetComponent<Rigidbody>();
                    fj.connectedBody = rb;
                }

            }
        }
        
    }
}
