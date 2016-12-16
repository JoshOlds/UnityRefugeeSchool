using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class EventOnTriggerEnter : MonoBehaviour {

    public UnityEvent OnTriggerEnterEvent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        OnTriggerEnterEvent.Invoke();
    }
}
