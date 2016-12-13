using UnityEngine;
using System.Collections;

public class DeactivateObjectOnStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("Deactivating: " + gameObject.name);
        gameObject.SetActive(false);
        Debug.Log(gameObject.activeSelf);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
