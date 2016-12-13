using UnityEngine;
using System.Collections;

public interface IPickUpable
{
    FixedJoint PickUp(Rigidbody rb);
    void Drop();
    bool IsPickedUp();
}
