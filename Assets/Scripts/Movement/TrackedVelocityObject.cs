using UnityEngine;
using System.Collections;

public class TrackedVelocityObject : MonoBehaviour {

    private bool initialized = false;
    private Vector3[] positionsArr;
    
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    if(initialized)
        {
            for(int i = (positionsArr.Length - 1); i > 0; i--)
            {
                positionsArr[i] = positionsArr[i - 1];
            }
            positionsArr[0] = transform.position;
        }
	}

    public void Initialize(int buffer)
    {
        positionsArr = new Vector3[buffer];
        initialized = true;
    }

    public Vector3 GetVelocity()
    {
        if (!initialized) throw new System.Exception("TrackedVelocityObject has not been initialized. Please use .Initialize()");
        Vector3 difference = positionsArr[0] - positionsArr[positionsArr.Length - 1];
        return difference;
    }

    public void OnDestroy()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(GetVelocity() * 10.0f, ForceMode.Force);
    }
}
