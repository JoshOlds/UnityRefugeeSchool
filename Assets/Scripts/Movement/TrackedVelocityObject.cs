using UnityEngine;
using System.Collections;

public class TrackedVelocityObject : MonoBehaviour {

    private bool initialized = false;
    private Vector3[] positionsArr;
    private Vector3[] rotationsArr;
    public float ForceMultiplier;

    private Rigidbody rb;
    
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    if(initialized)
        {
            for(int i = (positionsArr.Length - 1); i > 0; i--)
            {
                positionsArr[i] = positionsArr[i - 1];
                rotationsArr[i] = rotationsArr[i - 1];
            }
            positionsArr[0] = transform.position;
            rotationsArr[0] = transform.localEulerAngles;
        }
	}

    public void Initialize(int buffer, float forceMultiplier)
    {
        positionsArr = new Vector3[buffer];
        rotationsArr = new Vector3[buffer];
        ForceMultiplier = forceMultiplier;
        initialized = true;
    }

    public Vector3 GetVelocity()
    {
        if (!initialized) throw new System.Exception("TrackedVelocityObject has not been initialized. Please use .Initialize()");
        Vector3 difference = positionsArr[0] - positionsArr[positionsArr.Length - 1];
        return difference;
    }

    public Vector3 GetRotation()
    {
        if (!initialized) throw new System.Exception("TrackedVelocityObject has not been initialized. Please use .Initialize()");
        Vector3 difference = rotationsArr[0] - rotationsArr[rotationsArr.Length - 1];
        return difference;
    }

    public void OnDestroy()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(GetVelocity() * ForceMultiplier * rb.mass , ForceMode.Force);
        rb.AddTorque(-1 * GetRotation() * ForceMultiplier * rb.mass, ForceMode.Force);
    }
}
