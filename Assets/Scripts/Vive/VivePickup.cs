using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VivePickup : MonoBehaviour
{

    /* This script is to be used to allow for picking up and manipulating of objects with the vive controller
     * 
     * 
     * */
    //It is important to use an attachment transform that isn't scaled!!

    public ViveControllerManager ControllerManager;
    private Valve.VR.EVRButtonId GrabButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    public ViveControllerManager.Controller Controller;

    private List<IPickUpable> attachedObjects = new List<IPickUpable>();
    private Rigidbody rb;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        if (ControllerManager.IsReady())
        {
            if (!ControllerManager.GetPress(GrabButton, Controller)) //Released button
            {
                foreach (IPickUpable pickupable in attachedObjects)
                {
                    pickupable.Drop();
                }
                attachedObjects.Clear();
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (ControllerManager.IsReady()) //We should move this check to the ControllerManager
        {
            if (ControllerManager.GetPress(GrabButton, Controller)) //Is button down?
            {
                MonoBehaviour[] list = other.gameObject.GetComponents<MonoBehaviour>();
                foreach (MonoBehaviour mb in list)
                {
                    if (mb is IPickUpable)
                    {
                        IPickUpable pickupable = (IPickUpable)mb;
                        if (!pickupable.IsPickedUp())
                        {
                            pickupable.PickUp(rb);
                            attachedObjects.Add(pickupable);
                        }
                    }
                }
            }
        }

    }
}
