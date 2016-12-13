using UnityEngine;
using System.Collections;

public class PickUpable : MonoBehaviour, IPickUpable {

    public bool DebugMode = false;
    public int VelocityTrackerBuffer;
    public float ReleaseForceMultiplier = 1.0f;
    private bool isPickedUp = false;
    private FixedJoint fj;
    private TrackedVelocityObject tracker;

    public FixedJoint PickUp(Rigidbody rb)
    {
        if(!isPickedUp)
        {
            if(DebugMode) Debug.Log("Attaching joint: " + gameObject.name);
            fj = gameObject.AddComponent<FixedJoint>();
            tracker = gameObject.AddComponent<TrackedVelocityObject>();
            tracker.Initialize(10, ReleaseForceMultiplier);
            fj.connectedBody = rb;
            isPickedUp = true;
        }
        return fj;
    }

    public void Drop()
    {
        if (DebugMode) Debug.Log("Dropping: " + gameObject.name);
        tracker.ForceMultiplier = ReleaseForceMultiplier;
        Destroy(fj);
        Destroy(tracker);
        isPickedUp = false;
    }

    public bool IsPickedUp()
    {
        return isPickedUp;
    }
}
