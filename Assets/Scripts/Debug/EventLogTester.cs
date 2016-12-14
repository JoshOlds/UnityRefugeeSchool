using UnityEngine;
using System.Collections;

public class EventLogTester : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Event1(string input)
    {
        Debug.Log("Debug Event Logger Fired (Event1) with message: " + input);
    }

    public void Event2(string input)
    {
        Debug.Log("Debug Event Logger Fired (Event2) with message: " + input);
    }

    public void Event3(string input)
    {
        Debug.Log("Debug Event Logger Fired (Event3) with message: " + input);
    }
}
