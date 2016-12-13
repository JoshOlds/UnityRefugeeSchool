using UnityEngine;
using System.Collections;

public class VelocityLogger : MonoBehaviour {

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        Debug.Log("VelocityLogger: " + rb.velocity);
    }
}
